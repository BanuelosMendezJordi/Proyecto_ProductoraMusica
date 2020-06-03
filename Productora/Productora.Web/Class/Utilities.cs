using Productora.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Productora.Web.Class
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public void Dispose()
        {
            db.Dispose();
        }

    }
}