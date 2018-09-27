using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Venus.Interface;
using Venus.Model;
using Venus.SqlDB;

namespace UnitTest
{


    [TestClass]
    public class UnitTest1 : SqlDB
    {

        [TestMethod]
        public void TestMethod1()
        {
            int i = 0;
            TestModel Entity = new TestModel()
            {
                Name = "殷振召",
                Sex = "男",
                Addresss = "奥特之星72星云",
                Tel = "1388888888",
                Remark = "不同寻常的奥特之星"
            };

            Assert.AreEqual(base.TestInsert(Entity), true);

            var query = base.TestGetSinge<TestModel>("1");

           
        }


    }
}
