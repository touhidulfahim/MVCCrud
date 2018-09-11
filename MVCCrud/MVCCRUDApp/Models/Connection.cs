using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCRUDApp.Models
{
    public class ConnectionDb:DbContext
    {
        public ConnectionDb() : base("ConncetionString")
        {

        }

        public virtual DbSet<BookGenre> BookGenre { get; set; }
        public virtual DbSet<Book> Book { get; set; }


        public static ConnectionDb Create()
        {
            return new ConnectionDb();
        }
    }
}