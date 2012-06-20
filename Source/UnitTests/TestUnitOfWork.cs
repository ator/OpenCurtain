using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCurtain.Core.Domain;
using OpenCurtain.Infrastructure.NHibernate;
using NHibernate;

namespace OpenCurtain.UnitTests
{
    [TestClass]
    public class TestUnitOfWork
    {
        [TestMethod]
        public void UnitOfWorkOpensSessionFirst()
        {
            var sessionMock = new Mock<ISession>();
            
            var target = new UnitOfWork(sessionMock.Object);
            Assert.IsNotNull(target.Session, "Session not started");
            sessionMock.Verify<ITransaction>(x => x.BeginTransaction(), Times.Never(), "Transaction should not be started yet");
        }

        [TestMethod]
        public void UnitOfWorkCanStartTransaction()
        {
            var transactionMock = new Mock<ITransaction>();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);

            var target = new UnitOfWork(sessionMock.Object);
            using (target.Start())
            {
                sessionMock.Verify(x => x.BeginTransaction(), Times.Once(), "Should have started transaction using session");
            }
        }
    }
}
