using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public class NodeRepository:INodeRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public NodeRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public Node AddNewNode(AddNewNodeQueryParams parameters, int? IdLocation, int idNearStation)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //string sqlSelect = "Select Count(*) From Node";
                //int count =db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"IF NOT EXISTS (SELECT IdNode FROM Node WHERE IdLocation = @IdLocation) INSERT INTO Node (Description,IdLocation,IdNearStation,IsEnable,IsRealSensor,IsSprinklerOn, IsLightOn, IsSecurityCameraOn) Values (@Description,@IdLocation,@Id_NearStation,@Is_enable,@Is_RealSensor,@Is_Sprinkler, @is_LightOn, @is_SecurityCameraOn)";
                int insertedRows=db.Execute(sqlInsert, new { Description = parameters.Street, IdLocation = IdLocation, Altitude = 0, Id_NearStation = idNearStation, Is_enable = 1, Is_RealSensor = parameters.IsRealSensor, Is_Sprinkler=0, is_LightOn=0, is_SecurityCameraOn=0 });
                if (insertedRows > 0)
                {
                    string sqlRetriveveNode = $@"Select top 1 * From Node order by IdNode desc";
                    return db.QueryFirstOrDefault<Node>(sqlRetriveveNode);
                }
                else
                {
                    string sqlRetriveveNode = $@"Select top 1 * From Node WHERE IdLocation = @IdLocation order by IdNode desc";
                    return db.QueryFirstOrDefault<Node>(sqlRetriveveNode, new { IdLocation = IdLocation});
                 
                }
            }

            //return affectedRows;
        }

        public void ActivateSprinkler(int idNode)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                //string sqlSelect = "Select Count(*) From Node";
                //int count =db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"Update [dbo].[Node] set is_SprinklerON=1 where Id_Node={idNode}";
                db.Execute(sqlInsert);
            }
        }

        public void DectivateSprinkler(int idNode)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //string sqlSelect = "Select Count(*) From Node";
                //int count =db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"Update [dbo].[Node] set is_SprinklerON=0 where Id_Node = {idNode}";
                db.Execute(sqlInsert);
            }
        }

        public DashboardNodeData GetNodeDashboardDataById(int idNode)
        {
            IEnumerable<DashboardNodeData> articles = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                    string command = $@"  
                    SELECT N.IdNode
                           , N.Description
                           , N.IdLocation
                           , N.IdNearStation
                           , N.IsEnable
                           , N.IsRealSensor
                           , N.IsSprinklerON
                           , N.IsLightOn
                           , N.IsSecurityCameraOn
                           , L.Latitude 
                           , L.Longitude 
                           , C.Name as County 
                           , D.DistrictName 
                    FROM [dbo].[Node] N
                    inner join [dbo].[Location] L on N.IdLocation = L.Id_Location
					inner join District D on D.Id_District=L.Id_District
					inner join Counties C on L.Id_Countie =C.CountyId
                    where N.IdNode=@IdNode".Replace("@IdNode",idNode.ToString());

                    var dashboard = db.Query< Node, DashboardNodeData, DashboardNodeData >(command, (node, dash) =>
                    {
                        dash.Node = node;
                        return dash;
                    }, splitOn:"Latitude").AsList();

                    return dashboard.FirstOrDefault();

            }
            
        }

        public object TurnOnOrOfDevice(int idNode, string type,bool on)
        {
            string device = string.Empty;
            type = type.Replace(" ", "");
            if (type.ToLower() == "sensors")
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    int value = on ? 1 : 0;


                    string sqlquery = $"Update [dbo].[Sensor] set IsEnable={value.ToString()} where IdNode={idNode}";
                    return db.Execute(sqlquery);
                }
                

            }
            else
            {
                if (type.ToLower() == "light")
                    device += "IsLightOn";
                if (type.ToLower() == "sprinkler")
                    device += "IsSprinklerOn";
                if (type.ToLower() == "securitycamera")
                    device += "IsSecurityCameraOn";


                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    int value = on ? 1 : 0;
                    string sqlInsert = $"Update [dbo].[Node] set {device}={value.ToString()} where IdNode={idNode}";
                    return db.Execute(sqlInsert);
                }
            }
        }
    }
}
