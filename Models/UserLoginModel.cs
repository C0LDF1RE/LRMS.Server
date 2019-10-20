using System;
using System.ComponentModel.DataAnnotations;

namespace LRMS.Server
{
    public class UserLoginModel
    {
        [Key]
        public int uid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }
        public DateTime registry_date { get; set; }
        public DateTime Last_login_date { get; set; }
        public int login_count { get; set; }
    }
}