using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartIrrigation.Application.BasicCRUD.Location;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.BasicCRUD.Location;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigation.Domain.Node;
using SmartIrrigation.Domain.Sensor;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Sensor
{
    public class SensorApplication : ISensorApplication
    {

        private readonly ILocationDomain _locationDomain;
        private readonly IDistrictDomain _districtDomain;
        private readonly IGeocodingDomain _geocodingDomain;
        private readonly ICountiesDomain _countyDomain;
        private readonly INodeDomain _nodeDomain;
        private readonly ISensorDomain _sensorDomain;


        public SensorApplication(ILocationDomain locationDomain, IDistrictDomain districtDomain, IGeocodingDomain geocodingDomain, ICountiesDomain countyDomain, INodeDomain nodeDomain, ISensorDomain sensorDomain)
        {
            _locationDomain = locationDomain;
            _districtDomain = districtDomain;
            _geocodingDomain = geocodingDomain;
            _countyDomain = countyDomain;
            _nodeDomain = nodeDomain;
            _sensorDomain = sensorDomain;
        }
        public int AddNewSensor(GeocodingAddressModelQueryParams address, in bool isEnable)
        {
            //TODO: REFACTOR THIS
            RootGeocodingDataModel<GeocodingAddressResponseModel> coords = _geocodingDomain.GetCoordsFromAddress(address);
            Location location = _locationDomain.RetrieveLocation(coords.Data.FirstOrDefault().Latitude,
                coords.Data.FirstOrDefault().Longitude);
            if (location == null)
            {
                District district = _districtDomain.GetDistrictByDistrictName(address.District);
                County county = _countyDomain.GetCountyByCountyName(address.County);
                _locationDomain.InsertLocationData(coords, district.Id_District, county.CountyId);
                location = _locationDomain.RetrieveLocation(coords.Data.FirstOrDefault().Latitude,
                    coords.Data.FirstOrDefault().Longitude);

            }

            SmartIrrigationModels.Models.DTOS.Node nodeAdded = _nodeDomain.GetNodeByStreet(location.Description);
            if (nodeAdded == null)
            {
                //TODO: VER ISTO POR CAUSA DO IDNEARSTATION
                _nodeDomain.AddNewNode(address,true,false,false,location.Id_Location,0, true,true
                
                
                );
            }
            else
            {
                if (!nodeAdded.IsRealSensor)
                {
                    return -1;
                }
            }

            int rowsAffected =_sensorDomain.AddNewSensor(location.Description,location.Id_Location??0,nodeAdded.IdNode, isEnable);

            return rowsAffected;
        }
    }
}
