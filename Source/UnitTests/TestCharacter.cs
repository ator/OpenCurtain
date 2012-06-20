using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCurtain.Core.Domain;

namespace OpenCurtain.UnitTests
{
    [TestClass]
    public class TestCharacter
    {
        [TestMethod]
        public void RoleCanSetName()
        {
            var target = new Character();
            Assert.IsNull(target.Name);

            target.Name = "Falstaff";
            Assert.AreEqual("Falstaff", target.Name);

            target.Name = "Bardolfo";
            Assert.AreEqual("Bardolfo", target.Name);
        }

        [TestMethod]
        public void RoleCanAddDirection()
        {
            var target = new Character();
            Assert.AreEqual(0, target.Directions.Count);
            
            target.Add(new Direction());
            target.Add(new Direction());
            Assert.AreEqual(2, target.Directions.Count);
        }

        [TestMethod]
        public void RoleCanRemoveDirection()
        {
            var target = new Character();
            
            var direction1 = new Direction();
            var direction2 = new Direction();
            target.Add(direction1);
            target.Add(direction2);
            Assert.AreEqual(2, target.Directions.Count);
            
            target.Remove(direction1);
            Assert.AreEqual(1, target.Directions.Count);
        }
    }
}
