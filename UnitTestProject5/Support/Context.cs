using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UseJSONAddress;

namespace ContextInjection
{
    public class Context
    {
        private ChromeDriver driver;

        public Context()
        {
            driver = new ChromeDriver("C:\\Users\\John\\eclipse-workspace\\drivers");
            driver.Manage().Window.Maximize();
        }

        public ChromeDriver getDriver()
        {
            return driver;
        }
    }

}
