using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.IO;
using OpenCurtain.Infrastructure.NHibernate;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using log4net.Layout;
using log4net.Core;
using log4net;

namespace OpenCurtain
{
    static class Program
    {
        private const string DbFile = "OpenCurtain.db";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetupLogging();
            var sessionFactory = CreateSessionFactory();
            Application.Run(new MainForm());
        }

        private static void SetupLogging()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();
            var rootLogger = hierarchy.Root;
            rootLogger.Level = Level.Debug;
            
            // Define rolling file log with max 5MB per file and max 10 files
            var appender = new RollingFileAppender();
            appender.Name = "RollingLogFileAppenderNHibernate";
#if DEBUG
            appender.AppendToFile = false; // When debugging we want the log file to be recreated on each run
#else
            appenderNH.AppendToFile = true;
#endif
            appender.MaximumFileSize = "5MB";
            appender.MaxSizeRollBackups = 10;
            appender.RollingStyle = RollingFileAppender.RollingMode.Size;
            appender.StaticLogFileName = true;
            appender.LockingModel = new FileAppender.MinimalLock();
            appender.File = "opencurtain.log";
            appender.Layout = new PatternLayout("%date - %message%newline");
            appender.ActivateOptions();
            
            // Make NHibernate output to our log file
            var loggerNH = hierarchy.GetLogger("NHibernate") as Logger;
            loggerNH.Level = Level.Debug;
            loggerNH.AddAppender(appender);
            
            // Make NHibernate output SQL queries to our log file
            var loggerSQL = hierarchy.GetLogger("NHibernate.SQL") as Logger;
            loggerSQL.Level = Level.Debug;
            loggerSQL.AddAppender(appender);
            
            // Make the main application output to our log file (accessed via LogManager.GetLogger("OpenCurtain"))
            var loggerOC = hierarchy.GetLogger("OpenCurtain") as Logger;
            loggerOC.Level = Level.Debug;
            loggerOC.AddAppender(appender);
            
            // this is required to tell log4net that we're done 
            // with the configuration, so the logging can start
            hierarchy.Configured = true;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(SQLiteConfiguration.Standard.UsingFile(DbFile))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ActMap>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }

            new SchemaExport(config).Create(false, true);
        }
    }
}
