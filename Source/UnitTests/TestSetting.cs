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
    public class TestSetting
    {
        [TestMethod]
        public void SettingCanSetName()
        {
            var target = new Setting();
            Assert.IsNull(target.Name);

            target.Name = "Falstaff's lodging";
            Assert.AreEqual("Falstaff's lodging", target.Name);
            target.Name = "Ford's residence";
            Assert.AreEqual("Ford's residence", target.Name);
        }

        [TestMethod]
        public void SettingCanSetDescription()
        {
            var target = new Setting();
            Assert.IsNull(target.Description);

            target.Description = "A room at the lodging with an armchair, and a small table";
            Assert.AreEqual("A room at the lodging with an armchair, and a small table", target.Description);
            target.Description = "Main hall containing a large money chest, and a chair or small sofa";
            Assert.AreEqual("Main hall containing a large money chest, and a chair or small sofa", target.Description);
        }
    }
}
