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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeView()
        {

            Fill_Department();
            Fill_Designation();
            Fill_Services();



            return View();
        }


        [HttpPost]
        public ActionResult EmployeeView(EmployeeMod a)
        {


SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();

            SqlCommand Com = new SqlCommand("Insert into Tbl_Employee(Employee_Id,First_Name,Last_Name,Cell_No,DOB,Address,Department,Designation,Services,DOJ) Values('" + a.Employee_Id + "','" + a.First_Name + "','" + a.Last_Name + "','" + a.Cell_No + "','" + a.DOB + "','" + a.Addrerss + "','" + a.Department + "','" + a.Designation + "','" + a.Services + "','" + a.DOJ + "')", Cn);

            Com.ExecuteNonQuery();

            Fill_Department();
            Fill_Designation();
            Fill_Services();






            return View();

        }
        public ActionResult Show()

        {

SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();


            List<EmployeeMod> L = new List<EmployeeMod>();

            SqlCommand C = new SqlCommand("select * from Tbl_Employee", Cn);
            SqlDataReader Sdr = C.ExecuteReader();

            while (Sdr.Read())
            {

                EmployeeMod M = new EmployeeMod();
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Employee_Id = Sdr["Employee_Id"].ToString();
                M.First_Name = Sdr["First_Name"].ToString();
                M.Last_Name = Sdr["Last_Name"].ToString();
                M.Cell_No = Sdr["Cell_No"].ToString();
                M.DOB = Convert.ToDateTime(Sdr["DOB"]);
                M.Addrerss = Sdr["Address"].ToString();
                M.Department = Sdr["Department"].ToString();
                M.Designation = Sdr["Designation"].ToString();
                M.Services = Sdr["Services"].ToString();
                M.DOJ = Convert.ToDateTime(Sdr["DOJ"]);



                L.Add(M);

            }


            ViewData["Show"] = L;






            return View();
        }

        public ActionResult Edit(int id)

        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();


            SqlCommand Com = new SqlCommand("select * from Tbl_Employee where id=" + id, Cn);
            EmployeeMod M = new EmployeeMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {


                
                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Employee_Id = Sdr["Employee_Id"].ToString();
                M.First_Name = Sdr["First_Name"].ToString();
                M.Last_Name = Sdr["Last_Name"].ToString();
                M.Cell_No = Sdr["Cell_No"].ToString();
                M.DOB = Convert.ToDateTime(Sdr["DOB"]);
                M.Addrerss = Sdr["Address"].ToString();
                M.Department = Sdr["Department"].ToString();
                M.Designation = Sdr["Designation"].ToString();
                M.Services = Sdr["Services"].ToString();
                M.DOJ = Convert.ToDateTime(Sdr["Date"]);


            }


            Fill_Department();
            Fill_Designation();
            Fill_Services();


            return View(M);


        }

        [HttpPost]
        public ActionResult Edit(EmployeeMod a, int id)

        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();


            SqlCommand Com = new SqlCommand("Update Tbl_Employee set Employee_Id='" + a.Employee_Id+ "',First_Name='" + a.First_Name + "',Last_Name='" + a.Last_Name + "',Cell_No='" + a.Cell_No + "',DOB='" + a.DOB + "',Address='" + a.Addrerss + "',Department='" + a.Department + "',Designation='" + a.Designation + "' Services='" + a.Services + "',DOJ='" + a.DOJ + "'  where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Edit Successfully!') </script>");



            return View();


        }


        public ActionResult Delete(int id)

        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Employee where id=" + id, Cn);
            EmployeeMod M = new EmployeeMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                   M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Employee_Id = Sdr["Employee_Id"].ToString();
                M.First_Name = Sdr["First_Name"].ToString();
                M.Last_Name = Sdr["Last_Name"].ToString();
                M.Cell_No = Sdr["Cell_No"].ToString();
                M.DOB = Convert.ToDateTime(Sdr["DOB"]);
                M.Addrerss = Sdr["Address"].ToString();
                M.Department = Sdr["Department"].ToString();
                M.Designation = Sdr["Designation"].ToString();
                M.Services = Sdr["Services"].ToString();
                M.DOJ = Convert.ToDateTime(Sdr["Date"]);




            }

            return View(M);


        }

        [HttpPost]
        public ActionResult Delete(EmployeeMod a, int id)

        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();


            SqlCommand Com = new SqlCommand("delete from Tbl_Employee where id=" + id, Cn);

            Com.ExecuteNonQuery();


            Response.Write("<script>alert('Your Details Delete Successfully!') </script>");



            return View();


        }

        public ActionResult Details(int id)

        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();

            SqlCommand Com = new SqlCommand("select * from Tbl_Employee where id=" + id, Cn);
            EmployeeMod M = new EmployeeMod();
            SqlDataReader Sdr = Com.ExecuteReader();
            while (Sdr.Read())
            {

                M.Id = Convert.ToInt32(Sdr["Id"]);
                M.Employee_Id = Sdr["Employee_Id"].ToString();
                M.First_Name = Sdr["First_Name"].ToString();
                M.Last_Name = Sdr["Last_Name"].ToString();
                M.Cell_No = Sdr["Cell_No"].ToString();
                M.DOB = Convert.ToDateTime(Sdr["DOB"]);
                M.Addrerss = Sdr["Address"].ToString();
                M.Department = Sdr["Department"].ToString();
                M.Designation = Sdr["Designation"].ToString();
                M.Services = Sdr["Services"].ToString();
                M.DOJ = Convert.ToDateTime(Sdr["Date"]);


            }

            return View(M);



        }


    





public void Fill_Department()
        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();
            SqlCommand Com = new SqlCommand("select * from Tbl_Department", Cn);
            SqlDataReader Sdr = Com.ExecuteReader();
            List<SelectListItem> L = new List<SelectListItem>();
            while (Sdr.Read())
            {

                L.Add(new SelectListItem { Text = Sdr["Department"].ToString(), Value = Sdr["Department"].ToString() });



            }

            TempData["abc"] = L;



        }

        public void Fill_Designation()
        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();
            SqlCommand Com = new SqlCommand("select * from Tbl_Designation", Cn);
            SqlDataReader Sdr = Com.ExecuteReader();
            List<SelectListItem> L = new List<SelectListItem>();
            while (Sdr.Read())
            {

                L.Add(new SelectListItem { Text = Sdr["Designation"].ToString(), Value = Sdr["Designation"].ToString() });



            }

            TempData["xyz"] = L;



        }




        public void Fill_Services()
        {
SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            Cn.Open();
            SqlCommand Com = new SqlCommand("select * from Tbl_Services", Cn);
            SqlDataReader Sdr = Com.ExecuteReader();
            List<SelectListItem> L = new List<SelectListItem>();
            while (Sdr.Read())
            {

                L.Add(new SelectListItem { Text = Sdr["Services"].ToString(), Value = Sdr["Services"].ToString() });



            }

            TempData["pqr"] = L;



        }






    }
}
    
