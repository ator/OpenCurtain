using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCurtain.Core.Domain;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using OpenCurtain.Infrastructure.NHibernate;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Testing;

namespace OpenCurtain.UnitTests
{
    public abstract class TestRepository<T> : IDisposable where T: class
    {
        private const string DbFile = "OpenCurtainTest.db";
        protected readonly UnitOfWork unitOfWork;
        
        protected TestRepository()
        {
            unitOfWork = new UnitOfWork(CreateSessionFactory().OpenSession());
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              //.Database(SQLiteConfiguration.Standard.UsingFile(DbFile))
              .Database(SQLiteConfiguration.Standard.InMemory().ShowSql().Provider<SQLiteInMemoryTestConnectionProvider>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            //if (File.Exists(DbFile))
            //{
            //    File.Delete(DbFile);
            //}
            
            new SchemaExport(config).Create(false, true);
        }

        public void Dispose()
        {
            SQLiteInMemoryTestConnectionProvider.ExplicitlyDestroyConnection();
        }
    }
}
