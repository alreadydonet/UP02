using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 result = new Class1(new int[] { 1, 2 });
            Class1 expected = new Class1(new int[] { 2, 3 });
            result++;         
            Assert.AreEqual<Class1>(expected, result, "Ожидаемое значение не было получено!");
        }

        //[TestMethod]
        //public void TestMethod2()
        //{
        //    Class1 Actual = new Class1(new int[] { 1, 2, 3, 4, 5, 9 });
        //    FileInfo fileInf = new FileInfo(@"H:\МДК 01.01\1.txt");
        //    Class1 Expected = new Class1();
        //    Expected.ReadFile(fileInf);
        //    Assert.AreEqual<Class1>(Expected, Actual, "Результат не соответствует ожиданию");
        //}

        //[TestMethod]
        //public void TestMethod3()
        //{
        //    Class1 Actual = new Class1(new int[] { 2, -6, -3, 5, 49, -30, -45, 9, 19, -31 });
        //    Class1 ArrayExpected = new Class1(new int[]{ 19, -6, -3, 9, 49, -30, -45, 5, 2, -31 });
        //    Actual.Revers();

        //    Assert.AreEqual<Class1>(ArrayExpected, Actual, "Результат не соответствет ожиданию");
        //}

        //[TestMethod]
        //public void TestMethod4()
        //{
        //    Class1 arr1 = new Class1(new int[] { 1, -9, 2, 7, 3});
        //    Class1 arr2 = new Class1(new int[] { 0, 12, 3, -12, 9 });

        //    Class1 Actual =  arr1 + arr2;
        //    Class1 Exepted = new Class1(new int[] { 1, 3, 5, -5, 12 });

        //    Assert.AreEqual<Class1>(Exepted, Actual, "Результат не соответствет ожиданию");
        //}
    }
}
