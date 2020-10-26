using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class BPMActivitiesPage : BPMInternalBasePage {
        [SkipElement]
        public List<ActivityItem> ActivitiesList {
            get {
                return TryGetElements(By.CssSelector("#grid-ActivitySectionV2DataGridGrid-wrap .grid-listed-row"))
                .Select(we => new ActivityItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> ActivitiesTiles {
            get {
                return TryGetElement(By.Id("grid-ActivitySectionV2DataGridGrid-wrap"))
                .FindElements(By.ClassName("grid-row"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        [SkipElement]
        public List<ActivityItem> ActivitiesTilesOld {
            get {
                return TryGetElements(By.ClassName("grid-listed-row"))
                .Select(we => new ActivityItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> ActivityActionButtons {
            get {
                return TryGetElement(By.ClassName("grid-row-actions"))
                .FindElements(By.ClassName("t-btn-wrapper"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        public WebElement AddActivityButton {
            get {
                return TryGetElement(By.Id("ActivitySectionV2SeparateModeAddRecordButtonButton-textEl"));
            }
        }
        public WebElement ActivityListViewButton {
            get {
                return TryGetElement(By.Id("view-button-GridDataView-imageEl"));
            }
        }
        public FilterElement Filter {
            get {
                return new FilterElement(this, () => TryGetElement(By.Id("QuickFilterModuleContainer")));
            }
        }
        [SkipElement]
        public Input ActivitiesFilterSearchField {
            get {
                return new Input(this,
                    () => TryGetElement(By.Id("customFilterSectionModuleV2_ActivitySectionV2_QuickFilterModuleV2-el")));
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
        public BPMActivitiesPage(IWebDriver driver) : base(driver) { }
    }
    public class ActivityItem : WebElement {
        public WebElement ActiveSelectable { get { return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("grid-primary-column")), Page); } }
        public ActivityItem(BasePage page, IWebElement element) : base(page, () => element) {
        }
    }
}
