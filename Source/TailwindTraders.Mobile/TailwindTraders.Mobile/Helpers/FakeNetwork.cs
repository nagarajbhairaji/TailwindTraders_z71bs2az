﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TailwindTraders.Mobile.Helpers
{
    public static class FakeNetwork
    {
        private static readonly Random random = new Random();

        private const int OneOutOfNetworkErrors = 10;

        public static async Task<T> ReturnAsync<T>(T result)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            if (random.Next() % OneOutOfNetworkErrors == 0)
            {
                throw new HttpRequestException();
            }

            return result;
        }
    }
}
