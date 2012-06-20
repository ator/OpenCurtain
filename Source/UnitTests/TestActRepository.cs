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
using FluentNHibernate;
using FluentNHibernate.Utils;
using NHibernate.Tool.hbm2ddl;

namespace OpenCurtain.UnitTests
{
    [TestClass]
    public class TestActRepository: TestRepository<ActMap>
    {
        [TestMethod]
        public void ActRepositoryCanSaveNewAct()
        {
            using (var uow = unitOfWork.Start())
            {
                var target = new ActRepository(unitOfWork);
                
                var act = new Act();
                var originalAct = act;
                Assert.AreEqual(0, act.Id, "Id should not be set yet");
                
                target.Save(ref act);
                Assert.AreNotEqual(0, act.Id, "Id should be set");
                Assert.AreEqual(originalAct, act, "Should not have a new reference");
            }
        }

        [TestMethod]
        public void ActRepositoryCanMergeActs()
        {
            using (var uow = unitOfWork.Start())
            {
                var target = new ActRepository(unitOfWork);
                
                var original = new Act();
                original.Title = "A title";
                target.Save(ref original);
                
                var updated = new Act();
                var updatedOriginal = updated;

                // Make sure that our updated object has the same id as the one in the database
                // This tests if calls from different instances to the same database would merge their data
                var idMember = Reveal.Member<Act>("Id").ToMember();
                idMember.SetValue(updated, original.Id);
                
                updated.Title = "New title";
                target.Save(ref updated);
                
                Assert.AreNotEqual(updatedOriginal, updated, "Should have set updated to reference loaded from repository");
                Assert.AreEqual(original, updated, "Should have set updated to reference the original");
                Assert.AreEqual("New title", original.Title, "Original should have the new title");
            }
        }

        [TestMethod]
        public void ActRepositoryCanFindAll()
        {
            using (var uow = unitOfWork.Start())
            {
                var target = new ActRepository(unitOfWork);
                
                var act1 = new Act();
                target.Save(ref act1);
                
                var act2 = new Act();
                target.Save(ref act2);

                var acts = target.FindAll().ToList<Act>();
                Assert.AreEqual(2, acts.Count());
                Assert.IsTrue(acts.Contains(act1));
                Assert.IsTrue(acts.Contains(act2));
            }
        }
    }
}
