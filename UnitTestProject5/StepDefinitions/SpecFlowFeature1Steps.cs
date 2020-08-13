using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ContextInjection;
using UseJSONAddress;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Hook;
using MyScenarioContextInjection;
using TechTalk.SpecFlow.Assist;

namespace MyTesting.StepBindings1
{
    [Binding]
    public class JO1Steps
    {
        private ChromeDriver driver;
        private String targetUrl = "http://www.google.com";
        private IWebElement searchBox;
        public Context context;

        public ScenarioContext _scenarioContext;

        public JO1Steps(Context context, ScenarioContext sc)
        {
            //this.context = myContext;
            //this.driver = myContext.getDriver();
            this.driver = context.driver;
            this._scenarioContext = sc;
        }


        [Given(@"I go to Google gomepage")]
        public void GivenIGoToGoogleGomepage()
        {
            driver.Navigate().GoToUrl(targetUrl);
        }

        [Given(@"I enter ""(.*)"" into the search box")]
        public void GivenIEnterIntoTheSearchBox(string searchItem)
        {
            searchBox = driver.FindElementByName("q");
            searchBox.SendKeys(searchItem);
            driver.FindElementByXPath("//*[@id=\"tsf\"]/div[2]/div[1]/div[2]/div[2]/ul/li[2]/div/div[2]/div/span/b/brighton").Click();
         

            //*[@id="tsf"]/div[2]/div[1]/div[2]/div[2]/ul/li[2]/div/div[2]/div/span/b
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => driver.FindElementById("btnK").Enabled);
            driver.FindElementByName("btnK").Click();
        }

        [Then(@"I should be directed to search results page")]
        public void ThenIShouldBeDirectedToSearchResultsPage()
        {
            Assert.IsTrue(driver.Title.Contains("Brighton"));
        }



        [Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [When(@"I enter ""(.*)"" into search box")]
        public void WhenIEnterIntoSearchBox(string location)
        {
            searchBox = driver.FindElementById("searchLocation");
            searchBox.SendKeys(location);
        }

        [When(@"I click For Sale")]
        public void WhenIClickForSale()
        {
            driver.FindElementById("buy").Click();
        }


        [When(@"I click findproperties")]
        public void WhenIClickFindproperties()
        {
            driver.FindElementById("submit").Click();
        }

        [When(@"I enter")]
        public void WhenIEnter(Table table)
        {
            String radiusValue = table.Rows[0]["SearchRadius"];
            String minPriceValue = table.Rows[0]["PriceRangeMin"];
            String maxPriceValue  = table.Rows[0]["PriceRangeMax"];
            String minBeds = table.Rows[0]["BedroomsMin"];
            String maxBeds = table.Rows[0]["BedroomsMax"];
            String PropertyType = table.Rows[0]["PropType"];
            String AddedToSite = table.Rows[0]["Added"];
            String SoldSTC = table.Rows[0]["STC"];

            IWebElement radiusBox = driver.FindElementById("radius");
            SelectElement radius = new SelectElement(radiusBox);
            radius.SelectByText(radiusValue);

            new SelectElement(driver.FindElementById("minPrice")).SelectByText(minPriceValue);
            new SelectElement(driver.FindElementById("maxPrice")).SelectByText(maxPriceValue);

            new SelectElement(driver.FindElementById("minBedrooms")).SelectByText(minBeds);
            new SelectElement(driver.FindElementById("maxBedrooms")).SelectByText(maxBeds);
            new SelectElement(driver.FindElementById("displayPropertyType")).SelectByText(PropertyType);
            new SelectElement(driver.FindElementById("maxDaysSinceAdded")).SelectByText(AddedToSite);

            if (SoldSTC.Equals("yes"))
            {
                IWebElement box = driver.FindElementByClassName("touchsearch-checkbox");
                if (box.Displayed)
                {
                    Console.WriteLine("Box is Displayed");      
                }

                if (box.Enabled)
                {
                    Console.WriteLine("Box is enabled");
                }

                if (true)
                {
                    box.Click();
                }
            }
        }

        [Then(@"I should be on page ""(.*)""")]
        public void ThenIShouldBeOnPage(string page)
        {
            Assert.IsTrue(driver.FindElementById("searchTitle").Text.Contains(page));
        }

        [Given(@"I have the following data")]
        public void GivenIHaveTheFollowingData(Table table)
        {
          
            Assert.AreEqual("One", table.Rows[0]["Field"]);
            Assert.AreEqual("Test data part 1", table.Rows[0]["Value"]);

            Assert.AreEqual("Two", table.Rows[1]["Field"]);
            Assert.AreEqual("Test data part 2", table.Rows[1]["Value"]);
        }

        [Then(@"I can see the above data in the scenario")]
        public void ThenICanSeeTheAboveDataInTheScenario()
        {
            var si = _scenarioContext.ScenarioInfo;
        }
    }
}
