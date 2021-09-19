using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationSubmission.Model
{
    public class Applicant
    {
        public int Applicant_ID { get; set; }
        public string Applicant_fname { get; set; }
        public string Applicant_mname { get; set; }
        public string Applicant_lname { get; set; }
        public string Applicant_address { get; set; }
        public string Applicant_pincode { get; set; }
        public string Applicant_dob { get; set; }
        public string Applicant_email { get; set; }
        public string Applicant_mobno { get; set; }
        //public string Applicant_username { get; set; }
        //public string Applicant_password { get; set; }

        public Applicant Get_Applicant(int Applicant_ID)
        {
            DBHelper dbHelper = new DBHelper();
            try
            {
                Applicant appobj = new Applicant();

                dbHelper.Connect(dbHelper.GetConnStr());

                MySqlParameter[] app_para = new MySqlParameter[1];
                app_para[0] = new MySqlParameter("Applicant_ID", Applicant_ID);
                MySqlDataReader AppReader = dbHelper.ExecuteReader("GET_Applicant_Info_By_Id", DBHelper.QueryType.StotedProcedure, app_para);

                while (AppReader.Read())
                {
                    appobj.Applicant_ID = int.Parse(AppReader["Applicant_ID"].ToString());
                    appobj.Applicant_fname = AppReader["Applicant_fname"].ToString();
                    appobj.Applicant_mname = AppReader["Applicant_mname"].ToString();
                    appobj.Applicant_lname = AppReader["Applicant_lname"].ToString();
                    appobj.Applicant_address = AppReader["Applicant_address"].ToString();
                    appobj.Applicant_pincode = AppReader["Applicant_pincode"].ToString();
                    appobj.Applicant_dob = AppReader["Applicant_dob"].ToString();
                    appobj.Applicant_email = AppReader["Applicant_email"].ToString();
                    appobj.Applicant_mobno = AppReader["Applicant_mobno"].ToString();
                    //appobj.Applicant_username = AppReader["Customer_username"].ToString();
                    //appobj.Applicant_password = AppReader["Customer_password"].ToString();
                }

                return appobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbHelper.DisConnect();
                dbHelper = null;
            }
        }

        public bool Add_ApplicantInfo(Applicant AppPara)
        {
            DBHelper dbHelper = new DBHelper();
            bool Result = false;
            try
            {
                dbHelper.Connect(dbHelper.GetConnStr());

                MySqlParameter[] app_para = new MySqlParameter[8];
                app_para[0] = new MySqlParameter("Applicant_fname", AppPara.Applicant_fname);
                app_para[1] = new MySqlParameter("Applicant_mname", AppPara.Applicant_mname);
                app_para[2] = new MySqlParameter("Applicant_lname", AppPara.Applicant_lname);
                app_para[3] = new MySqlParameter("Applicant_address", AppPara.Applicant_address);
                app_para[4] = new MySqlParameter("Applicant_pincode", AppPara.Applicant_pincode);
                app_para[5] = new MySqlParameter("Applicant_dob", AppPara.Applicant_dob);
                app_para[6] = new MySqlParameter("Applicant_email", AppPara.Applicant_email);
                app_para[7] = new MySqlParameter("Applicant_mobno", AppPara.Applicant_mobno);

                int r = dbHelper.Execute("Add_ApplicantInfo", DBHelper.QueryType.StotedProcedure, app_para);

                if (r == 1)
                {
                    Result = true;
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbHelper.DisConnect();
                dbHelper = null;
            }
        }

        public bool Update_ApplicantInfo(Applicant AppPara, int id)
        {
            DBHelper dbHelper = new DBHelper();
            bool Result = false;
            try
            {
                dbHelper.Connect(dbHelper.GetConnStr());

                MySqlParameter[] app_para = new MySqlParameter[9];
                app_para[0] = new MySqlParameter("Applicant_ID", id);
                app_para[1] = new MySqlParameter("Applicant_fname", AppPara.Applicant_fname);
                app_para[2] = new MySqlParameter("Applicant_mname", AppPara.Applicant_mname);
                app_para[3] = new MySqlParameter("Applicant_lname", AppPara.Applicant_lname);
                app_para[4] = new MySqlParameter("Applicant_address", AppPara.Applicant_address);
                app_para[5] = new MySqlParameter("Applicant_pincode", AppPara.Applicant_pincode);
                app_para[6] = new MySqlParameter("Applicant_dob", AppPara.Applicant_dob);
                app_para[7] = new MySqlParameter("Applicant_email", AppPara.Applicant_email);
                app_para[8] = new MySqlParameter("Applicant_mobno", AppPara.Applicant_mobno);

                int r = dbHelper.Execute("Update_ApplicantInfo", DBHelper.QueryType.StotedProcedure, app_para);

                if (r == 1)
                {
                    Result = true;
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbHelper.DisConnect();
                dbHelper = null;
            }
        }

        public bool Delete_ApplicantInfo(int id)
        {
            DBHelper dbHelper = new DBHelper();
            bool Result = false;
            try
            {
                dbHelper.Connect(dbHelper.GetConnStr());

                MySqlParameter[] app_para = new MySqlParameter[1];
                app_para[0] = new MySqlParameter("Applicant_ID", id);

                int r = dbHelper.Execute("Delete_ApplicantInfo", DBHelper.QueryType.StotedProcedure, app_para);

                if (r == 1)
                {
                    Result = true;
                }

                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbHelper.DisConnect();
                dbHelper = null;
            }
        }
    }
}
