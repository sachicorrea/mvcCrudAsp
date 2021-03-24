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
                DataTable dataTable = new DataTable();

                string sql = "Select * From AlumniDb";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    UsersAlumini usersalumini = new UsersAlumini();
                        usersalumini.Usr_id = Convert.ToInt32(dr["Usr_id"]);
                        usersalumini.Usr_doc = Convert.ToString(dr["Usr_doc"]);
                        usersalumini.Usr_kind_doc = Convert.ToString(dr["Usr_kind_doc"]);
                        usersalumini.Usr_phonenum = Convert.ToString(dr["Usr_phonenum"]);
                        usersalumini.Usr_email = Convert.ToString(dr["Usr_email"]);
                        usersalumini.Usr_gender = Convert.ToString(dr["Usr_gender"]);
                        usersalumini.Usr_category = Convert.ToString(dr["Usr_category"]);
                        usersalumini.Usr_program = Convert.ToString(dr["Usr_program"]);
                        usersalumini.Usr_startdate = Convert.ToDateTime(dr["Usr_startdate"]);
                        usersalumini.Usr_address = Convert.ToString(dr["Usr_address"]);
                        usersalumini.Usr_neighborhood = Convert.ToString(dr["Usr_neighborhood"]);
                        usersalumini.Usr_city = Convert.ToString(dr["Usr_city"]);
                        usersalumini.Usr_province = Convert.ToString(dr["Usr_province"]);
                        usersalumini.Usr_dateregistr = Convert.ToDateTime(dr["Usr_dateregistr"]);

                        usersAluminiList.Add(usersalumini);
                }

                connection.Close();
            }
            return View(usersAluminiList);
        }
    }
    
    public IActionResult Create()
    {
        return View();
    }

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
            string sql = "Insert Into Inventory (Usr_doc, Usr_kind_doc, Usr_name, Usr_phonenum, Usr_email, Usr_gender, Usr_category, Usr_program, Usr_startdate, Usr_address, Usr_neighborhood, Usr_city, Usr_province, Usr_dateregistr) Values (@Usr_doc, @Usr_kind_doc, @Usr_name, @Usr_phonenum, @Usr_email, @Usr_gender, @Usr_category, @Usr_program, @Usr_startdate, @Usr_address, @Usr_neighborhood, @Usr_city, @Usr_province, @Usr_dateregistr)";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;

                // adding parameters

                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Usr_id",
                    Value = usersalumini.Usr_id,
                    SqlDbType = SqlDbType.Int,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Usr_doc",
                    Value = usersalumini.Usr_doc,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Usr_kind_doc",
                    Value = usersalumini.Usr_kind_doc,
                    SqlDbType = SqlDbType.VarChar,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);

                connection.Open();

                // Execute the stored procedure
                command.ExecuteNonQuery();

                // Output parameter value
                string result = Convert.ToString(command.Parameters["@Result"].Value);
                ViewBag.Result = result;

                connection.Close();
            }
        }
        return View();
    }
}
