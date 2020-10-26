using Common.Tests.Base;
using Common.Tests.WebElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Common.Tests.Pages.Contracts {
    public class ContractLawyerVisaPage : BPMInternalBasePage {
        public const string COMMENT_VAL = "Любой комментарий";
        public ContractLawyerVisaPage(IWebDriver driver) : base(driver) {
        }
        [SkipElement]
        public WebElement SaveButton { //Сохранить
            get {
                return TryGetElement(By.Id("f073e66a-36ec-47d7-9c6a-e5952dbf05a3-textEl"));
            }
        }
        [SkipElement]
        public Input CommentInput { //Комментарий
            get {
                return TryGetElement(By.Id("UsrLawyerVisaPageSTRING7200d022-36e6-4280-b401-6a3d09663b24MemoEdit-el")).ToInput();
            }
        }
    }  
}
