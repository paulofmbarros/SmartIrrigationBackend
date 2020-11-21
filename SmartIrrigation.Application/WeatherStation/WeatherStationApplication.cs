using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.BasicCRUD.Location;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public class WeatherStationApplication : IWeatherStationApplication
    {
        private readonly IWeatherStationDomain _weatherStationDomain;
        private readonly ICountiesDomain _countiesDomain;
        private readonly IDistrictDomain _districtDomain;
        private readonly IGeocodingDomain _geocodingDomain;
        private readonly ILocationDomain _locationDomain;

        public WeatherStationApplication(IWeatherStationDomain weatherStationDomain, ICountiesDomain countiesDomain, IDistrictDomain districtDomain, IGeocodingDomain geocodingDomain, ILocationDomain locationDomain)
        {
            _weatherStationDomain = weatherStationDomain;
            _countiesDomain = countiesDomain;
            _districtDomain = districtDomain;
            _geocodingDomain = geocodingDomain;
            _locationDomain = locationDomain;
        }

        public RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit) => _weatherStationDomain.FindWeatherStation(query, limit);

        public RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams) =>
            _weatherStationDomain.FindNearByStation(findStationParams);

        public void AddWeatherStationToDatabase(GeocodingAddressModelQueryParams parameters)
        {
            GeocodingAddressResponseModel locationquerycoords = _geocodingDomain.GetCoordsFromAddress(parameters).Data.FirstOrDefault();
            District district = _districtDomain.GetDistrictByDistrictName(parameters.District);
            County county = _countiesDomain.GetCountyByCountyName(parameters.County);

            Location locationquery = new Location(locationquerycoords.Latitude, locationquerycoords.Longitude, "0", locationquerycoords.Name, district.Id_District, county.CountyId);
            _locationDomain.InsertLocationData(locationquery, district.Id_District, county.CountyId);


            WeatherStationWithParamsModel nearbyWeatherStation =
                _weatherStationDomain.FindNearByStationFromLatLong(new FindNearbyStationModel(float.Parse(locationquerycoords.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    float.Parse(locationquerycoords.Longitude, CultureInfo.InvariantCulture.NumberFormat), 8, null));

            Location locationStation = new Location(nearbyWeatherStation.Latitude.ToString(), nearbyWeatherStation.Longitude.ToString(), nearbyWeatherStation.Elevation.ToString(), nearbyWeatherStation.Name.En, district.Id_District, county.CountyId);
            _locationDomain.InsertLocationData(locationStation, district.Id_District, county.CountyId);


            _weatherStationDomain.AddWeatherStationToDatabase(new Station(null, nearbyWeatherStation.Name.En, nearbyWeatherStation.Country, nearbyWeatherStation.Region, nearbyWeatherStation.National, nearbyWeatherStation.Wmo, nearbyWeatherStation.Icao, nearbyWeatherStation.Iata, nearbyWeatherStation.Elevation, nearbyWeatherStation.Timezone, nearbyWeatherStation.Active, _locationDomain.RetrieveLocation(nearbyWeatherStation.Latitude.ToString(), nearbyWeatherStation.Longitude.ToString()).Id_Location));
        }



    }
}