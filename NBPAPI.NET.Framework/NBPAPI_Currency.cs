﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace NBPAPINETFramework
{
    /// <summary>
    /// Entry point for interaction with the library.
    /// </summary>
    public static partial class NBPAPI
    {
        #region GetCurrency
        /// <summary>
        /// Gets current Exchange rate from PLN to <paramref name="currencyCode"/> (asynchronous).
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <returns>Async XML/JSON result from NBP API.</returns>
        public static Task<string> GetCurrencyAsync(char tableCode, string currencyCode, bool isJSON = true)
        {
            currencyCode = currencyCode.ToUpper();
            if (currencyCode.Length != 3) throw new ArgumentException("Code must be 3 letters long, check ISO 4217.");

            string tableLetter = tableCode.ToString().ToUpper();

            if (!TableLetterCheck(tableLetter[0])) throw new ArgumentException("Incorrect table letter!");

            string getpath = uri + $"exchangerates/rates/{tableLetter}/{currencyCode}?format={(isJSON ? "json" : "xml")}";

            HttpResponseMessage result = httpClient.GetAsync(getpath).Result;

            if (!result.IsSuccessStatusCode) throw Error(result);

            return result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Gets current Exchange rate from PLN to <paramref name="currencyCode"/>.
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <returns>XML/JSON result from NBP API.</returns>
        public static string GetCurrency(char tableCode, string currencyCode, bool isJSON = true)
        {
            return GetCurrencyAsync(tableCode, currencyCode, isJSON).Result;
        }

        /// <summary>
        /// Gets current Exchange rate from PLN to <paramref name="currencyCode"/> published today (asynchronous).
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <returns>Async XML/JSON result from NBP API.</returns>
        public static Task<string> GetCurrencyTodayAsync(char tableCode, string currencyCode, bool isJSON = true)
        {
            currencyCode = currencyCode.ToUpper();
            if (currencyCode.Length != 3) throw new ArgumentException("Code must be 3 letters long, check ISO 4217.");

            string tableLetter = tableCode.ToString().ToUpper();

            if (!TableLetterCheck(tableLetter[0])) throw new ArgumentException("Incorrect table letter!");

            string getpath = uri + $"exchangerates/rates/{tableLetter}/{currencyCode}/today?format={(isJSON ? "json" : "xml")}";

            HttpResponseMessage result = httpClient.GetAsync(getpath).Result;

            if (!result.IsSuccessStatusCode) throw Error(result);

            return result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Gets Exchange rate from PLN to <paramref name="currencyCode"/> published today.
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML</param>
        /// <returns>XML/JSON result from NBP API.</returns>
        public static string GetCurrencyToday(char tableCode, string currencyCode, bool isJSON = true)
        {
            return GetCurrencyAsync(tableCode, currencyCode, isJSON).Result;
        }
        /// <summary>
        /// Gets current Exchange rate from PLN to <paramref name="currencyCode"/> from <paramref name="date"/> (asynchronous).
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <param name="date">The date.</param>
        /// <returns>Async XML/JSON result from NBP API.</returns>
        public static Task<string> GetCurrencyAsync(char tableCode, string currencyCode, DateTime date, bool isJSON = true)
        {
            currencyCode = currencyCode.ToUpper();
            if (currencyCode.Length != 3) throw new ArgumentException("Code must be 3 letters long, check ISO 4217.");

            string tableLetter = tableCode.ToString().ToUpper();

            if (!TableLetterCheck(tableLetter[0])) throw new ArgumentException("Incorrect table letter!");

            string getpath = uri + $"exchangerates/rates/{tableLetter}/{currencyCode}/{date:yyyy-MM-dd}?format={(isJSON ? "json" : "xml")}";

            HttpResponseMessage result = httpClient.GetAsync(getpath).Result;

            if (!result.IsSuccessStatusCode) throw Error(result);

            return result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Gets Exchange rate from PLN to <paramref name="currencyCode"/> from <paramref name="date"/>.
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <param name="date">The date.</param>
        /// <returns>XML/JSON result from NBP API.</returns>
        public static string GetCurrencyToday(char tableCode, string currencyCode, DateTime date, bool isJSON = true)
        {
            return GetCurrencyAsync(tableCode, currencyCode, date, isJSON).Result;
        }
        #endregion GetCurrency

        #region GetCurrencies
        /// <summary>
        /// Gets last <paramref name="topCount"/> exchange rates from PLN to <paramref name="currencyCode"/> (asynchronous).
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="topCount">Amount of exchange rates to return.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <returns>Async XML/JSON result from NBP API.</returns>
        public static Task<string> GetCurrenciesAsync(char tableCode, string currencyCode, int topCount, bool isJSON = true)
        {
            currencyCode = currencyCode.ToUpper();
            if (currencyCode.Length != 3) throw new ArgumentException("Code must be 3 letters long, check ISO 4217.");

            string tableLetter = tableCode.ToString().ToUpper();

            if (!TableLetterCheck(tableLetter[0])) throw new ArgumentException("Incorrect table letter!");

            string getpath = uri + $"exchangerates/rates/{tableLetter}/{currencyCode}/last/{topCount}?format={(isJSON ? "json" : "xml")}";

            HttpResponseMessage result = httpClient.GetAsync(getpath).Result;

            if (!result.IsSuccessStatusCode) throw Error(result);

            return result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Gets current Exchange rate from PLN to <paramref name="currencyCode"/>.
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <param name="topCount">The amount of currencies to get.</param>
        /// <returns>XML/JSON result from NBP API.</returns>
        public static string GetCurrencies(char tableCode, string currencyCode, int topCount, bool isJSON = true)
        {
            return GetCurrencies(tableCode, currencyCode, topCount, isJSON);
        }
        /// <summary>
        /// Gets exchange rates from PLN to <paramref name="currencyCode"/> from <paramref name="startDate"/> to <paramref name="endDate"/> (asynchronous).
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <returns>Async XML/JSON result from NBP API.</returns>
        public static Task<string> GetCurrenciesAsync(char tableCode, string currencyCode, DateTime startDate, DateTime endDate, bool isJSON = true)
        {
            currencyCode = currencyCode.ToUpper();
            if (currencyCode.Length != 3) throw new ArgumentException("Code must be 3 letters long, check ISO 4217.");

            string tableLetter = tableCode.ToString().ToUpper();

            if (!TableLetterCheck(tableLetter[0])) throw new ArgumentException("Incorrect table letter!");

            string getpath = uri + $"exchangerates/rates/{tableLetter}/{currencyCode}/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}?format={(isJSON ? "json" : "xml")}";

            HttpResponseMessage result = httpClient.GetAsync(getpath).Result;

            if (!result.IsSuccessStatusCode) throw Error(result);

            return result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Gets exchange rates from PLN to <paramref name="currencyCode"/> from <paramref name="startDate"/> to <paramref name="endDate"/>.
        /// </summary>
        /// <param name="tableCode">Table Code (Capital A-C).</param>
        /// <param name="currencyCode">ISO 4217 Currency Code.</param>
        /// <param name="isJSON"><c>true</c> if returned string will be JSON, <c>false</c> if XML.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns>XML/JSON result from NBP API.</returns>
        public static string GetCurrencies(char tableCode, string currencyCode, DateTime startDate, DateTime endDate, bool isJSON = true)
        {
            return GetCurrencies(tableCode, currencyCode, startDate, endDate, isJSON);
        }
        #endregion GetCurrencies
    }
}