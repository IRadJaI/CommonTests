using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;

namespace Common.Tests.Pages.Accounts {
    public class AddStructurePage : BPMInternalBasePage {
        public AddStructurePage(IWebDriver driver) : base(driver) {

        }
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("AccountOrganizationChartPageV2SaveButtonButton-textEl"));
            }
        }

        public ControlDropSelect AddDepartmentInput {
            get {
                return TryGetElement(By.Id("AccountOrganizationChartPageV2DepartmentContainer_Control")).ToControlDropSelect();
            }
        }
        public Input Description {
            get {
                return TryGetElement(By.Id("AccountOrganizationChartPageV2DescriptionMemoEdit-el")).ToInput();
            }
        }
    }
}
