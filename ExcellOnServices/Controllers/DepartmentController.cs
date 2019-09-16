using ExcellOnServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnServices.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult DepartmentView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmentView(DepartmentMod a)
        {


            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("Insert into Tbl_Department(Department,Date) Values('" + a.Department + "','" + a.Date + "')", Cn);

            Com.ExecuteNonQuery();


        



            return View();
        }
        public ActionResult Show()

        { 

            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            List<DepartmentMod> L = new List<DepartmentMod>();

            SqlCommand C = new SqlCommand("select * from Tbl_Department", Cn);
            SqlDataReader Sdr = C.ExecuteReader();

            while (Sdr.Read())
            {

                DepartmentMod M = new DepartmentMod();
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Department = Sdr["Department"].ToString();
               
                M.Date = Convert.ToDateTime(Sdr["Date"]); 



                L.Add(M);

            }


            ViewData["Show"] = L;






            return View();
        }

        public ActionResult Edit(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("select * from Tbl_Department where id=" + id, Cn);
            DepartmentMod M = new DepartmentMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Department = Sdr["Department"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);


            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Edit(DepartmentMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("Update Tbl_Department set Department='" + a.Department + "',Date='" + a.Date + "'  where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Edit Successfully!') </script>");



            return View();


        }


        public ActionResult Delete(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Department where id=" + id, Cn);
            DepartmentMod M = new DepartmentMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {
                
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Department = Sdr["Department"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);




            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Delete(DepartmentMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("delete from Tbl_Department where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Delete Successfully!') </script>");



            return View();


        }

        public ActionResult Details(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Department where id=" + id, Cn);
            DepartmentMod M = new DepartmentMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {
               
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Department = Sdr["Department"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);



            }

            return View(M);



        }

       



        





    }
}