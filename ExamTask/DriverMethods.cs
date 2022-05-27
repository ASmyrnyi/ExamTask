using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ExamTask
{
    public static class DriverMethods
    {
        public static string Email { get; set; } = "";
        public static string Password { get; set; } = "";

        public static bool Login()
        {
            var currentDirectory = Environment.CurrentDirectory.Contains("ExamTask")
                ? "ExamTask"
                : "Tests";

            var path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf(currentDirectory));
            IWebDriver driver = new ChromeDriver(path);
            driver.Navigate().GoToUrl("https://accounts.ukr.net/");

            driver.FindElement(By.Name("login")).SendKeys(Email);
            driver.FindElement(By.Name("password")).SendKeys(Password);
            driver.FindElement(By.XPath("/html/body/div/div/main/div[1]/form/button")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            bool loginSuccess;

            try
            {
                wait.Until(driver => driver.FindElement(By.ClassName("sidebar__lists")));
                loginSuccess = driver.FindElements(By.ClassName("sidebar__lists")).Count == 1;
            }
            catch (Exception)
            {
                loginSuccess = false;
            }

            Console.WriteLine("Login " + (loginSuccess ? "successful" : "failure"));
            driver.Dispose();
            return loginSuccess;
        }
    }
}
