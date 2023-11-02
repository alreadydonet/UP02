using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IntArray result = new IntArray(new int[] { 1, 2 });
            IntArray expected = new IntArray(new int[] { 2, 3 });
            result++;
            Assert.AreEqual(expected, result, "Ожидаемое значение не было получено!");
        }
        [TestMethod]
        public void TestMethod2()
        {
            IntArray obj1 = new IntArray(new int[] { 1, 2, 3 });
            IntArray obj2 = new IntArray(new int[] { 1, 2 });
            IntArray expected = new IntArray(new int[] { 2, 4, 3 });
            IntArray result = obj1 + obj2;
            Assert.AreEqual(expected, result, "Ожидаемое значение не было получено!");
        }
        [TestMethod]
        public void TestMethod3()
        {          
            FileInfo file = new FileInfo(@"E:\C#\ЛР15\test file.txt");
            IntArray result = new IntArray(file);
            IntArray expected = new IntArray(new int[] { 12, 22, 12, 222,2, 22, 3, 3 });
            Assert.AreEqual(expected, result, "Ожидаемое значение не было получено!");
        }
        [TestMethod]
        public void TestMethod4()
        {
            FileInfo file = new FileInfo(@"F:\C#\ЛР15\test.txt");
            IntArray result = new IntArray(new int[] {});
            try
            {
                result = new IntArray(file);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, result.fileLoadException.Message, "Ожидаемое значение не было получено!");
            }
        }
        [TestMethod]
        public void TestMethod5()
        {           
            IntArray result = new IntArray(new int[] { });
            try
            {
                result = new IntArray(new Random(), -1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, result.argumentException.Message, "Ожидаемое значение не было получено!");
            }
        }
        [TestMethod]
        public void TestMethod6()
        {
            IntArray obj = new IntArray(new int[] { 1, 2, 3, 4 });
            List<int> expected = new List<int>(new int[] { 1, 2 });
            List<int> result = obj.FindIndexesNearAvg();
            if (result.Count == expected.Count)
            {
                for(int i = 0; i < result.Count; i++)
                {
                    Assert.AreEqual(expected[i], result[i], "Ожидаемое значение не было получено!");
                }
            }
            else
                Assert.Fail();
        }      
    }
}
