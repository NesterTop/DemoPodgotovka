using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoPodgotovka;
using System;

namespace UnitTesting
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void TestingConnection_ReturnedTrue()
        {
            using(DataBase dataBase = new DataBase())
            {
                Assert.IsTrue(dataBase.IsConnected);
            }
        }
    }
}
