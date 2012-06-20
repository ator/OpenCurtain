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
    public class TestAct
    {
        [TestMethod]
        public void ActCanAddScene()
        {
            var target = new Act();
            Assert.AreEqual(0, target.Scenes.Count);
            
            target.Add(new Scene());
            target.Add(new Scene());
            Assert.AreEqual(2, target.Scenes.Count);
        }

        [TestMethod]
        public void ActCanRemoveScene()
        {
            var target = new Act();
            
            var scene1 = new Scene();
            var scene2 = new Scene();
            target.Add(scene1);
            target.Add(scene2);
            Assert.AreEqual(2, target.Scenes.Count);
            
            target.Remove(scene1);
            Assert.AreEqual(1, target.Scenes.Count);
        }
    }
}
