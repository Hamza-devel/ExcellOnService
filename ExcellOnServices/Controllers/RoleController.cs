using ExcellOnServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnServices.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult RoleView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleView(RoleMod a)
        {


            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("Insert into Tbl_Role(Role,Date) Values('" + a.Role + "','" + a.Date + "')", Cn);

            Com.ExecuteNonQuery();






            return View();
        }


        public ActionResult Show()

        {

            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            List<RoleMod> L = new List<RoleMod>();

            SqlCommand C = new SqlCommand("select * from Tbl_Role", Cn);
            SqlDataReader Sdr = C.ExecuteReader();

            while (Sdr.Read())
            {

                RoleMod M = new RoleMod();
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Role = Sdr["Role"].ToString();

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


            SqlCommand Com = new SqlCommand("select * from Tbl_Role where id=" + id, Cn);
            RoleMod M = new RoleMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {


                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Role = Sdr["Role"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);


            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Edit(RoleMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("Update Tbl_Role set Role='" + a.Role + "',Date='" + a.Date + "'  where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Edit Successfully!') </script>");



            return View();


        }


        public ActionResult Delete(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Role where id=" + id, Cn);
            RoleMod M = new RoleMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Role = Sdr["Role"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);




            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Delete(RoleMod a, int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();


            SqlCommand Com = new SqlCommand("delete from Tbl_Role where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Delete Successfully!') </script>");



            return View();


        }

        public ActionResult Details(int id)

        {
            SqlConnection Cn = new SqlConnection("Server=.;User=sa;Password=aptech;initial Catalog=ExcellOnServices");
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Role where id=" + id, Cn);
            RoleMod M = new RoleMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Role = Sdr["Role"].ToString();

                M.Date = Convert.ToDateTime(Sdr["Date"]);



            }

            return View(M);



        }






    }
}