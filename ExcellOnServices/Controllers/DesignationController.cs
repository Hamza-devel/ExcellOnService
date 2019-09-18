using ExcellOnServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnServices.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Designation
        public ActionResult DesignationView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DesignationView(DesignationMod a)
        {


            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("Insert into Tbl_Designation(Designation,Date) Values('" + a.Designation + "','" + a.Date + "')", Cn);

            Com.ExecuteNonQuery();






            return View();
        }
        public ActionResult Show()

        {

            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            List<DesignationMod> L = new List<DesignationMod>();

            SqlCommand C = new SqlCommand("select * from Tbl_Designation", Cn);
            SqlDataReader Sdr = C.ExecuteReader();

            while (Sdr.Read())
            {

                DesignationMod M = new DesignationMod();
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Designation= Sdr["Designation"].ToString();

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


            SqlCommand Com = new SqlCommand("select * from Tbl_Designation where id=" + id, Cn);
            DesignationMod M = new DesignationMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {


                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Designation = Sdr["Designation"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);


            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Edit(DesignationMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("Update Tbl_Designation set Designation='" + a.Designation + "',Date='" + a.Date + "'  where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Edit Successfully!') </script>");



            return View();


        }


        public ActionResult Delete(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Designation where id=" + id, Cn);
            DesignationMod M = new DesignationMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Designation = Sdr["Designation"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);




            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Delete(DesignationMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("delete from Tbl_Designation where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Delete Successfully!') </script>");



            return View();


        }

        public ActionResult Details(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=HAMZA-LAPTOP;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Designation where id=" + id, Cn);
            DesignationMod M = new DesignationMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Designation = Sdr["Designation"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);



            }

            return View(M);



        }












    }
}