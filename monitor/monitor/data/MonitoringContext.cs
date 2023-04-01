using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Windows.Markup;
using System.Runtime.Remoting.Contexts;

namespace monitor.datamodel
{
    public class MonitoringContext : DbContext
    {
        public static string ccs = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security = True";
        
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public MonitoringContext() : base(MonitoringContext.ccs)
        {
            this.Database.Log = null;
        }

        // Отражение таблиц базы данных на свойства с типом DbSet

        public DbSet<GraphPoint> GraphPoint { get; set; }
        public DbSet<GraphList> GraphList { get; set; }
    }
}
