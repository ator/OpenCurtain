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
    public class TestScene
    {
        [TestMethod]
        public void SceneCanAddCharacter()
        {
            var target = new Scene();
            Assert.AreEqual(0, target.Characters.Count);
            
            target.Add(new Character());
            target.Add(new Character());
            Assert.AreEqual(2, target.Characters.Count);
        }

        [TestMethod]
        public void SceneCanRemoveCharacter()
        {
            var target = new Scene();
            
            var character1 = new Character();
            var character2 = new Character();
            target.Add(character1);
            target.Add(character2);
            Assert.AreEqual(2, target.Characters.Count);
            
            target.Remove(character1);
            Assert.AreEqual(1, target.Characters.Count);
        }

        [TestMethod]
        public void SceneCanSetAct()
        {
            var target = new Scene();
            Assert.IsNull(target.Act);
            
            var act = new Act();
            target.Act = act;
            Assert.AreEqual(act, target.Act);
        }
    }
}
