using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class BPMLeadsPage : BPMInternalBasePage {
        [SkipElement]
        public List<LeadItem> LeadsList {
            get {
                return TryGetElements(By.CssSelector("#grid-LeadSectionV2DataGridGrid-wrap .grid-listed-row"))
                .Select(we => new LeadItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> LeadsTiles {
            get {
                return TryGetElement(By.Id("grid-LeadSectionV2DataGridGrid-wrap"))
                .FindElements(By.ClassName("grid-row"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        [SkipElement]
        public List<LeadItem> LeadsTilesOld {
            get {
                return TryGetElements(By.ClassName("grid-listed-row"))
                .Select(we => new LeadItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> LeadActionButtons {
            get {
                return TryGetElement(By.ClassName("grid-row-actions"))
                .FindElements(By.ClassName("t-btn-wrapper"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        public WebElement AddLeadButton {
            get {
                return TryGetElement(By.Id("LeadSectionV2SeparateModeAddRecordButtonButton-textEl"));
            }

        }
        public FilterElement Filter {
            get {
                return new FilterElement(this, () => TryGetElement(By.Id("QuickFilterModuleContainer")));
            }
        }
        [SkipElement]
        public Input LeadsFilterSearchField {
            get {
                return new Input(this,
                    () => TryGetElement(By.Id("customFilterSectionModuleV2_LeadSectionV2_QuickFilterModuleV2-el")));
            }
        }
        [SkipElement]
        public WebElement DeleteFiltersButton {
            get {
                return TryGetElement(By.ClassName("filter-remove-button"));
            }
        }
        [SkipElement]
        public WebElement ModalMsgBox {
            get {
                return TryGetElement(By.ClassName("ts-messagebox-box"));
            }
        }
        public BPMLeadsPage(IWebDriver driver) : base(driver) { }
    }
    public class LeadItem : WebElement {
        public WebElement ActiveSelectable { get { return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("grid-cols-4")), Page); } }
        public LeadItem(BasePage page, IWebElement element) : base(page, () => element) {
        }
    }
}
