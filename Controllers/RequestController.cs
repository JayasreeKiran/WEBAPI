using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Business;
using WEBAPI.Models;


namespace WEBAPI.Controllers
{
    
    public class RequestController : ApiController
    {
        private IRequestProcessor _requestProcessor;

        public RequestController(IRequestProcessor requestProcessor)
        {
            _requestProcessor = requestProcessor;         
        }

        [Route("api/Request/candidate")]
        [HttpGet]
        public Candidate GetCandidate()
        {
            return _requestProcessor.GetCandidateDetails();
        }

        [Route("api/Request/Location")]
        [HttpGet]
        public string GetCityByIPAddress([FromUri]string ipAddress)
        {
            return _requestProcessor.GetCityByIPAddress(ipAddress);
        }
        [Route("api/Request/Listings")]
        [HttpGet]
        public List<Listing> GetDatandFilterbyNoofPassengers([FromUri] int passengerNo)
        {
            return _requestProcessor.GetDatandFilterbyNoofPassengers(passengerNo);
        }
    }
}
