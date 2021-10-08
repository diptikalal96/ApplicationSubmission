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
    public class LoanController : ControllerBase
    {
        // GET: applicationsubmission/Loan
        [HttpGet]
        public JsonResult Get(string bid)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg;
            List<Loan> lstloandetail = new List<Loan>();
            Loan loandetail = new Loan();

            try
            {

                lstloandetail = loandetail.Get_All_Loan(int.Parse(bid));

                if (lstloandetail.Count <= 0)
                {
                    msg = "No loan application found.";
                    loandetail.LogMessage("Get Loan Data ----" + " " + msg.ToString());
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    var content = JsonConvert.SerializeObject(lstloandetail);
                    loandetail.LogMessage("Get Loan Data ----" + " " + content.ToString());

                    return new JsonResult(lstloandetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                loandetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // GET: applicationsubmission/Loan/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg;
            Loan loandetail = new Loan();

            try
            {

                loandetail = loandetail.Get_Loan_by_id(id);

                if (loandetail.LoanApplication_ID == 0)
                {
                    msg = "No loan application found.";
                    loandetail.LogMessage("Get Loan Data ----" + " " + msg.ToString());
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    var content = JsonConvert.SerializeObject(loandetail);
                    loandetail.LogMessage("Get Loan Data ----" + " " + content.ToString());

                    return new JsonResult(loandetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                loandetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // POST: applicationsubmission/Loan
        [HttpPost]
        public JsonResult Post([FromBody] Loan value)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg = "";
            ResponseBody rb = new ResponseBody();
            Loan loandetail = new Loan();

            try
            {

                int result = loandetail.Add_LoanInfo(value);

                if (result > 0)
                {
                    rb.ID = result;
                    rb.msg = "Loan application saved successfully.";
                    var content = JsonConvert.SerializeObject(value);
                    loandetail.LogMessage(rb.msg + " " + content.ToString());
                }
                else
                {
                    rb.ID = result;
                    rb.msg = "Loan application not saved.";
                    var content = JsonConvert.SerializeObject(value);
                    loandetail.LogMessage(rb.msg + " " + content.ToString());
                }

                return new JsonResult(rb, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                loandetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
                return new JsonResult(ex.Message);
            }

        }

        // PUT: applicationsubmission/Business/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Loan value)
        {
            this.Response.ContentType = "application/json";
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            string msg = ""; bool result = false; bool IsClosed = false;
            Loan loandetail = new Loan();

            try
            {
                //Check the if the loan application has closed.
                IsClosed = loandetail.CheckIsClosed(id);

                if (IsClosed == false)
                {
                    result = loandetail.Update_LoanInfo(value, id);
                }

                if (result == true)
                {
                    msg = "Loan application updated successfully.";
                    var content = JsonConvert.SerializeObject(value);
                    loandetail.LogMessage(msg + " " + content.ToString());
                }
                else if (IsClosed == true)
                {
                    msg = "This loan application is closed, You can not process this.";
                    var content = JsonConvert.SerializeObject(value);
                    loandetail.LogMessage(msg + " " + content.ToString());
                }
                else
                {
                    msg = "Loan application not updated.";
                    var content = JsonConvert.SerializeObject(value);
                    loandetail.LogMessage(msg + " " + content.ToString());
                }

                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                loandetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
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
            Loan loandetail = new Loan();

            try
            {

                bool result = loandetail.Delete_LoanInfo(id);

                if (result == true)
                {
                    msg = "Loan application deleted successfully.";
                    loandetail.LogMessage(msg + " " + id.ToString());
                }
                else
                {
                    msg = "Loan application not deleted.";
                    loandetail.LogMessage(msg + " " + id.ToString());
                }

                return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                loandetail.LogMessage(ex.Message.ToString() + " " + ex.Message.ToString());
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
