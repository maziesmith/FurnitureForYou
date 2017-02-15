using FFY.Data;
using FFY.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FFY.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FFYContext, Configuration>());
            FFYContext.Create().Database.Initialize(true);
        }
    }
}