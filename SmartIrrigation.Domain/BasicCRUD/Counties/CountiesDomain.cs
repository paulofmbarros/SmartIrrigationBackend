using SmartIrrigation.Abstractions.Relational.Reads;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Domain.BasicCRUD.Counties
{
    public class CountiesDomain:ICountiesDomain
    {
        private readonly IReadCountiesInformation _readCountiesInformation;

        public CountiesDomain(IReadCountiesInformation readCountiesInformation)
        {
            _readCountiesInformation = readCountiesInformation;
        }

        public County GetCountyByCountyName(string countyName) => 
            _readCountiesInformation.RetrieveCountyByCountyName(countyName);
        
    }
}
