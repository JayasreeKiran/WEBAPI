using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.Models;
namespace WEBAPI.Business
{
    public interface IRequestProcessor
    {
        Candidate GetCandidateDetails();
        string GetCityByIPAddress(string ipAddress);

        List<Listing> GetDatandFilterbyNoofPassengers(int passengerNo);
    }
}
