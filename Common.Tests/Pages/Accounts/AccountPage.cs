using Common.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Tests.WebElements;
using Common.Tests.Base;

namespace Common.Tests.Pages.Accounts {
    public class BPMAccountPage : BPMInternalBasePage {

        public BPMAccountPage(IWebDriver driver) : base(driver) { }
        public Input AccountNameInput {
            get {
                return TryGetElement(By.Id("AccountPageV2AccountNameTextEdit-el")).ToInput();
            }
        }
        public ControlDropSelect RegionCDS {
            get {
                return TryGetElement(By.Id("AccountPageV2Regionac14a373-cccc-4136-846e-ac02bc01d9c7Container_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect TypeCDS {
            get {
                return TryGetElement(By.Id("AccountPageV2AccountTypeContainer_Control")).ToControlDropSelect();
            }
        }
        public WebElement CaseFeedPanelTabs {
            get {
                return TryGetElement(By.Id("SectionActionsDashboardTabsTabPanel-tabpanel-items"));
            }
        }
        [SkipElement]
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("AccountPageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public ControlDropSelect PCCountCDS {
            get {
                return TryGetElement(By.Id("AccountPageV2UsrPCkoldb2b3c70-a39b-443f-bfb0-4119a24b0eb6Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect EmployeeCountCDS {
            get {
                return TryGetElement(By.Id("AccountPageV2EmployeesNumberde1bae2f-e25c-4e89-831d-d57f1cfb6f70Container_Control")).ToControlDropSelect();
            }
        }
        public Input WebInput {
            get {
                return TryGetElement(By.Id("AccountPageV2AccountWebTextEdit-el")).ToInput();
            }
        }
        [SkipElement]
        public ControlDropSelect IndustryCDS {
            get {
                return TryGetElement(By.Id("AccountPageV2Industrya9f87a79-9115-4a6b-acc9-a3a43687f864Container_Control")).ToControlDropSelect();
            }
        }
        public Input MainPhone {
            get {
                return TryGetElement(By.Id("AccountPageV2AccountPhoneTextEdit-el")).ToInput();
            }
        }
        [SkipElement]
        public WebElement ModalMsgBox {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.ClassName("ts-messagebox-box")), this);
            }
        }
        [SkipElement]
        public Input CategoryInput {
            get {
                return TryGetElement(By.Id("AccountPageV2NewAccountCategoryComboBoxEdit-el")).ToInput();
            }
        }
        [SkipElement]
        public ControlDropSelect ClassificationInput {
            get {
                return TryGetElement(By.Id("AccountPageV2Usrclassifa8be4c7c-6919-4dd7-9c70-baea2c4d54e9Container_Control")).ToControlDropSelect();
            }
        }
        public WebElement AddConnectionTypeButton {
            get {
                return TryGetElement(By.Id("AccountCommunicationDetailAddButtonButton-wrapperEl"));
            }
        }
        [SkipElement]
        public List<WebElement> AddConnectionActions {
            get {
                return TryGetElements(By.CssSelector("ul[data-item-marker^=AddTypedRecordButton] li")).ToList();
            }
        }
        [SkipElement]
        public List<CommunicationItem> AccountCommunicationDetail {
            get {
                return TryGetElement(By.Id("AccountCommunicationDetailDetailControlGroup"))
                    .FindElements(By.CssSelector("#AccountCommunicationDetailCommunicationsContainerContainerList>div"))
                    .Select(we => new CommunicationItem(this, () => we))
                    .ToList();
            }
        }
        public WebElement AddBirtdayButton {
            get {
                return TryGetElement(By.Id("AccountAnniversaryDetailV2AddTypedRecordButtonButton-imageEl"));
            }
        }
        [SkipElement]
        public List<WebElement> MenuElements {
            get {
                return TryGetElements(By.CssSelector(".menu-wrap .menu-item"));
            }
        }
        [SkipElement]
        public List<WebElement> TabButtons {
            get {
                return TryGetElements(By.CssSelector("#AccountPageV2TabsTabPanel-tabpanel-items>li"));
            }
        }
        [SkipElement]
        public WebElement NextScrollTabsRights {
            get {
                return TryGetElement(By.Id("AccountPageV2TabsTabPanel-scroll-right"));
            }
        }
        [SkipElement]
        public WebElement AddStructureButton {
            get {
                return TryGetElement(By.Id("AccountOrganizationChartDetailV2AddRecordButton-imageEl"));
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("AccountPageV2CloseButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement OrganizationUnit {
            get {
                return TryGetElement(By.Id("grid-AccountOrganizationChartDetailV2DataGridGrid-wrap"));
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
}