using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace WEBAPI.Business
{
    public class RequestProcessor : IRequestProcessor
    {
        public Candidate GetCandidateDetails()
        {
            Candidate objReturn = new Candidate();
            objReturn.Name = "test";
            objReturn.Phone = "test";

            return objReturn;
        }

        public string GetCityByIPAddress(string ipAddress)
        {
            string url = Common.IPStackURL;
            url = url.Replace("{IpAddress}", ipAddress);
            var request = System.Net.WebRequest.Create(url);
            using (WebResponse wrs = request.GetResponse())
            {
                using (Stream stream = wrs.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        var obj = JObject.Parse(json);
                        string City = (string)obj["city"];

                        return (City);
                    }
                }
            }


        }
        public List<Listing> GetDatandFilterbyNoofPassengers(int passengerNo)
        {
            string url = Common.JayrideDataUrl;
            List<Listing> lstData = new List<Listing>();

            var request = System.Net.WebRequest.Create(url);
            using (WebResponse wrs = request.GetResponse())
            {
                using (Stream stream = wrs.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        var obj = JObject.Parse(json);                        
                        
                        foreach (var innerObj in obj["listings"])
                        {
                            Listing objdata = new Listing();
                            objdata.Name = (string)innerObj["name"];
                            objdata.PricePerPassenger = Convert.ToDecimal((string)innerObj["pricePerPassenger"]);
                            objdata.vehicleType.Name = (string)innerObj["vehicleType"]["name"];
                            objdata.vehicleType.MaxPassengers = (int)innerObj["vehicleType"]["maxPassengers"];
                            objdata.TotalPrice = 0;
                            lstData.Add(objdata);
                        } 
                    }
                }
            }

            lstData = lstData.FindAll(x => x.vehicleType.MaxPassengers >= passengerNo);
            if (lstData != null && lstData.Count() > 0)
            {
                lstData.ForEach(x => x.TotalPrice = x.PricePerPassenger * passengerNo);
                return lstData.OrderBy(x => x.TotalPrice).ToList();
            }
            else
            {
                return lstData;
            }

        }
    }
}