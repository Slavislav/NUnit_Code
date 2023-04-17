using OpenQA.Selenium;

namespace POMexercises.Pages
{
    public class SumNumbersPage
    {
       private WebDriver driver;
        private const string URL = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        public SumNumbersPage(WebDriver driver)
        {
            this.driver = driver;
        }
        //The idea of this page is to contain all the properties for the related project
        public IWebElement Field1 => driver.FindElement(By.Id("number1"));
        //public IWebElement Field1 { get { return driver.FindElement(By.Id("number1"));  } }
        public IWebElement Field2 => driver.FindElement(By.Id("number2"));
        public IWebElement OperationField => driver.FindElement(By.Id("operation"));
        public IWebElement CalcButton => driver.FindElement(By.Id("calcButton"));
        public IWebElement ResetButton => driver.FindElement(By.Id("resetButton"));
        public IWebElement ResultLabel => driver.FindElement(By.Id("result"));

        public void Open()
        {
            driver.Navigate().GoToUrl(URL);
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }
        public string CalculateNumbers(string firstValue, string operation, string secondValue)
        {
            Field1.SendKeys(firstValue);
            OperationField.SendKeys(operation);
            Field2.SendKeys(secondValue);

            CalcButton.Click();

            return ResultLabel.Text;
        }

    }
}
