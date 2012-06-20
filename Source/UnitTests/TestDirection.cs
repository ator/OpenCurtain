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
    public class TestDirection
    {
        [TestMethod]
        public void DirectionCanSetActor()
        {
            var target = new Direction();
            Assert.IsNull(target.Character);

            var actor = new Character();
            target.Character = actor;
            Assert.AreEqual(actor, target.Character);

            actor = new Character();
            target.Character = actor;
            Assert.AreEqual(actor, target.Character);
        }

        [TestMethod]
        public void DirectionCanSetScene()
        {
            var target = new Direction();
            Assert.IsNull(target.Scene);

            var scene = new Scene();
            target.Scene = scene;
            Assert.AreEqual(scene, target.Scene);

            scene = new Scene();
            target.Scene = scene;
            Assert.AreEqual(scene, target.Scene);
        }

        [TestMethod]
        public void DirectionCanSetDescription()
        {
            var target = new Direction();
            Assert.IsNull(target.Description);

            target.Description = "Feels sorry for himself";
            Assert.AreEqual("Feels sorry for himself", target.Description);

            target.Description = "";
            Assert.AreEqual("", target.Description);
        }
    }
}
