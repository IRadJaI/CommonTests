using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class OpportunitiesPage : BPMInternalBasePage {
        [SkipElement]
        public List<OpportunityItem> OpportunitiesList {
            get {
                return TryGetElements(By.CssSelector("#grid-OpportunitySectionV2DataGridGrid-wrap .grid-listed-row"))
                .Select(we => new OpportunityItem(this, () => we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> OpportunitiesTiles {
            get {
                return TryGetElements(By.CssSelector("#grid-OpportunitySectionV2DataGridGrid-wrap .grid-row"));
            }
        }
        [SkipElement]
        public List<WebElement> OpportunitiesActionButtons {
            get {
                return TryGetElements(By.CssSelector(".grid-row-actions .t-btn-wrapper"));
            }
        }
        public WebElement AddOpportunityButton {
            get {
                return WebElementExtensions.ToWebElement(() => 
                    TryGetElement(By.Id("OpportunitySectionV2SeparateModeAddRecordButtonButton-textEl")),this);
            }

        }
        public FilterElement Filter {
            get {
                return new FilterElement(this, () => TryGetElement(By.Id("QuickFilterModuleContainer")));
            }
        }
        [SkipElement]
        public Input OpportunitiesFilterSearchField {
            get {
                return new Input(this, 
                    () => TryGetElement(By.Id("customFilterSectionModuleV2_OpportunitySectionV2_QuickFilterModuleV2-el")));
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
        public OpportunitiesPage(IWebDriver driver) : base(driver) { }
    }
    public class OpportunityItem : WebElement {
        public WebElement EditLink { get { return WebElementExtensions.ToWebElement(() => 
            Element.FindElement(By.CssSelector("a[data-column^=Name]")), Page); } }
        public OpportunityItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {}
    }
}