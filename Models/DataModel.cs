using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using GroupBCinema.Models;

namespace GroupBCinema.Models
{
    public class DataModel:DbContext
    {
        public DataModel()
           : base("name=DataModel")
        {
        }

        //public virtual DbSet<creditcard> creditcards { get; set; }
        public virtual DbSet<movy> movies { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<show> shows { get; set; }
        public virtual DbSet<theater> theaters { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}