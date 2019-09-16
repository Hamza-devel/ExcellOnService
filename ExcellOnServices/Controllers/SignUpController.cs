using ExcellOnServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnServices.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult SignUpView()
        {

            Fill_Role();
            return View();
        }
        [HttpPost]
        public ActionResult SignUpView(SignUpMod a)
        {


            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("Insert into Tbl_SignUp(Username,Email,Password,Role,Date) Values('" + a.Username + "','" + a.Email + "','" + a.Password + "','" + a.Role + "','" + a.Date + "')", Cn);

            Com.ExecuteNonQuery();






            return View();
        }





        public void Fill_Role()
        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();
            SqlCommand Com = new SqlCommand("select * from Tbl_Role", Cn);
            SqlDataReader Sdr = Com.ExecuteReader();
            List<SelectListItem> L = new List<SelectListItem>();
            while (Sdr.Read())
            {

                L.Add(new SelectListItem { Text = Sdr["Role"].ToString(), Value = Sdr["Role"].ToString() });



            }

            TempData["abc"] = L;



        }
    }
}