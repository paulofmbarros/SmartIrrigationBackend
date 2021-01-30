using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Abstractions.Relational.Reads
{
    public interface IReadNodeInformation
    {
        Node RetrieveNodeByStreet(string street);
        Node RetrieveNodeByLatLong(string latitude, string longitude);
        IEnumerable<Node> GetAllActiveNodes();
    }
}
