using System.Threading.Tasks;
using ContextInjection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace MyTesting.CheckCollectionObjects
{
    class CheckCollectionsPageObjects
    {
        private ChromeDriver driver;

        public CheckCollectionsPageObjects(ChromeDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Start")]
        public IWebElement StartButton { get; set; }
    }
}
