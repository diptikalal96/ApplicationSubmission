using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg;
            List<Business> lstbusidetail = new List<Business>();
            Business busidetail = new Business();

            try
            {
                lstbusidetail = busidetail.Get_All_Business(int.Parse(aid));

                if (lstbusidetail.Count <= 0)
                {
                    msg = "No business details found.";
                    busidetail.LogMessage("Get Business Data ----" + " " + msg.ToString());
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    var content = JsonConvert.SerializeObject(lstbusidetail);
                    busidetail.LogMessage("Get Business Data ----" + " " + content.ToString());

                    return new JsonResult(lstbusidetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                busidetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // GET: applicationsubmission/Business/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg;
            Business busidetail = new Business();

            try
            {
                busidetail = busidetail.Get_Business_by_id(id);

                if (busidetail.Business_ID == 0)
                {
                    msg = "No business details found.";
                    busidetail.LogMessage("Get Business Data ----" + " " + id.ToString());

                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    var content = JsonConvert.SerializeObject(busidetail);
                    busidetail.LogMessage("Get Business Data ----" + " " + content.ToString());

                    return new JsonResult(busidetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                busidetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // POST: applicationsubmission/Business
        [HttpPost]
        public JsonResult Post([FromBody] Business value)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg = "";
            ResponseBody rb = new ResponseBody();
            Business busidetail = new Business();

            try
            {

                int result = busidetail.Add_BusinessInfo(value);

                if (result > 0)
                {
                    rb.ID = result;
                    rb.msg = "Business details saved successfully.";
                    var content = JsonConvert.SerializeObject(value);
                    busidetail.LogMessage(rb.msg + " " + content.ToString());
                }
                else
                {
                    rb.ID = result;
                    rb.msg = "Business details not saved.";
                    var content = JsonConvert.SerializeObject(value);
                    busidetail.LogMessage(rb.msg + " " + content.ToString());
                }


                return new JsonResult(rb, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                busidetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // PUT: applicationsubmission/Business/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Business value)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg = "";
            Business busidetail = new Business();

            try
            {

                bool result = busidetail.Update_BusinessInfo(value, id);

                if (result == true)
                {
                    msg = "Business details updated successfully.";
                    var content = JsonConvert.SerializeObject(value);
                    busidetail.LogMessage(msg + " " + content.ToString());
                }
                else
                {
                    msg = "Business details not updated.";
                    var content = JsonConvert.SerializeObject(value);
                    busidetail.LogMessage(msg + " " + content.ToString());
                }

                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                busidetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // DELETE: applicationsubmission/ApiWithActions/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg = "";
            Business busidetail = new Business();

            try
            {

                bool result = busidetail.Delete_ApplicantInfo(id);

                if (result == true)
                {
                    msg = "Business details deleted successfully.";
                    busidetail.LogMessage(msg + " " + id.ToString());
                }
                else
                {
                    msg = "Business details not deleted.";
                    busidetail.LogMessage(msg + " " + id.ToString());
                }


                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                busidetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // Options: applicationsubmission/ApiWithActions/5
        [HttpDelete("{id}")]
        public JsonResult Options(int id)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage();

                this.Response.ContentType = "application/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return new JsonResult(res, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }

        }
    }
}
