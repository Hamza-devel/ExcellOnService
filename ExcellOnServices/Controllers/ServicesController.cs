using ExcellOnServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnServices.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult ServicesView()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ServicesView(ServicesMod a)
        {


            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("Insert into Tbl_Services(Services,Date) Values('" + a.Services+ "','" + a.Date + "')", Cn);

            Com.ExecuteNonQuery();






            return View();
        }
        public ActionResult Show()

        {

            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            List<ServicesMod> L = new List<ServicesMod>();

            SqlCommand C = new SqlCommand("select * from Tbl_Services", Cn);
            SqlDataReader Sdr = C.ExecuteReader();

            while (Sdr.Read())
            {

                ServicesMod M = new ServicesMod();
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Services = Sdr["Services"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);



                L.Add(M);

            }


            ViewData["Show"] = L;






            return View();
        }

        public ActionResult Edit(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("select * from Tbl_Services where id=" + id, Cn);
            ServicesMod M = new ServicesMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {


                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Services = Sdr["Services"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);


            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Edit(ServicesMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("Update Tbl_Services set Services='" + a.Services + "',Date='" + a.Date + "'  where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Edit Successfully!') </script>");



            return View();


        }


        public ActionResult Delete(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Services where id=" + id, Cn);
            ServicesMod M = new ServicesMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Services = Sdr["Services"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);




            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Delete(ServicesMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("delete from Tbl_Services where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Delete Successfully!') </script>");



            return View();


        }

        public ActionResult Details(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Services where id=" + id, Cn);
            ServicesMod M = new ServicesMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Services = Sdr["Services"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);



            }

            return View(M);



        }


    }
}