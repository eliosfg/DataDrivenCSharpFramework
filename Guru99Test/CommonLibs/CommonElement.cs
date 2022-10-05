using System;
using OpenQA.Selenium;

namespace CommonLibs.Implementation
{
    public class CommonElement
    {
        public void ChangeCheckboxStatus(IWebElement Element, bool DesiredState)
        {
            bool CurrentState = Element.Selected;

            if (DesiredState != CurrentState)
            {
                Element.Click();
            }
        }

        public void ClearText(IWebElement element) => element.Clear();


        public void ClickElement(IWebElement element) => element.Click();


        public string GetAttribute(IWebElement element, string attribute) => element.GetAttribute(attribute);


        public string GetCssValue(IWebElement element, string cssProperty) => element.GetCssValue(cssProperty);


        public string GetText(IWebElement element) => element.Text;


        public bool IsElementEnabled(IWebElement element) => element.Enabled;


        public bool IsElementSelected(IWebElement element) => element.Selected;


        public bool IsElementVisible(IWebElement Element) => Element.Displayed;

        public void SetText(IWebElement Element, string TextToWrite) => Element.SendKeys(TextToWrite);

    }
}
