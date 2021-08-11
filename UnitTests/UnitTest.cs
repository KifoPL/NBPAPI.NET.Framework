using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBPAPINETFramework;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod()]
        public void GetCurrencyAsyncTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetCurrencyAsync('A', "EUR").Result.Contains("code"));
        }

        [TestMethod()]
        public void GetCurrencyTodayAsyncTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetCurrencyTodayAsync('A', "EUR").Result.Contains("code"));
        }

        [TestMethod()]
        public void GetCurrencyAsyncAtDateTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetCurrencyAsync('A', "EUR", new DateTime(2021, 07, 12)).Result.Contains("code"));
        }

        [TestMethod()]
        public void GetCurrenciesAsyncTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetCurrenciesAsync('A', "EUR", 3).Result.Contains("code"));
        }

        [TestMethod()]
        public void GetCurrenciesAsyncTestFromTo()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetCurrenciesAsync('A', "EUR", new DateTime(2021, 07, 21), new DateTime(2021, 07, 25)).Result.Contains("code"));
        }

        [TestMethod()]
        public void GetTableAsyncTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetTableAsync('A').Result.Contains("EUR"));
        }

        [TestMethod()]
        public void GetTableAsyncTestAtDate()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetTableAsync('A', new DateTime(2021, 07, 20)).Result.Contains("EUR"));
        }

        [TestMethod()]
        public void GetTableTodayAsyncTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetTableTodayAsync('A').Result.Contains("EUR"));
        }

        [TestMethod()]
        public void GetTablesAsyncTest()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetTablesAsync('A', 3).Result.Contains("EUR"));
        }

        [TestMethod()]
        public void GetTablesAsyncTestFromTo()
        {
            Assert.IsTrue(NBPAPINETFramework.NBPAPI.GetTablesAsync('A', new DateTime(2021, 07, 20), new DateTime(2021, 07, 26)).Result.Contains("EUR"));
        }
    }
}
