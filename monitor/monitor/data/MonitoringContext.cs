using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace monitor.datamodel
{
    public class MonitoringContext : DbContext
    {
        public static string ccs = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=monitoring;Integrated Security=True;MultipleActiveResultSets=True";
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public MonitoringContext() : base(MonitoringContext.ccs)
        { }

        // Отражение таблиц базы данных на свойства с типом DbSet

        public DbSet<GraphPoint> GraphPoint { get; set; }
        public DbSet<GraphList> GraphList { get; set; }
    }
}
