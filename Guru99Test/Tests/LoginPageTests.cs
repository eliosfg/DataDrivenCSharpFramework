using CommonLibs;
using Guru99Test.Utils;
using NUnit.Framework;
using Pages;

namespace Tests
{
    public class LoginPageTests
    {
        CommonDriver cmnDriver;
        string url = "http://demo.guru99.com/v4";
        LoginPage loginPage;
        
        [SetUp]
        public void Setup()
        {
            cmnDriver = new CommonDriver("chrome");
            
            cmnDriver.NavigateToUrl(url: url);

            loginPage = new LoginPage(cmnDriver.Driver);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), "GetDataFromDatabase")]
        public void verifyLogin(string username, string password)
        {
           
            loginPage.LoginToApplication(username, password);

            var expectedTitle = "Guru99 Bank Manager HomePage";
            
            var actualTitle = cmnDriver.GetTitle();

            Assert.AreEqual(expectedTitle, actualTitle);


        }

        [TearDown]
        public void tearDown(){
                cmnDriver.CloseAllBrowsers();
        }
    }
}