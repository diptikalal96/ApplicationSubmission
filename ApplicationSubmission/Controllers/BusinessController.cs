using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationSubmission.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApplicationSubmission.Controllers
{
    [Route("applicationsubmission/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        // GET: applicationsubmission/Business
        [HttpGet]
        public JsonResult Get(string aid)
        {
            try
            {
                string msg;
                List<Business> lstbusidetail = new List<Business>();
                Business busidetail = new Business();
                lstbusidetail = busidetail.Get_All_Business(int.Parse(aid));

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (lstbusidetail.Count <= 0)
                {
                    msg = "No business details found.";
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    return new JsonResult(lstbusidetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // GET: applicationsubmission/Business/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                string msg;
                Business busidetail = new Business();
                busidetail = busidetail.Get_Business_by_id(id);

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (busidetail.Business_ID == 0)
                {
                    msg = "No business details found.";
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    return new JsonResult(busidetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // POST: applicationsubmission/Business
        [HttpPost]
        public JsonResult Post([FromBody] Business value)
        {
            try
            {
                string msg = "";
                Business busidetail = new Business();
                bool result = busidetail.Add_BusinessInfo(value);

                if (result == true)
                {
                    msg = "Business details saved successfully.";
                }
                else
                {
                    msg = "Business details not saved.";
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

        // PUT: applicationsubmission/Business/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Business value)
        {
            try
            {
                string msg = "";
                Business busidetail = new Business();
                bool result = busidetail.Update_BusinessInfo(value, id);

                if (result == true)
                {
                    msg = "Business details updated successfully.";
                }
                else
                {
                    msg = "Business details not updated.";
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
                Business busidetail = new Business();
                bool result = busidetail.Delete_ApplicantInfo(id);

                if (result == true)
                {
                    msg = "Business details deleted successfully.";
                }
                else
                {
                    msg = "Business details not deleted.";
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
