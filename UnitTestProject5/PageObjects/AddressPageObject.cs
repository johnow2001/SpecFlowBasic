using System.Threading.Tasks;
using ContextInjection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using static MyLocators.FindElement;

namespace MyTesting.AddressPageObjects
{
    class AddressPageObject
    {
        private ChromeDriver driver;

        public AddressPageObject(ChromeDriver driver)
        {
            this.driver = driver;
        }

        /*
        //[FindsBy(How = How.Id, Using = "mxui_widget_TextInput_0")]
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @class='form-control']")]
        public IWebElement PostCodeEntryBox { get; set; }

        //[FindsBy(How = How.Id, Using = "mxui_widget_Wrapper_4")]
        [FindsBy(How = How.XPath, Using = "//*[@type='button' and text()='Find address']")]
        public IWebElement FindAddressButton { get; set; }

        [FindsBy(How = How.Id, Using = "mxui_widget_ReferenceSelector_0_input")]
        //[FindsBy(How = How.XPath, Using = "//*[@class='form-control' and contains(@id,'ReferenceSelector_0')]")]
        public IWebElement SelectAddress { get; set; }

        //[FindsBy(How = How.Id, Using = "mxui_widget_Wrapper_7")]
        [FindsBy(How = How.XPath, Using = "//*[@type='button' and text()='Next collections']")]
        public IWebElement NexCollectionButton { get; set; }
        */

        public void PostCodeEntryBox(string PostCode)
        {
            //IWebElement PostCodeEntryBox = driver.FindElementByXPath("//input[@type='text' and @class='form-control']");
            IWebElement PostCodeEntryBox = MyFindElement(driver, ExpectedConditions.ElementToBeClickable
             (By.XPath("//input[@type='text' and @class='form-control']")), 0);
            PostCodeEntryBox.SendKeys(PostCode);
        }

        public void FindAddressButton()
        {
            driver.FindElementByXPath("//*[@type='button' and text()='Find address']").Click();
        }

        public void SelectAdressFromDropDown(string Address)
        {
            /*
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            IWebElement Addr = wait.
                Until(ExpectedConditions.ElementToBeClickable(By.Id("mxui_widget_ReferenceSelector_0_input")));
            Addr.Click();
            SelectElement MyAddress = new SelectElement(Addr);
            MyAddress.SelectByText(Address); 
            */

            IWebElement E = MyFindElement(driver, ExpectedConditions.
                ElementToBeClickable(By.Id("mxui_widget_ReferenceSelector_0_input")),2);
            E.Click();
            SelectElement MyAddress = new SelectElement(E);
            MyAddress.SelectByText(Address);
        }

        public void NexCollectionButton()
        {          
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            IWebElement Button = wait.
                Until(ExpectedConditions.
                ElementToBeClickable(By.XPath("//*[@type='button' and text()='Next collections']")));
            Button.Click();
        }

        //Fin with CSS Selectors

        public void PostCodeEntryBoxCSS(string PostCode)
        {
            driver.FindElementByCssSelector("input[type='text'][id*='TextInput']").
                SendKeys(PostCode);
        }

        public void FindAddressButtonCSS()
        {
            driver.FindElementByCssSelector("button.btn-success").Click(); 
        }

        public void SelectAdressFromDropDownCSS(string Address)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(3));
            IWebElement Addr = wait.Until(ExpectedConditions.
                ElementToBeClickable(By.CssSelector("Select[id*='Selector']")));

            Addr.Click();
            SelectElement MyAddress = new SelectElement(Addr);
            MyAddress.SelectByText(Address);
        }

        public void NexCollectionButtonCSS()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.
                CssSelector("button.chevron-right.btn-success"))).Click();
        }
    }
}

