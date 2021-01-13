using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Host.Model
{
    public class Demo
    {
        [Key]
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Ename { get => ename; set => ename = value; }
        public string Email { get => email; set => email = value; }

        private string ename;
        private string email;
    }
}
