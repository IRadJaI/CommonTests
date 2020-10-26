using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class BPMAccountsPage : BPMInternalBasePage {
        [SkipElement]
        public List<AccountItem> AccountsList {
            get {
                return TryGetElements(By.CssSelector("#grid-AccountSectionV2DataGridGrid-wrap .grid-listed-row"))
                .Select(we => new AccountItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> AccountsTiles {
            get {
                return TryGetElement(By.Id("grid-AccountSectionV2DataGridGrid-wrap"))
                .FindElements(By.ClassName("grid-row"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        [SkipElement]
        public List<AccountItem> AccountsTilesOld {
            get {
                return TryGetElements(By.ClassName("grid-listed-row"))
                .Select(we => new AccountItem(this, we)).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> AccountActionButtons {
            get {
                return TryGetElement(By.ClassName("grid-row-actions"))
                .FindElements(By.ClassName("t-btn-wrapper"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        public WebElement AddAccountButton {
            get {
                return TryGetElement(By.Id("AccountSectionV2SeparateModeAddRecordButtonButton-textEl"));
            }

        }
        public FilterElement Filter {
            get {
                return new FilterElement(this, () => TryGetElement(By.Id("QuickFilterModuleContainer")));
            }
        }
        [SkipElement]
        public Input AccountsFilterSearchField {
            get {
                return new Input(this,
                    () => TryGetElement(By.Id("customFilterSectionModuleV2_AccountSectionV2_QuickFilterModuleV2-el")));
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
        public BPMAccountsPage(IWebDriver driver) : base(driver) { }
    }
    public class AccountItem : WebElement {
        public WebElement EditLink { get { return WebElementExtensions.ToWebElement(() => Element.FindElement(By.CssSelector("a[data-column^=Name]")), Page); } }
        public AccountItem(BasePage page, IWebElement element) : base(page, () => element) {
        }
    }
}
