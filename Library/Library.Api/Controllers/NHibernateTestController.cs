using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Library.Data.NHibernate.Model;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NHibernateTestController : ControllerBase
    {
        private ISessionFactory _sessionFactory;
        public IActionResult Index()
        {
            //creating database 
            string connectionString = "Server=localhost;Database=Library;User Id = dbUser; Password=password;";
            CreateDatabase(connectionString);
            Console.WriteLine("Database Created sucessfully");

            //creating a object of customer
            var book = Book.Create("1984", Name.Create("George", "Orwell", null).Value).Value;

            //saving customer in database.
            using (var session = _sessionFactory.OpenSession())
                session.Save(book);

            Console.WriteLine("Customer Saved");
            return Ok();
        }

        void CreateDatabase(string connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                 //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }
    }
}
