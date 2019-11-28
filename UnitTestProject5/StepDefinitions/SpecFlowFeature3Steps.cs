using System;
using TechTalk.SpecFlow;
using ContextInjection;
using OpenQA.Selenium.Chrome;
using MyTesting.HomePageObjects;
using MyTesting.CheckCollectionObjects;
using MyTesting.AddressPageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using UseJSONAddress;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using NUnit.Framework;
using System.Linq;
using Hook;

namespace MyTesting.StepDefinitions3
{
    [Binding]
    public class JO3Steps
    {
        private ChromeDriver driver;
        private HomePageObject HomePage;
        private CheckCollectionsPageObjects CheckCollections;
        private AddressPageObject AddressPage;
        private ReadOnlyCollection<String> WindowHandles;
        public JSONAddress address;

        public JO3Steps(JSONAddress myAddress, Context context)
        {
            this.driver = context.getDriver();
            this.address = myAddress;
        }

        [When(@"I click on bin collections")]
        public void WhenIClickOnBinCollections()
        {
            HomePage = new HomePageObject(this.driver);
            HomePage.BinCollectionLink.Click();
        }
        
        [When(@"I select start")]
        public void WhenISelectStart()
        {
            CheckCollections = new CheckCollectionsPageObjects(this.driver);
            CheckCollections.StartButton.Click();
        }
        
        [When(@"I enter postcode ""(.*)""")]
        public void WhenIEnterPostcode(string PostCode)
        {
            WindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(WindowHandles[1]);
            AddressPage = new AddressPageObject(this.driver);
            AddressPage.PostCodeEntryBoxCSS(PostCode);
        }
        
        [When(@"I click find addess and enter ""(.*)""")]
        public void WhenIClickFindAddessAndEnter(string Address)
        {
            driver.SwitchTo().Window(WindowHandles[1]);
            if (AddressPage == null)
            {
                AddressPage = new AddressPageObject(this.driver);
            }
            AddressPage.FindAddressButtonCSS();
            AddressPage.SelectAdressFromDropDownCSS(Address);
        }
        
        [When(@"I click next collections")]
        public void WhenIClickNextCollections()
        {
            driver.SwitchTo().Window(WindowHandles[1]);
            if (AddressPage == null)
            {
                AddressPage = new AddressPageObject(this.driver);
            }
            AddressPage.NexCollectionButtonCSS();
        }

        [Given(@"I enter address and postcode from file")]
        public void WhenIEnterAddressAndPostcodeFromFile()
        {
            String path = @"C:\Users\John\source\repos\UnitTestProject5\UnitTestProject5\Features\data.json";
            //address = JsonConvert.DeserializeObject<JSONAddress>(File.ReadAllText(path));
            
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                this.address = (JSONAddress)serializer.Deserialize(file, typeof(JSONAddress));
                Console.WriteLine(address.Names.ToString());               
                Console.WriteLine("PostCode = ", address.PostCode);
                Console.WriteLine("Address = ", address.Address);
          
                String[] a1 = new String[address.Names.Count];
                String[] a2 = new String[address.Names.Count];

                a1 = address.Names.ToArray();
                a2[0]="John"; a2[1]="Dave"; a2[2]="Admin"; a2[3]="User";
                Assert.IsTrue(a1.SequenceEqual(a2));

                WhenIEnterPostcode(address.PostCode);
                WhenIClickFindAddessAndEnter(address.Address);
            }           
        }

    }
}
