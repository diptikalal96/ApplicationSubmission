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
    public class BusinessController : ControllerBase
    {
        // GET: api/Business
        [HttpGet]
        public List<Business> Get(string aid)
        {
            List<Business> lstbusidetail = new List<Business>();
            Business busidetail = new Business();
            lstbusidetail = busidetail.Get_All_Business(int.Parse(aid));

            return lstbusidetail;
        }

        // GET: api/Business/5
        [HttpGet("{id}")]
        public Business Get(int id)
        {
            Business busidetail = new Business();
            busidetail = busidetail.Get_Business_by_id(id);

            return busidetail;
        }

        // POST: api/Business
        [HttpPost]
        public string Post([FromBody] Business value)
        {
            string msg = "";
            Business busidetail = new Business();
            bool result = busidetail.Add_BusinessInfo(value);

            if (result == true)
            {
                msg = "Business data saved successfully.";
            }
            else
            {
                msg = "Business data not saved.";
            }

            return msg;
        }

        // PUT: api/Business/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Business value)
        {
            string msg = "";
            Business busidetail = new Business();
            bool result = busidetail.Update_BusinessInfo(value, id);

            if (result == true)
            {
                msg = "Business data updated successfully for Business " + id.ToString();
            }
            else
            {
                msg = "Business data not updated.";
            }
            return msg;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = "";
            Business busidetail = new Business();
            bool result = busidetail.Delete_ApplicantInfo(id);

            if (result == true)
            {
                msg = "Business data deleted successfully for Business " + id.ToString();
            }
            else
            {
                msg = "Business data not deleted.";
            }
            return msg;
        }
    }
}
