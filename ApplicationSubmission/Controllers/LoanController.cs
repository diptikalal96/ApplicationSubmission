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
    public class LoanController : ControllerBase
    {
        // GET: applicationsubmission/Loan
        [HttpGet]
        public JsonResult Get(string bid)
        {
            try
            {
                string msg;
                List<Loan> lstloandetail = new List<Loan>();
                Loan loandetail = new Loan();
                lstloandetail = loandetail.Get_All_Loan(int.Parse(bid));

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (lstloandetail.Count <= 0)
                {
                    msg = "No loan application found.";
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    return new JsonResult(lstloandetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // GET: applicationsubmission/Loan/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                string msg;
                Loan loandetail = new Loan();
                loandetail = loandetail.Get_Loan_by_id(id);

                this.Response.ContentType = "text/json";
                this.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (loandetail.LoanApplication_ID == 0)
                {
                    msg = "No loan application found.";
                    return new JsonResult(msg, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
                else
                {
                    return new JsonResult(loandetail, new JsonSerializerSettings { Formatting = Formatting.Indented });
                }
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                return new JsonResult(ex.Message);
            }
            
        }

        // POST: applicationsubmission/Loan
        [HttpPost]
        public JsonResult Post([FromBody] Loan value)
        {
            try
            {
                string msg = "";
                Loan loandetail = new Loan();
                bool result = loandetail.Add_LoanInfo(value);

                if (result == true)
                {
                    msg = "Loan application saved successfully.";
                }
                else
                {
                    msg = "Loan application not saved.";
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
        public JsonResult Put(int id, [FromBody] Loan value)
        {
            try
            {
                string msg = "";
                Loan loandetail = new Loan();
                bool result = loandetail.Update_LoanInfo(value, id);

                if (result == true)
                {
                    msg = "Loan application updated successfully.";
                }
                else
                {
                    msg = "Loan application not updated.";
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
                Loan loandetail = new Loan();
                bool result = loandetail.Delete_LoanInfo(id);

                if (result == true)
                {
                    msg = "Loan application deleted successfully.";
                }
                else
                {
                    msg = "Loan application not deleted.";
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
