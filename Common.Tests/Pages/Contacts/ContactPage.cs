using Common.Tests.Base;
using Common.Tests.WebElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Common.Tests.Pages.Contacts {
    public class ContactPage : BPMInternalBasePage {
        public const string JOB_INPUT_VAL = "Руководитель отдела";
        public const string SKYPE_VAL = "skype";
        public const string GENDER_INPUT_VAL = "Мужской";
        public const string PHONE_INPUT_VAL = "123456789";
        public const string EMAIL_INPUT_VAL = "test@email.com";
        public const string DISCOUNT_INPUT_VAL = "100";
        public const string DEAR_INPUT_VAL = "Ув.";
        public const string COMMENTS_INPUT_VAL = "Комментарий";
        public const string DEPARTMERNT_INPUT_VAL = "Разработка";
        public const string ESN_MESSAGE_VAL = "test";
        public const string BIRTDAY_INPUT_VAL = "22.02.1992";
        private const int MAX_ITERATIONS = 20;

        public ContactPage(IWebDriver driver) : base(driver) {
        }
        public void DataFilling() {
            JobInput.Value = JOB_INPUT_VAL;
            AddConnectionTypeButton.Click();
            AddSkypeButton.Click();
            ContactCommunicationDetail.Last().input.Value= SKYPE_VAL;
            GenderInput.Value = GENDER_INPUT_VAL;
            MobilePhoneInput.Value = PHONE_INPUT_VAL;
            EmailInput.Value =EMAIL_INPUT_VAL;
            WorkPhoneInput.Value = PHONE_INPUT_VAL;
            DiscountInput.Value = DISCOUNT_INPUT_VAL;
            DearInput.Value = DEAR_INPUT_VAL;
            CommentsInput.Value = COMMENTS_INPUT_VAL;
            AddBirtdayButton.Click();
            Executor.SpinWait(() => BirthdayElements.Where(be => be.Text == "День рождения").Count() > 0);
            BirthdayElements.Single(be => be.Text == "День рождения").Click();
            Driver.WaitForReady();
            AddBirthdayDetailPage addBirthdayDP = new AddBirthdayDetailPage(Driver);
            addBirthdayDP.BirthdayField.SendKeys(BIRTDAY_INPUT_VAL);
            addBirthdayDP.SaveButton.Click();
            Executor.SpinWait(() => TabButtons.Where(tb => tb.Text == "МЕСТО РАБОТЫ").Count() > 0);
            TabButtons.Single(tb => tb.Text == "МЕСТО РАБОТЫ").Click();
            Executor.SpinWait(() => DepartmerntInput.Exist && DearInput.Displayed);
            DepartmerntInput.Value = DEPARTMERNT_INPUT_VAL;
            Driver.WaitForReady();
            AddCareerButton.Click();
            AddContactCareerPage addContactCareerPage = new AddContactCareerPage(Driver);
            addContactCareerPage.DataFilling();
            addContactCareerPage.SaveButton.Click();
            Executor.SpinWait(() => TabButtons.Where(tb => tb.Displayed).Count() > 0);
            for (int iterator = 0; iterator <= MAX_ITERATIONS && !TabButtons.Any(tb => tb.Text.Contains("ЛЕНТА")); iterator++) {
                NextScrollTabsRights.Click();
            }
            TabButtons.Single(tb => tb.Text.Contains("ЛЕНТА")).Click();
            Executor.SpinWait(() => FeedNewMessageEditor.ClickAreaEditor.Exist && FeedNewMessageEditor.ClickAreaEditor.Displayed);
            FeedNewMessageEditor.ClickAreaEditor.Click();
            Driver.WaitForReady();
            FeedNewMessageEditor.TypeText(ESN_MESSAGE_VAL);
            FeedNewMessageSubmitButton.Click();
            Driver.WaitForReady();
            CloseButton.Click();
        }
        public void DataCheck() {
            Assert.AreEqual(JobInput.Value, JOB_INPUT_VAL);
            Assert.AreEqual(ContactCommunicationDetail.First(cd => cd.input.Value == "skype").input.Text, string.Empty);
            Assert.AreEqual(GenderInput.Value, GENDER_INPUT_VAL);
            Assert.AreEqual(MobilePhoneInput.Value, PHONE_INPUT_VAL);
            Assert.AreEqual(WorkPhoneInput.Value, PHONE_INPUT_VAL);
            Assert.AreEqual(EmailInput.Value, EMAIL_INPUT_VAL);
            Assert.AreEqual(DiscountInput.Value, DISCOUNT_INPUT_VAL);
            Assert.AreEqual(DearInput.Value, DEAR_INPUT_VAL);
            Assert.AreEqual(CommentsInput.Value, COMMENTS_INPUT_VAL);
            Assert.AreEqual(BirthdayDetailElements.Last().Text, BIRTDAY_INPUT_VAL);
            TabButtons.Single(tb => tb.Text == "МЕСТО РАБОТЫ").Click();
            Assert.AreEqual(DepartmerntInput.Value, DEPARTMERNT_INPUT_VAL);
            for (int iterator = 0; iterator <= MAX_ITERATIONS && !TabButtons.Any(tb => tb.Text.Contains("ЛЕНТА")); iterator++) {
                NextScrollTabsRights.Click();
            }
            Driver.WaitForReady();
            TabButtons.Single(tb => tb.Text.Contains("ЛЕНТА")).Click();
            Driver.WaitForReady();
            Assert.AreEqual(EsnMessages.First().TextField.Text, ESN_MESSAGE_VAL);
        }

        public WebElement CaseFeedPanelTabs {
            get {
                return TryGetElement(By.Id("SectionActionsDashboardTabsTabPanel-tabpanel-items"));
            }
        }
        [SkipElement]
        public List<WebElement> TabButtons {
            get {
                return TryGetElements(By.CssSelector("#ContactPageV2TabsTabPanel-tabpanel-items>li"));
            }
        }
        [SkipElement]
        public WebElement NextScrollTabsRights {
            get {
                return TryGetElement(By.Id("ContactPageV2TabsTabPanel-scroll-right"));
            }
        }
        [SkipElement]
        public WebElement FeedNewMessageSubmitButton {
            get {
                return TryGetElement(By.CssSelector(".postMessage span[data-item-marker^=publishPostMessageButton]"));
            }
        }
        [SkipElement]
        public CKEEditor FeedNewMessageEditor {
            get {
                return new CKEEditor(this, () => TryGetElement(By.ClassName("social-message-edit-container")), TryGetElement(By.CssSelector(".social-message-edit-container textarea")).GetAttribute("id"));
            }
        }
        [SkipElement]
        public List<EsnMessage> EsnMessages {
            get {
                return TryGetElements(By.CssSelector(".social-feed-messages .postContainer"))
                    .Select(messageWebElement => {
                        return new EsnMessage(this, () => messageWebElement);
                    }).ToList();
            }
        }
        [SkipElement]
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("ContactPageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("ContactSectionV2CloseButtonButton-textEl"));
            }
        }

        public Input MobilePhoneInput {
            get {
                return TryGetElement(By.Id("ContactPageV2AccountMobilePhoneTextEdit-el")).ToInput();
            }
        }
        public Input WorkPhoneInput {
            get {
                return TryGetElement(By.Id("ContactPageV2AccountPhoneTextEdit-el")).ToInput();
            }
        }
        public Input EmailInput {
            get {
                return TryGetElement(By.Id("ContactPageV2AccountEmailTextEdit-el")).ToInput();
            }
        }
        public ControlDropSelect GenderInput {
            get {
                return TryGetElement(By.Id("ContactPageV2GenderContainer_Control")).ToControlDropSelect();
            }
        }
        public Input DiscountInput {
            get {
                return TryGetElement(By.Id("ContactPageV2UsrdiscTextEdit-el")).ToInput();
            }
        }
        public Input DearInput {
            get {
                return TryGetElement(By.Id("ContactPageV2DearTextEdit-el")).ToInput();
            }
        }
        public Input CommentsInput {
            get {
                return TryGetElement(By.Id("ContactPageV2UsrcommentariiMemoEdit-el")).ToInput();
            }
        }
        [SkipElement]
        public ControlDropSelect JobInput {
            get {
                return TryGetElement(By.Id("ContactPageV2Job1LookupEdit-wrap")).ToControlDropSelect();
            }
        }
        public WebElement AddConnectionTypeButton {
            get {
                return TryGetElement(By.Id("ContactCommunicationDetailAddButtonButton-wrapperEl"));
            }
        }
        [SkipElement]
        public List<WebElement> JobItems {
            get {
                return TryGetElements(By.CssSelector(".listview li"));
            }
        }
        [SkipElement]
        public WebElement AddSkypeButton {
            get {
                return TryGetElement(By.Id("09e4bda6-cfcb-df11-9b2a-001d60e938c6"));
            }
        }
        [SkipElement]
        public WebElement WorkplaceTab {
            get {
                return TryGetElement(By.CssSelector("#ContactPageV2TabsTabPanel-tabpanel-items > li:nth-child(2)"));
            }
        }
        [SkipElement]
        public WebElement CloseCardButton {
            get {
                return TryGetElement(By.Id("ContactSectionV2CloseButtonButton-textEl"));
            }
        }
        [SkipElement]
        public ControlDropSelect DepartmerntInput {
            get {
                return TryGetElement(By.Id("ContactPageV2DepartmentContainer_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public List<CommunicationItem> ContactCommunicationDetail {
            get {
                return TryGetElement(By.Id("ContactCommunicationDetailDetailControlGroup"))
                    .FindElements(By.CssSelector("#ContactCommunicationDetailCommunicationsContainerContainerList>div"))
                    .Select(we => new CommunicationItem(this, () => we))
                    .ToList();
            }
        }
        public WebElement AddBirtdayButton {
            get {
                return TryGetElement(By.Id("ContactAnniversaryDetailV2AddTypedRecordButtonButton-imageEl"));
            }
        }
        [SkipElement]
        public List<WebElement> BirthdayElements {
            get {
                return TryGetElements(By.CssSelector(".menu-wrap .menu-item"));
            }
        }
        [SkipElement]
        public List<WebElement> BirthdayDetailElements {
            get {
                return TryGetElements(By.CssSelector("#grid-ContactAnniversaryDetailV2DataGridGrid-wrap .grid-cols-12"));
            }
        }
        [SkipElement]
        public WebElement AddCareerButton {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.Id("ContactCareerDetailV2AddRecordButtonButton-imageEl")), this);
            }
        }
    }
    public class CommunicationItem : WebElement {
        public CommunicationItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {}
        public Input input {
            get {
                return new Input(Page, () => Element.FindElement(By.CssSelector("input")));
            }
        }
    }
    public class TabPanelItem : WebElement {
        public TabPanelItem(BasePage page, Func<IWebElement> getElement): base(page, getElement) {}
        public WebElement Tab {
            get {
                return WebElementExtensions.ToWebElement(() => Element.FindElement(By.CssSelector("ts-box-sizing")), Page);
            }
        }
    }
    public class EsnMessage : WebElement {
        public WebElement LikeButton {
            get {
                return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("likeButtonImageConfig")), Page);
            }
        }
        public WebElement TextField {
            get {
                return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("multiline-label")), Page);
            }
        }
        public EsnMessage(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }
    }
}
