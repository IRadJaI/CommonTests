using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static QuestionAlert ToQuestionAlert(this WebElement element) {
            return new QuestionAlert(element.Page, () => element.Element);
        }
        public static QuestionAlert ToQuestionAlert(this IWebElement element, BasePage page) {
            return new QuestionAlert(page, () => element);
        }
    }
    public class QuestionAlert : WebElement {
        const string YES_BUTTON_TEXT = "Да";
        const string NO_BUTTON_TEXT = "Нет";
        public QuestionAlert(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public WebElement Yes {
            get {
                return WebElementExtensions.ToWebElement(() => FindElements(By.ClassName("x-panel-btn")).Single(iw => iw.Text == YES_BUTTON_TEXT), Page);
            }
        }
        public WebElement No {
            get {
                return WebElementExtensions.ToWebElement(() => FindElements(By.ClassName("x-panel-btn")).Single(iw => iw.Text == NO_BUTTON_TEXT), Page);
            }
        }
    }
}
