﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace NBPAPINETFramework
{
    public static partial class NBPAPI
    {
        /// <summary>
        /// Table Codes accepted by NBP API (Currently A, B, C).
        /// </summary>
        public static readonly char[] TableCodes = "ABC".ToCharArray();

        private static HttpClient httpClient = new HttpClient();
        /// <summary>
        /// http://api.nbp.pl/api/
        /// </summary>
        private readonly static string uri = "http://api.nbp.pl/api/";

        /// <param name="tableCode">The table code (in uppercase).</param>
        /// <returns>Whether <see cref="TableCodes"/> contains the table code.</returns>
        private static bool TableLetterCheck(char tableCode)
        {
            if (TableCodes.Contains(tableCode)) return true;
            else return false;
        }

        /// <param name="response">The response.</param>
        /// <returns>Error message with status code.</returns>
        private static HttpRequestException Error(HttpResponseMessage response)
        {
            return new HttpRequestException($"Error {response.StatusCode:D}: {response.ReasonPhrase}");
        }
    }
}