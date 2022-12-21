using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupBCinema.Models
{
    public class Admin
    {
        public int AdminUserId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

    }
}