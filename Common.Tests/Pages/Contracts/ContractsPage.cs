using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class ContractsPage : BPMInternalBasePage {
        [SkipElement]
        public List<ContactItem> ContractsList {
            get {
                return TryGetElements(By.CssSelector("#grid-ContractSectionV2DataGridGrid-wrap .grid-listed-row"))
                .Select(we => new ContactItem(this, () => we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> ContractsTiles {
            get {
                return TryGetElements(By.CssSelector("#grid-ContractSectionV2DataGridGrid-wrap .grid-row"));
            }
        }
        [SkipElement]
        public List<WebElement> ContractsActionButtons {
            get {
                return TryGetElements(By.CssSelector(".grid-row-actions .t-btn-wrapper"));
            }
        }
        public WebElement AddContractButton {
            get {
                return WebElementExtensions.ToWebElement(() =>
                    TryGetElement(By.Id("ContractSectionV2SeparateModeAddRecordButtonButton-textEl")), this);
            }

        }
        public FilterElement Filter {
            get {
                return new FilterElement(this, () => TryGetElement(By.Id("QuickFilterModuleContainer")));
            }
        }
        [SkipElement]
        public Input ContractsFilterSearchField {
            get {
                return new Input(this,
                    () => TryGetElement(By.Id("customFilterSectionModuleV2_ContractSectionV2_QuickFilterModuleV2-el")));
            }
        }
        [SkipElement]
        public WebElement ModalMsgBox {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.ClassName("ts-messagebox-box")), this);
            }
        }
        [SkipElement]
        public WebElement FilterCloseButton {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.ClassName("filter-remove-button")), this);
            }
        }
        public ContractsPage(IWebDriver driver) : base(driver) { }
    }
    public class ContractItem : WebElement {
        public WebElement EditLink {
            get {
                return WebElementExtensions.ToWebElement(() =>
                Element.FindElement(By.CssSelector("a[data-column^=Name]")), Page);
            }
        }
        public ContractItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
    }
}