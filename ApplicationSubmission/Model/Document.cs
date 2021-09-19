using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationSubmission.Model
{
    public class Document
    {
        public int Document_ID { get; set; }
        public int Loan_ID { get; set; }
        public string DocumentName { get; set; }
        public string Comment { get; set; }
        public string DocumentLink { get; set; }
        public DateTime DocumentUploadDate { get; set; }

    }
}
