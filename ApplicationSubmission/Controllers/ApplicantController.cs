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
        // GET: applicationsubmission/Applicant/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                string msg;
                Applicant appdetail = new Applicant();
                appdetail = appdetail.Get_Applicant(id);

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (appdetail.Applicant_ID == 0)
                {
                    msg = "No applicant details found.";
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    return new JsonResult(appdetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // POST: applicationsubmission/Applicant
        [HttpPost]
        public JsonResult Post([FromBody] Applicant value)
        {
            try
            {
                string msg = "";
                Applicant appdetail = new Applicant();
                bool result = appdetail.Add_ApplicantInfo(value);

                if (result == true)
                {
                    msg = "Applicant details saved successfully.";
                }
                else
                {
                    msg = "Applicant details not saved.";
                }

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // PUT: applicationsubmission/Applicant/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Applicant value)
        {
            try
            {
                string msg = "";
                Applicant appdetail = new Applicant();
                bool result = appdetail.Update_ApplicantInfo(value, id);

                if (result == true)
                {
                    msg = "Applicant details updated successfully.";
                }
                else
                {
                    msg = "Applicant details not updated.";
                }

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });

            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // DELETE: applicationsubmission/ApiWithActions/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                string msg = "";
                Applicant appdetail = new Applicant();
                bool result = appdetail.Delete_ApplicantInfo(id);

                if (result == true)
                {
                    msg = "Applicant details deleted successfully.";
                }
                else
                {
                    msg = "Applicant details not deleted.";
                }

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }
    }
}
