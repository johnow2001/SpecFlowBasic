using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextInjection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MyTesting.HomePageObjects
{
    class HomePageObject
    {
        private ChromeDriver driver;

        public HomePageObject(ChromeDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Check bin collection days")]
        public IWebElement BinCollectionLink { get; set; }
    }
}
