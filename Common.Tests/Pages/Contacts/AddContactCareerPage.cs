using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;

namespace Common.Tests.Pages.Contacts
{
    public class AddContactCareerPage : BPMInternalBasePage
    {
        internal AddContactCareerPage(IWebDriver driver) : base(driver) {

        }
        internal WebElement SaveButton
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2SaveButtonButton-textEl"));
            }
        }

        internal WebElement AddNameInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2ContactLookupEdit-link-el"));
            }
        }
        internal ControlDropSelect AddCareerInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2JobContainer_Control")).ToControlDropSelect();
            }
        }
        internal ControlDropSelect AddDepartmentInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2DepartmentContainer_Control")).ToControlDropSelect();
            }
        }
        internal WebElement AddCareerStartDateInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2StartDateDateEdit-el"));
            }
        }
        internal ControlDropSelect AddJobChangeReasonInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2JobChangeReasonContainer_Control")).ToControlDropSelect();
            }
        }
        internal Input AddDescriptionInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2DescriptionMemoEdit-el")).ToInput();
            }
        }
        internal ControlDropSelect AddRoleInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2DecisionRoleContainer_Control")).ToControlDropSelect();
            }
        }
        internal WebElement AddDueDateInput
        {
            get
            {
                return TryGetElement(By.Id("ContactCareerPageInContactV2DueDateDateEdit-el"));
            }
        }
        internal void DataFilling()
        {
            AddCareerInput.Value ="Руководитель отдела";

            AddDepartmentInput.Value ="Разработка";

            AddJobChangeReasonInput.Value ="Интересная работа";

            AddDescriptionInput.Value ="Описание";
            Driver.WaitForReady();

            AddRoleInput.Value ="Исполнитель";

            AddDueDateInput.SendKeys(DateTime.Today.ToString("dd.MM.yyyy"));
            Driver.WaitForReady();
        }
    }
}
