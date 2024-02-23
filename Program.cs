using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Drawing.Text;

namespace Ecole
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var session = CreateSession())
            {
                Console.WriteLine(session.IsConnected);
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static ISession CreateSession()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsetting.json").Build();
            var connstr = config.GetSection("connstr").Value;

            var mapper = new ModelMapper();

            mapper.AddMappings(typeof(Etudiant).Assembly.ExportedTypes);

            HbmMapping domainmapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var hbconfig = new Configuration();

            hbconfig.DataBaseIntegration(c =>
            {
                c.Driver<MicrosoftDataSqlClientDriver>();
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connstr;
                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;
            });

            hbconfig.AddMapping(domainmapping);

            var sessionfactory = hbconfig.BuildSessionFactory();

            var session = sessionfactory.OpenSession();
            return session;
        }

    }
}