using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class InvoicesPage : BPMInternalBasePage {
        [SkipElement]
        public List<InvoiceItem> InvoicesList {
            get {
                return TryGetElements(By.CssSelector("#grid-InvoiceSectionV2DataGridGrid-wrap .grid-listed-row"))
                .Select(we => new InvoiceItem(this, () => we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> InvoicesTiles {
            get {
                return TryGetElements(By.CssSelector("#grid-InvoiceSectionV2DataGridGrid-wrap .grid-row"));
            }
        }
        [SkipElement]
        public List<WebElement> InvoicesActionButtons {
            get {
                return TryGetElements(By.CssSelector(".grid-row-actions .t-btn-wrapper"));
            }
        }
        public WebElement AddInvoiceButton {
            get {
                return WebElementExtensions.ToWebElement(() => 
                    TryGetElement(By.Id("InvoiceSectionV2SeparateModeAddRecordButtonButton-textEl")),this);
            }

        }
        public FilterElement Filter {
            get {
                return new FilterElement(this, () => TryGetElement(By.Id("QuickFilterModuleContainer")));
            }
        }
        [SkipElement]
        public Input InvoicesFilterSearchField {
            get {
                return new Input(this, 
                    () => TryGetElement(By.Id("customFilterSectionModuleV2_InvoiceSectionV2_QuickFilterModuleV2-el")));
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
        public InvoicesPage(IWebDriver driver) : base(driver) { }
    }
    public class InvoiceItem : WebElement {
        public WebElement EditLink { get { return WebElementExtensions.ToWebElement(() => 
            Element.FindElement(By.CssSelector("a[data-column^=Name]")), Page); } }
        public InvoiceItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {}
    }
}