using Common.Tests.Base;
using Common.Tests.WebElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Common.Tests.Pages.Invoice {
    public class InvoicePage : BPMInternalBasePage {
        public string DATE_OF_PAY = DateTime.Today.AddDays(1).ToString("dd.MM.yyyy");
        public const string OPPORTUNITY_VAL = "1 ESD H&B";
        public const string ACCOUNT_VAL = "Здравсервис";
        public const string ORGANIZATION_VAL = "ООО \"Перемена Трейд\"";
        public const string AGREEMENT1C_VAL = "Основной договор (Руб)";
        public const string OPPORTUNITY_SEARCH_VAL = "Продажа";
        public const string TabName = "ДОХОДЫ ПО СЧЕТУ";
        private const int MAX_ITERATIONS = 20;

        public InvoicePage(IWebDriver driver) : base(driver) {
        }
        public void DataFilling() {
            DateOfPay.Value = DATE_OF_PAY;
            OpportunityCDS.Value=OPPORTUNITY_VAL;
            OrganizationCDS.Value = ORGANIZATION_VAL;
            Agrrement1CCDS.Value = AGREEMENT1C_VAL;
            SaveButton.Click();
        }
        public void DataCheck() {
            Assert.AreEqual(DateOfPay.Value, DATE_OF_PAY);
            Assert.AreEqual(OpportunityCDS.Value, OPPORTUNITY_VAL);
            Assert.AreEqual(AccountCDS.Value, ACCOUNT_VAL);
            Assert.AreEqual(OrganizationCDS.Value, ORGANIZATION_VAL);
            Assert.AreEqual(Agrrement1CCDS.Value, AGREEMENT1C_VAL);
            Executor.SpinWait(() => TabButtons.Where(tb => tb.Displayed).Count() > 0);
            for (int iterator = 0; iterator <= MAX_ITERATIONS && !TabButtons.Any(tb => tb.Text.Contains(TabName)); iterator++) {
                NextScrollTabsRights.Click();
            }
            TabButtons.Single(tb => tb.Text.Contains(TabName)).Click();
            SpecialOpinionBool.Click();
            Assert.AreNotEqual(ResponsibleSpecialOpinionCDS.Value, OwnerCDS.Value);
        }
        [SkipElement]
        public List<WebElement> TabButtons {
            get {
                return TryGetElements(By.CssSelector("#InvoicePageV2TabsTabPanel-tabpanel-items>li"));
            }
        }
        [SkipElement]
        public WebElement NextScrollTabsRights {
            get {
                return TryGetElement(By.Id("InvoicePageV2TabsTabPanel-scroll-right"));
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
                return TryGetElement(By.Id("InvoicePageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("InvoiceSectionV2CloseButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement SaveRecordButton {
            get {
                return TryGetElement(By.Id("InvoiceSectionV2SaveRecordButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement SpecialOpinionBool {
            get {
                return TryGetElement(By.Id("InvoicePageV2UsrSpecialOpinionResponsibleaaad6662-c4a8-4ecb-b3ee-028099438cd6CheckBoxEdit-wrapEl"));
            }
        }
        public Input DateOfPay {
            get {
                return TryGetElement(By.Id("InvoicePageV2DATE38172814-4809-41d7-9b9d-6cd85e9c46f5DateEdit-el")).ToInput();
            }
        }
        public ControlDropSelect OpportunityCDS {
            get {
                return TryGetElement(By.Id("InvoicePageV2Opportunity9e3ff4a1-272b-405c-ba03-f7fc282a7c4cContainer_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect ResponsibleSpecialOpinionCDS {
            get {
                return TryGetElement(By.Id("InvoicePageV2UsrResponsibleSpecialOpinion79e23ef7-fd22-48ec-98b9-e7b2e58fd5e3Container_Control")).ToControlDropSelect();
            }
        }
        
        public ControlDropSelect AccountCDS {
            get {
                return TryGetElement(By.Id("InvoicePageV2Account685f295c-05c1-468d-879f-10c61e572555Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect OrganizationCDS {
            get {
                return TryGetElement(By.Id("InvoicePageV2UsrOrganizationd63c1364-2e08-4459-8b06-d6aeb0552b53Container_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect OwnerCDS {
            get {
                return TryGetElement(By.Id("InvoicePageV2OwnerContainer_Control")).ToControlDropSelect();
            }
        }
        
        [SkipElement]
        public ControlDropSelect Agrrement1CCDS {
            get {
                return TryGetElement(By.Id("InvoicePageV2UsrContract1c0ed2ed87-1be7-404e-ac7c-31c6fcf208a7Container_Control")).ToControlDropSelect();
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
