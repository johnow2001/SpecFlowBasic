using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ContextInjection;
using UseJSONAddress;
using Hook;

namespace MyTesting.StepBindings2
{
    [Binding]
    public class JO2Steps
    { 
        private ChromeDriver driver;
        public String MyAddress;
        public Context context;

        public JO2Steps(JSONAddress address, Context myContext)
        {
            this.driver = myContext.driver;
            this.MyAddress = address.PostCode;
        }
   
        [Then(@"There shouild be ""(.*)"" results")]
        public void ThenThereShouildBeResults(String resultValue)
        {
            String actualValue = driver.FindElementById("searchHeader").Text;
            Assert.AreEqual(resultValue, actualValue);
        }

        [When(@"I pass the adrress and postcode to this step")]
        public void WhenIPassTheAdrressAndPostcodeToThisStep()
        {
            Console.WriteLine("PostCode = ", this.MyAddress);
        }
    }
}
