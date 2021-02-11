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
        public void AddNewNode(GeocodingAddressModelQueryParams address,  bool isRealSensor,  bool isSprinkler,  bool isEnable, int? locationIdLocation, int IdNearStation, bool isLightOn, bool isSecurityCameraOn)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //string sqlSelect = "Select Count(*) From Node";
                //int count =db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"IF NOT EXISTS (SELECT Id_Node FROM Node WHERE Id_Location = @IdLocation) INSERT INTO Node (Description,Id_Location,Id_NearStation,Is_enable,is_RealSensor,is_SprinklerOn, is_LightOn, is_SecurityCameraOn) Values (@Description,@IdLocation,@Id_NearStation,@Is_enable,@Is_RealSensor,@Is_Sprinkler, @is_LightOn, @is_SecurityCameraOn)";
                db.Execute(sqlInsert, new { Description = address.Street, IdLocation = locationIdLocation, Altitude = 0, Id_NearStation = IdNearStation, Is_enable = isEnable, Is_RealSensor = isRealSensor, Is_Sprinkler=isSprinkler, is_LightOn=isLightOn, is_SecurityCameraOn=isSecurityCameraOn });
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
    }
}
