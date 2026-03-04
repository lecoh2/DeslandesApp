
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Tests.Contexts
{
    public class TestContext
    {
        public static DataContext CreateDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: "DeslandesApp")
               .Options;

            return new DataContext(options);
        }
    }
}
