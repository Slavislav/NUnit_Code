using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMexercises.Pages;

namespace POMexercises.Tests
{
    public class Tests
    {
        private WebDriver driver;
        private SumNumbersPage page;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            this.page = new SumNumbersPage(driver);
            page.Open();


        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SumNumberPage_CheckTitle()
        {
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("Number Calculator"));
        }
        [Test]
        public void Test_SumNumberPage_TwoPositiveNumbers()
        {
            
            var actualResult = page.CalculateNumbers("5", "+", "15");
            Assert.That(actualResult, Is.EqualTo("Result: 20"));
        }
        [Test]
        public void Test_SumNumberPage_MultiplyTwoPositiveNumbers()
        {

            var actualResult = page.CalculateNumbers("5", "*", "15");
            Assert.That(actualResult, Is.EqualTo("Result: 75"));
        }
        [TestCase("5", "*", "20", "Result: 100")]
        [TestCase("5", "+", "20", "Result: 25")]
        [TestCase("5", "-", "20", "Result: 15")]
        [TestCase("20", "/", "5", "Result: 4")]
        public void Test_SumNumberPage_MultiplyTwoPositiveNumbers2
            (string firstValue, string operation, string secondValue, string result)
        {

            var actualResult = page.CalculateNumbers(firstValue, operation, secondValue);
            Assert.That(actualResult, Is.EqualTo(result));
        }
    }
}