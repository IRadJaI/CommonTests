using Common.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Tests.WebElements;
using Common.Tests.Base;

namespace Common.Tests.Pages.Activities {
    public class BPMActivityPage : BPMInternalBasePage {

        public BPMActivityPage(IWebDriver driver) : base(driver) { }
        
        [SkipElement]
        public WebElement ModalSelectContactBox {
            get {
                return TryGetElement(By.ClassName("ts-modalbox"));
            }
        }
        public Input ActivityNameInput {
            get {
                return TryGetElement(By.Id("ActivityPageV2TitleMemoEdit-el")).ToInput();
            }
        }
        public ControlDropSelect ActivityStateCDS {
            get {
                return TryGetElement(By.Id("ActivityPageV2Status0810f3f5-838d-41dc-b3fa-7d058fd002e5Container_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect ActivityPriorityCDS {
            get {
                return TryGetElement(By.Id("ActivityPageV2PriorityContainer_Control")).ToControlDropSelect();
            }
        }
        public ControlDropSelect ActivityCategoryCDS {
            get {
                return TryGetElement(By.Id("ActivityPageV2ActivityCategoryContainer_Control")).ToControlDropSelect();
            }
        }
        public Input ActivityDescriptionInput {
            get {
                return TryGetElement(By.Id("ActivityPageV2Usropisaniebeb4d671-2439-4258-897d-665f7702331bMemoEdit-el")).ToInput();
            }
        }
        public ControlDropSelect ActivityResultCDS {
            get {
                return TryGetElement(By.Id("ActivityPageV2ResultContainer_Control")).ToControlDropSelect();
            }
        }
        public Input ActivityResultAdvancedInput {
            get {
                return TryGetElement(By.Id("ActivityPageV2DetailedResultMemoEdit-el")).ToInput();
            }
        }
        [SkipElement]
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("ActivityPageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("ActivitySectionV2CloseButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement SaveRecordButton {
            get {
                return TryGetElement(By.Id("ActivitySectionV2SaveRecordButtonButton-textEl"));
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
    public class ContactItem : WebElement {
        public WebElement PrimaryColumn { get { return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("grid-primary-column")), Page); } }
        public ContactItem(BasePage page, IWebElement element) : base(page, () => element) {
        }
    }
}