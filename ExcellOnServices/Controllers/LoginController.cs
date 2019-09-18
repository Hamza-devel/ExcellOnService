using ExcellOnServices.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnServices.Controllers
{
    public class LoginController : Controller

    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Login

        [HttpGet]
        public ActionResult LoginView()
        {


            Fill_Role();
            return View();
        }
        void connectionstring()
        {
            con.ConnectionString = "data source=HAMZA-LAPTOP;database=ExcellOnServices;integrated security=SSPI";


        }
        [HttpPost]
        public ActionResult Dashboard(LoginMod a)
        {

            connectionstring();

            con.Open();

            com.Connection = con;
            com.CommandText = "select * from Tbl_SignUp where Email='" + a.Email + "' and Password='" + a.Password + "' and Role='"+ a.Role +"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                con.Close();
                return View();
                
            }
            else
            {
                con.Close();

                Fill_Role();
                Response.Write("<script>alert('Email or Password is invaild!') </script>");
                return View("LoginView");
                

            }


           






        }


        public ActionResult SessionOut()
        {

            if (Session["U"] == null)
            {
                return RedirectToAction("LoginView");

            }
            else
            {
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Remove("U");
            return RedirectToAction("LoginView");
        }



        public void Fill_Role()
        {
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
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
