using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MyLocators
{
    static class FindElement
    {
       public static IWebElement MyFindElement(ChromeDriver driver, Func<IWebDriver, IWebElement> Conditions, int TimeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));        
            return wait.Until(Conditions);
        }
    }

}
