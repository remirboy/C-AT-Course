using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using address_book_web.Managers;
using address_book_web.Models;
using address_book_web.Tests;

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

    }
}
