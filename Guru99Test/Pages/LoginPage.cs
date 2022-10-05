using CommonLibs.Implementation;
using OpenQA.Selenium;

namespace Pages
{
    public class LoginPage
    {
        CommonElement commonElement;
        private IWebDriver driver;

        private IWebElement username => driver.FindElement(By.Name("uid"));

        private IWebElement password => driver.FindElement(By.Name("password"));

        private IWebElement loginButton => driver.FindElement(By.Name("btnLogin"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            commonElement = new CommonElement();

        }

        public void LoginToApplication(string sUsername, string sPassword){

            commonElement.SetText(username, sUsername);

            commonElement.SetText(password, sPassword);

            commonElement.ClickElement(loginButton);

        }
    }
}