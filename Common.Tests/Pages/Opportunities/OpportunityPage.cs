using Common.Tests.Base;
using Common.Tests.WebElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Common.Tests.Pages.Opportunities {
    public class OpportunityPage : BPMInternalBasePage {
        public const string CLIENT_INPUT_VAL = "КТЗ (Калужский турбинный завод)";
        public const string AGENT_VAL = "Промтекстиль";
        public const string LEGAL_CUSTOMER_VAL = "ООО \"ПРОМТЕКСТИЛЬ\"";
        public const string OPPORTUNITY_NAME = "Автотестовая продажа";
        public const string LEAD_TYPE = "Teamwork";
        private const int MAX_ITERATIONS = 20;

        public OpportunityPage(IWebDriver driver) : base(driver) {
        }
        public void DataFilling() {
            ClientCDS.Value = CLIENT_INPUT_VAL;
            NotDirectOpportunityBool.Click();
            AgentCDS.Value = AGENT_VAL;
            OpportunityNameInput.Value = OPPORTUNITY_NAME;
            LeadTypeCDS.Value = LEAD_TYPE;
            SaveButton.Click();
        }
        public void DataCheck() {
            Assert.AreEqual(ClientCDS.Value, CLIENT_INPUT_VAL);
            Assert.AreEqual(AgentCDS.Value, AGENT_VAL);
            Assert.AreEqual(OpportunityNameInput.Value, OPPORTUNITY_NAME);
            Assert.AreEqual(LeadTypeCDS.Value, LEAD_TYPE);
            Assert.AreEqual(LegalCustomerCDS.Value, LEGAL_CUSTOMER_VAL);
        }
        [SkipElement]
        public List<WebElement> TabButtons {
            get {
                return TryGetElements(By.CssSelector("#OpportunityPageV2TabsTabPanel-tabpanel-items>li"));
            }
        }
        [SkipElement]
        public WebElement NextScrollTabsRights {
            get {
                return TryGetElement(By.Id("OpportunityPageV2TabsTabPanel-scroll-right"));
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
                return TryGetElement(By.Id("OpportunityPageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement SaveRecordButton {
            get {
                return TryGetElement(By.Id("OpportunitySectionV2SaveRecordButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("OpportunitySectionV2CloseButtonButton-textEl"));
            }
        }

        public Input OpportunityNameInput {
            get {
                return TryGetElement(By.Id("OpportunityPageV2OpportunityTitleTextEdit-el")).ToInput();
            }
        }
        public ControlDropSelect LeadTypeCDS {
            get {
                return TryGetElement(By.Id("OpportunityPageV2OpportunityLeadTypeContainer_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect ClientCDS {
            get {
                return TryGetElement(By.Id("OpportunityPageV2OpportunityClientContainer_Control")).ToControlDropSelect();
            }
        }
        public WebElement NotDirectOpportunityBool {
            get {
                return TryGetElement(By.Id("OpportunityPageV2UsrIsNotDirectOpportunityCheckBoxEdit-wrapEl"));
            }
        }
        [SkipElement]
        public ControlDropSelect AgentCDS {
            get {
                return TryGetElement(By.Id("OpportunityPageV2LOOKUPb06c70af-997f-4446-8f79-0c4ceb9e5417Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect LegalCustomerCDS {
            get {
                return TryGetElement(By.Id("OpportunityPageV2UsrLegalCustomer8f82dc0e-9b34-4188-a74c-cfc337ff9769Container_Control")).ToControlDropSelect();
            }
        }
        public Input PossibleMargin {
            get {
                return TryGetElement(By.Id("OpportunityPageV2UsrTotalMargin35bec28f-5a9d-4bfc-86fa-891bda1f074aFloatEdit-el")).ToInput();
            }
        }
        public ControlDropSelect CurrencyCDS {
            get {
                return TryGetElement(By.Id("OpportunityPageV2LOOKUPf2b6c248-72de-495b-9cc1-6a84956aee58Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public Input PossibleMarginRub {
            get {
                return TryGetElement(By.Id("OpportunityPageV2UsrTotalMarginRub382a8722-cf22-4945-9100-bbdd1289cfc2FloatEdit-wrap")).ToInput();
            }
        }
        public WebElement CaseFeedPanelTabs {
            get {
                return TryGetElement(By.Id("OpportunityActionsDashboardTabsTabPanel-tabpanel-items"));
            }
        }
        public Input CloseDate {
            get {
                return TryGetElement(By.Id("OpportunityPageV2OpportunityDueDateDateEdit-el")).ToInput();
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
