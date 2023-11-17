using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace MyExample
{
    public class PastePage
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://pastebin.com";
        
        public PastePage(IWebDriver browser)
        {
            this.driver = browser;
        //    PageFactory.InitElements(browser, this);
        }
        [FindsBy(How = How.Id, Using = "loginform-username")]
        public IWebElement UnameBox { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        public IWebElement GoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "loginform-password")]
        public IWebElement PasswordBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='OyEIQ uSvLId']//div[@jsname='B34EJ']")]
        public IWebElement ValidationLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='btn-sign sign-in']")]
        private readonly By buttontest = By.XPath("//a[@class='btn-sign sign-in']");
        public IWebElement LoginButton { get; set; }
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        public void Login()
        {
            Thread.Sleep(6000);
            driver.FindElement(buttontest).Click();
            Thread.Sleep(6000);
        }
        public void Search(string uname, string pwd)
        {
            UnameBox.Clear();
            UnameBox.SendKeys(uname);
            PasswordBox.SendKeys(pwd);
            GoButton.Click();
        }

        public void ValidateMessage(string expectedText)
        {
            Assert.IsTrue(this.ValidationLabel.Text.Contains(expectedText));
        }
    }
}
