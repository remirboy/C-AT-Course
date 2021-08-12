using NUnit.Framework;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using address_book_web.Managers;
using address_book_web.Models;
using address_book_web.Tests;
using System.Text;

namespace address_book_web.Tests
{
    public class TestBase 
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupAppliationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random random = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(random.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
                builder.Append((char)random.Next('A', 'Z' + 1));
            return builder.ToString();
        }

    }
}
