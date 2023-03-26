using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace monitor.datamodel
{
    public class MonitoringContext : DbContext
    {
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public MonitoringContext() : base("monitoring")
        { }

        // Отражение таблиц базы данных на свойства с типом DbSet

        public DbSet<GraphPoint> IdContainer { get; set; }
    }
}
