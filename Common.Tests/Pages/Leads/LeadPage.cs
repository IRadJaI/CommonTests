using Common.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Tests.WebElements;
using Common.Tests.Base;

namespace Common.Tests.Pages.Leads {
    public class BPMLeadPage : BPMInternalBasePage {

        public BPMLeadPage(IWebDriver driver) : base(driver) { }
        public ControlDropSelect DepartmentCDS {
            get {
                return TryGetElement(By.Id("LeadPageV2UsrLeadDepartment6800cfd2-8e35-4c6b-94a7-047d855e9982Container_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect VendorCDS {
            get {
                return TryGetElement(By.Id("LeadPageV2UsrLeadVendorbafe7919-6923-44c5-b4db-eef4d8d8bc7fContainer_Control")).ToControlDropSelect();
            }
        }
        public WebElement CaseFeedPanelTabs {
            get {
                return TryGetElement(By.Id("LeadSectionActionsDashboardTabsTabPanel-tabpanel-items"));
            }
        }
        [SkipElement]
        public WebElement AddContactButton {
            get {
                return TryGetElement(By.Id("LeadContactProfileSchemaFindButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement ModalSelectContactBox {
            get {
                return TryGetElement(By.ClassName("ts-modalbox"));
            }
        }
        [SkipElement]
        public Input ContactNameInput {
            get {
                return TryGetElement(By.Id("searchEdit-el")).ToInput();
            }
        }
        [SkipElement]
        public List<ContactItem> ContactsGridList {
            get {
                return TryGetElements(By.ClassName("grid-listed-row"))
                .Select(we => new ContactItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public WebElement ConfirmSelectedContactButton {
            get {
                return TryGetElement(By.CssSelector("span[data-tag^=SelectButton]"));
            }
        }
        public Input ContactFIOInput {
            get {
                return TryGetElement(By.Id("LeadPageV2ContactTextEdit-el")).ToInput();
            }
        }
        public Input AccountNameInput {
            get {
                return TryGetElement(By.Id("LeadPageV2AccountTextEdit-el")).ToInput();
            }
        }
        public Input MobilePhoneInput {
            get {
                return TryGetElement(By.Id("LeadPageV2MobilePhoneTextEdit-el")).ToInput();
            }
        }
        public Input EmailInput {
            get {
                return TryGetElement(By.Id("LeadPageV2EmailTextEdit-el")).ToInput();
            }
        }
        public Input FullJobPositionInput {
            get {
                return TryGetElement(By.Id("LeadPageV2FullJobTitle8ff59c45-bdeb-4cab-a622-1999b4df12a7TextEdit-el")).ToInput();
            }
        }
        public Input WebInput {
            get {
                return TryGetElement(By.Id("LeadPageV2WebsiteTextEdit-el")).ToInput();
            }
        }
        public ControlDropSelect EmployeesCountCDS {
            get {
                return TryGetElement(By.Id("LeadPageV2EmployeesNumberContainer_Control")).ToControlDropSelect();
            }
        }
        public Input WorkPhoneInput {
            get {
                return TryGetElement(By.Id("LeadPageV2BusinesPhone137c74e1-b590-47bd-afff-e8228bf96409TextEdit-el")).ToInput();
            }
        }
        public ControlDropSelect RegionCDS {
            get {
                return TryGetElement(By.Id("LeadPageV2Regiond67567fc-5f19-4e55-a635-ff8fd7b2916eContainer_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect LeadTypeCDS {
            get {
                return TryGetElement(By.Id("LeadPageV2LeadType4ead281b-55c5-49fd-83e8-f90dba16bcc5Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("LeadPageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("LeadSectionV2CloseButtonButton-textEl"));
            }
        }
    }
    public class CommunicationItem : WebElement {
        public CommunicationItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public Input input {
            get {
                return new Input(Page, () => Element.FindElement(By.CssSelector("input")));
            }
        }
    }
    public class ContactItem : WebElement {
        public WebElement PrimaryColumn { get { return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("grid-primary-column")), Page); } }
        public ContactItem(BasePage page, IWebElement element) : base(page, () => element) {
        }
    }
}