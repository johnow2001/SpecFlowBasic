using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
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

        public ChromeDriver driver1 {get; set;}

        public Context()
        {
            driver = new ChromeDriver("C:\\Users\\John\\eclipse-workspace\\drivers");
            driver.Manage().Window.Maximize();
        }


        /*
        private ChromeDriver driver;
        private IObjectContainer ojectContainer;

        public Context(IObjectContainer objCont)
        {
            this.ojectContainer = objCont;
        }

        
        [BeforeScenario]
        public void InitialiseWebDriver()
        {
            driver = new ChromeDriver("C:\\Users\\John\\eclipse-workspace\\drivers");
            ojectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        /* one way of doing it
        public Context()
        {
            driver = new ChromeDriver("C:\\Users\\John\\eclipse-workspace\\drivers");
            driver.Manage().Window.Maximize();
        }

        public ChromeDriver getDriver()
        {
            return driver;
        }
        */


    }

}
