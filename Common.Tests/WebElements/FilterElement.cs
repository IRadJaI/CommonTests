using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public class FilterElement : WebElement {
        private const string ADD_CONDITION_LABEL = "Добавить условие";

        public FilterElement(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }

        [SkipElement]
        public WebElement FilterButton {
            get {
                return WebElementExtensions.ToWebElement(() => FindElement(By.ClassName("custom-filter-button-container")), Page);
            }
        }
        [SkipElement]
        public List<WebElement> FilterMenuItems {
            get {
                return Page.TryGetElements(By.CssSelector("ul.menu-wrap[data-item-marker=filterButton]>li.menu-item"))
                    .Select(e => WebElementExtensions.ToWebElement(() => e, Page)).ToList();
            }
        }
        
        [SkipElement]
        public List<CustomFilterItem> CustomFilterItems
        {
            get
            {
                return Page.TryGetElements(By.ClassName("filter-element-container-wrap"))
                    .Select(e => new CustomFilterItem(Page, () => e)).ToList();
            }
        }
        [SkipElement]
        public ControlDropSelect SearchColumnField {
            get {
                return Page.TryGetElement(By.CssSelector("[data-item-marker^=columnEdit]")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public WebElement DeleteFiltersButton {
            get {
                return WebElementExtensions.ToWebElement(
                    () => FindElement(By.ClassName("filter-remove-button")), Page);
            }
        }
        
        
        public void AddCondition() {
            FilterButton.Click();
            Thread.Sleep(1000);
            Executor.SpinWait(() => FilterMenuItems.Where(tb => tb.Text == ADD_CONDITION_LABEL).Count() == 1);
            FilterMenuItems.Single(tb => tb.Text == ADD_CONDITION_LABEL).Click();
        }
        public void SetFilterSearchingType(string SearchingType) {
            SearchColumnField.Value = SearchingType;
        }
    }
}
