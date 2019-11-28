using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ContextInjection;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Hook
{
    [Binding]
    class Hooks
    {
        private static ExtentHtmlReporter reporter;
        private static ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        public ChromeDriver driver;
        public Context myContext;

        public Hooks(Context context)
        {
            this.myContext = context;
        }
       

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            reporter = new ExtentHtmlReporter(@"C:\Users\John\source\repos\UnitTestProject5\TestResults\report.html");
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title); 
        }

        [BeforeScenario]
        public void Before()
        {
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "And")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

            //Pending Status
            /*
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
            */
        }

        [AfterScenario]
        public void After()
        {
            myContext.getDriver().Quit();
        }

        [AfterFeature]
        public static void AfterFeature()
        {

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }
    }
}
