using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace CommonLibs
{
   public class CommonDriver
    {

       public IWebDriver Driver {get; private set;}

        private int pageLoadTimeout;

        private int elementDetectionTimeout;

       public int PageLoadTimeout
        {
            private get { return pageLoadTimeout; }
            set { if (value >= 0) { pageLoadTimeout = value; } }
        }

        public int ElementDetectionTimeout
        {

            private get { return elementDetectionTimeout; }

            set
            {
                if (value > 0) { elementDetectionTimeout = value; }
            }
        }


        public CommonDriver(string browserType) {

                pageLoadTimeout = 60;
                elementDetectionTimeout = 10;

                if(browserType.Equals("chrome")) {
                    Driver = new ChromeDriver();
                } else  if(browserType.Equals("edge")) {
                    Driver = new EdgeDriver();
                } else {
                    throw new Exception("Invalid browser type -" + browserType);
                }

                Driver.Manage().Cookies.DeleteAllCookies();

                Driver.Manage().Window.Maximize();
        }


        public void navigateToFirstUrl(string url) {
            url = url.Trim();

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);

            Driver.Url = url;
        }

        public void NavigateToUrl(string url)
        {
            url = url.Trim();

            Driver.Navigate().GoToUrl(url);
        }

        public void Refresh() => Driver.Navigate().Refresh();

        public void CloseAllBrowsers() => Driver.Quit();


        public void closeBrowser() => Driver.Close();

         public string GetCurrentUrl() => Driver.Url;


        public string GetPageSource() => Driver.PageSource;


        public string GetTitle() => Driver.Title;


        public void NavigateBackward() => Driver.Navigate().Back();


        public void NavigateForward() => Driver.Navigate().Forward();
    }
}
