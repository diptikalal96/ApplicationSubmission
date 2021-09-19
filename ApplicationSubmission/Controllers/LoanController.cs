using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationSubmission.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSubmission.Controllers
{
    [Route("applicationsubmission/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        // GET: api/Loan
        [HttpGet]
        public List<Loan> Get(string bid)
        {
            List<Loan> lstloandetail = new List<Loan>();
            Loan loandetail = new Loan();
            lstloandetail = loandetail.Get_All_Loan(int.Parse(bid));

            return lstloandetail;
        }

        // GET: api/Loan/5
        [HttpGet("{id}")]
        public Loan Get(int id)
        {
            Loan loandetail = new Loan();
            loandetail = loandetail.Get_Loan_by_id(id);

            return loandetail;
        }

        // POST: api/Loan
        [HttpPost]
        public string Post([FromBody] Loan value)
        {
            string msg = "";
            Loan loandetail = new Loan();
            bool result = loandetail.Add_LoanInfo(value);

            if (result == true)
            {
                msg = "Loan data saved successfully.";
            }
            else
            {
                msg = "Loan data not saved.";
            }

            return msg;
        }

        // PUT: api/Business/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Loan value)
        {
            string msg = "";
            Loan loandetail = new Loan();
            bool result = loandetail.Update_LoanInfo(value, id);

            if (result == true)
            {
                msg = "Loan data updated successfully for Loan " + id.ToString();
            }
            else
            {
                msg = "Loan data not updated.";
            }

            return msg;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = "";
            Loan loandetail = new Loan();
            bool result = loandetail.Delete_LoanInfo(id);

            if (result == true)
            {
                msg = "Loan data deleted successfully for Loan " + id.ToString();
            }
            else
            {
                msg = "Loan data not deleted.";
            }

            return msg;
        }
    }
}
