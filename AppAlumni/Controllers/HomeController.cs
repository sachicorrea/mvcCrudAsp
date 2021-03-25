using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AppAlumni.Models;
using System.Data.SqlClient;
using System.Data;

namespace AppAlumni.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            List<UsersAlumini> usersAluminiList = new List<UsersAlumini>();
            
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "Select * From AlumniDb";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        UsersAlumini usersalumini = new UsersAlumini();
                        usersalumini.Usr_id = Convert.ToInt32(dataReader["Usr_id"]);
                        usersalumini.Usr_doc = Convert.ToString(dataReader["Usr_doc"]);
                        usersalumini.Usr_kind_doc = Convert.ToString(dataReader["Usr_kind_doc"]);
                        usersalumini.Usr_phonenum = Convert.ToString(dataReader["Usr_phonenum"]);
                        usersalumini.Usr_email = Convert.ToString(dataReader["Usr_email"]);
                        usersalumini.Usr_gender = Convert.ToString(dataReader["Usr_gender"]);
                        usersalumini.Usr_category = Convert.ToString(dataReader["Usr_category"]);
                        usersalumini.Usr_program = Convert.ToString(dataReader["Usr_program"]);
                        usersalumini.Usr_startdate = Convert.ToDateTime(dataReader["Usr_startdate"]);
                        usersalumini.Usr_address = Convert.ToString(dataReader["Usr_address"]);
                        usersalumini.Usr_neighborhood = Convert.ToString(dataReader["Usr_neighborhood"]);
                        usersalumini.Usr_city = Convert.ToString(dataReader["Usr_city"]);
                        usersalumini.Usr_province = Convert.ToString(dataReader["Usr_province"]);
                        usersalumini.Usr_dateregistr = Convert.ToDateTime(dataReader["Usr_dateregistr"]);

                        usersAluminiList.Add(usersalumini);
                    }
                }

                connection.Close();
            }
            return View(usersAluminiList);
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsersAlumini usersalumini)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Insert Into AlumniDb (Usr_doc, Usr_kind_doc, Usr_name, Usr_phonenum, Usr_gender, Usr_category, Usr_program, Usr_startdate, Usr_address, Usr_neighborhood, Usr_city, Usr_province, Usr_dateregistr, Usr_email) Values (@Usr_doc, @Usr_kind_doc, @Usr_name, @Usr_phonenum, @Usr_gender, @Usr_category, @Usr_program, @Usr_startdate, @Usr_address, @Usr_neighborhood, @Usr_city, @Usr_province, @Usr_dateregistr, @Usr_email)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    // adding parameters
                    /*
                    SqlParameter parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_id",
                        Value = usersalumini.Usr_id,
                        SqlDbType = SqlDbType.Int
                    };
                    command.Parameters.Add(parameter);
                    */

                    SqlParameter parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_doc",
                        Value = usersalumini.Usr_doc,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 15
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_kind_doc",
                        Value = usersalumini.Usr_kind_doc,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 15
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_name",
                        Value = usersalumini.Usr_name,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 15
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_phonenum",
                        Value = usersalumini.Usr_phonenum,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 10
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_email",
                        Value = usersalumini.Usr_email,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_gender",
                        Value = usersalumini.Usr_gender,
                        SqlDbType = SqlDbType.Char,
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_category",
                        Value = usersalumini.Usr_category,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_program",
                        Value = usersalumini.Usr_program,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_startdate",
                        Value = usersalumini.Usr_startdate,
                        SqlDbType = SqlDbType.Date,
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_address",
                        Value = usersalumini.Usr_address,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_neighborhood",
                        Value = usersalumini.Usr_neighborhood,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_city",
                        Value = usersalumini.Usr_city,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_province",
                        Value = usersalumini.Usr_province,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100
                    };
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter
                    {
                        ParameterName = "@Usr_dateregistr",
                        Value = usersalumini.Usr_dateregistr,
                        SqlDbType = SqlDbType.Date,
                    };
                    command.Parameters.Add(parameter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            ViewBag.Result = "Success";
            return View();
        }
    }
}
