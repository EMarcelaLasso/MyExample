using EllipticCurve.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExample;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace Paste.Tests
{
    [TestClass]
    public class PasteTests
    {
        public FirefoxDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        [TestInitialize]
        public void SetupTest()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AcceptInsecureCertificates = true;
            Driver = new FirefoxDriver(firefoxOptions);
            Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));  
        }
        [TestCleanup]
        public void TeardownTest()
        {
            Driver.Quit();
        }
        [TestMethod]
        public void RightUser_First()
        {
            PastePage searchEmailMainPage = new PastePage(Driver);
            //searchEmailMainPage.Navigate();
            Driver.Url = "https://pastebin.com";
            searchEmailMainPage.Login();
            searchEmailMainPage.Search("TestML", "Password123.");
            PastePage gmailPage = new PastePage(Driver);
            //gmailPage.ValidateResultsCount("Google Account: test1");
        }
    }
}