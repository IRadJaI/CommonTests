using Common.Tests.Base;
using Common.Tests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class VisaListElement : WebElement {
        const string APPROVE_VISA = "Утвердить";
        const string REJECT_VISA = "Отклонить";
        const string CHANGE_VISA = "Сменить визирующего";
        public void RejectVisa(string comment="") {
            VisaName.Click();
            VisaActionButton.Click();
            Executor.SpinWait(() => VisaActions.Any(vm => vm.Exist && vm.Displayed && vm.Text==REJECT_VISA));
            VisaActions.Single(tb => tb.Text == REJECT_VISA).Click();
            ((BPMInternalBasePage)Page).VisaMessageBox.ButtonOk.Click();
        }
        public void ApproveVisa() {
            VisaName.Click();
            VisaActionButton.Click();
            Executor.SpinWait(() => VisaActions.Any(vm => vm.Exist && vm.Displayed && vm.Text == APPROVE_VISA));
            VisaActions.Single(tb => tb.Text == APPROVE_VISA).Click();
            Executor.SpinWait(() => !Exist);
        }
        public void ChangeVisa() {
            VisaName.Click();
            VisaActionButton.Click();
            Executor.SpinWait(() => VisaActions.Any(vm => vm.Exist && vm.Displayed && vm.Text == CHANGE_VISA));
            VisaActions.Single(tb => tb.Text == CHANGE_VISA).Click();
        }

        public WebElement VisaName {
            get {
                return new WebElement(Page, () => Element.FindElement(By.ClassName("visa-notification-item-container")));
            }
        }
        public WebElement VisaActionButton {
            get {
                return new WebElement(Page, () => Element.FindElement(By.CssSelector("span[data-item-marker^=VisaActionButton]")));
            }
        }
        [SkipElement]
        public List<WebElement> VisaActions {
            get {
                return Page.TryGetElements(By.CssSelector("ul[data-item-marker^=VisaActionButton] li"))
                    .Select(e => WebElementExtensions.ToWebElement(() => e, Page)).ToList();
            }
        }
        public VisaListElement(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }
    }

}
