using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAlumni.Models
{
    public class UsersAlumini
    {
        public int Usr_id { get; set; }
        public String Usr_doc { get; set; }
        public String Usr_kind_doc { get; set; }
        public String Usr_name { get; set; }
        public String Usr_phonenum { get; set; }
        public String Usr_email { get; set; }
        public String Usr_gender { get; set; }
        public String Usr_category { get; set; }
        public String Usr_program { get; set; }
        public DateTime Usr_startdate { get; set; }
        public String Usr_address { get; set; }
        public String Usr_neighborhood { get; set; }
        public String Usr_city { get; set; }
        public String Usr_province { get; set; }
        public DateTime Usr_dateregistr { get; set; }
    }
}
