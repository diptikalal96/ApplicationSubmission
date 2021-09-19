using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using ApplicationSubmission.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApplicationSubmission.Controllers
{
    [Route("applicationsubmission/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        // GET: api/Applicant/5
        [HttpGet("{id}")]
        public Applicant Get(int id)
        {
            Applicant appdetail = new Applicant();
            appdetail = appdetail.Get_Applicant(id);

            //string res = Newtonsoft.Json.JsonConvert.SerializeObject(appdetail);
            //var response = new APIGatewayProxyResponse
            //{
            //    StatusCode = (int)HttpStatusCode.OK,
            //    Body = res,
            //    Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            //};
            //response.Headers.Add("Access-Control-Allow-Origin", "*");

            return appdetail;
        }

        // POST: api/Applicant
        [HttpPost]
        public string Post([FromBody] Applicant value)
        {
            string msg = "";
            Applicant appdetail = new Applicant();
            bool result = appdetail.Add_ApplicantInfo(value);

            if (result == true)
            {
                msg = "Applicant data saved successfully.";
            }
            else
            {
                msg = "Applicant data not saved.";
            }

            return msg;
        }

        // PUT: api/Applicant/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Applicant value)
        {
            string msg = "";
            Applicant appdetail = new Applicant();
            bool result = appdetail.Update_ApplicantInfo(value, id);

            if (result == true)
            {
                msg = "Applicant data updated successfully for Applicant " + id.ToString();
            }
            else
            {
                msg = "Applicant data not updated.";
            }

            return msg;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = "";
            Applicant appdetail = new Applicant();
            bool result = appdetail.Delete_ApplicantInfo(id);

            if (result == true)
            {
                msg = "Applicant data deleted successfully for Applicant " + id.ToString();
            }
            else
            {
                msg = "Applicant data not deleted.";
            }

            return msg;
        }
    }
}
