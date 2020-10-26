using Common.Tests.Base;
using Common.Tests.WebElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Common.Tests.Pages.Contracts {
    public class ContractPage : BPMInternalBasePage {
        public const string ACCOUNT_VAL = "Ингейт Ingate";
        public const string ORGANIZATION_VAL = "ООО \"Перемена Трейд\"";
        public const string LEGAL_CUSTOMER_VAL = "ООО \"ИГД\"";
        public const string CONTRACT_VER_VAL = "Microsoft CSP";

        public const string STAGE_PREPARE_VAL = "Подготовка";
        public const string STAGE_AGREEMENT_VAL = "Согласование";
        public const string STAGE_AWAITING_CUSTOMER_VAL = "Ожидает подписания клиентом";
        public const string FILES_TABNAME = "ФАЙЛЫ И ПРИМЕЧАНИЯ";
        public const string VISA_TABNAME = "СОГЛАСОВАНИЕ";

        public ContractPage(IWebDriver driver) : base(driver) {
        }
        public void DataFilling() {
            AccountDropSelect.Value = ACCOUNT_VAL;
            OrganizationDropSelect.Value = ORGANIZATION_VAL;
            LegalCustomerDropSelect.Value = LEGAL_CUSTOMER_VAL;
            ContractVerDropSelect.Value = CONTRACT_VER_VAL;
            Thread.Sleep(2000);
            SaveButton.Click();
            Assert.AreEqual(ModalMsgBox.Text, "По данному юридическому лицу уже создан годовой договор! 1 (Microsoft CSP) Продолжить сохранение? ДАНЕТ");
        }
        string isNull(string str) {
            if (str != null) {
                return str;
            }
            else {
                return "null";
            }
        }
        public void OpenTab(string TabName) {
            const int MAX_ITERATIONS = 20;
            Executor.SpinWait(() => TabButtons.Any(tb => tb.Displayed));
            for (int iterator = 0; iterator <= MAX_ITERATIONS && !TabButtons.Any(tb => tb.Text.Contains(TabName)); iterator++) {
                NextScrollTabsRights.Click();
            }
            TabButtons.Single(tb => tb.Text.Contains(TabName)).Click();
        }
        public WebElement ApproveButton {
                get {
                    return TryGetElement(By.CssSelector("span[data-item-marker^=ApproveButton"));
                }
            }
        [SkipElement]
        public List<DetailTilesListElement> ContractVisaDetailTiles {
            get {
                return TryGetElements(By.CssSelector("#grid-VisaDetailV2DataGridGrid-wrap .grid-row.grid-pad")).Select(dtl => dtl.ToDetailTiles()).ToList();
            }
        }
        [SkipElement]
        public WebElement ContractPageV2VisaContainer {
            get {
                return TryGetElement(By.Id("ContractPageV2VisaContainer"));
            }
        }
        [SkipElement]
        public WebElement ContractPageV2FilesContainer {
            get {
                return TryGetElement(By.Id("ContractPageV2FilesContainer"));
            }
        }
        [SkipElement]
        public WebElement AddFileButton {
            get {
                return TryGetElement(By.Id("FileDetailV2AddRecordButtonButton-wrapperEl"));
            }
        }
        [SkipElement]
        public WebElement ActionFileButton {
            get {
                return TryGetElement(By.CssSelector("#FileDetailV2DetailControlGroup-tools span[data-item-marker^=ToolsButton")); 
            }
        }
        [SkipElement]
        public List<DetailTilesListElement> ContractFileDetailTiles {
            get {
                return TryGetElements(By.CssSelector("#grid-FileDetailV2DataGridGrid-wrap .grid-row.grid-pad")).Select(dtl => dtl.ToDetailTiles()).ToList();
            }
        }
        [SkipElement]
        public List<WebElement> ContractDetailActions {
            get {
                return TryGetElement(By.CssSelector("ul[data-item-marker^=ToolsButton]"))
                .FindElements(By.ClassName("menu-item"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        [SkipElement]
        public WebElement AddFileInput {
            get {
                return TryGetElement(By.Id("FileDetailV2AddRecordButtonButton-fileupload"));
            }
        }
        [SkipElement]
        public List<WebElement> TabButtons {
            get {
                return TryGetElements(By.CssSelector("#ContractPageV2TabsTabPanel-tabpanel-items>li"));
            }
        }
        [SkipElement]
        public WebElement NextScrollTabsRights {
            get {
                return TryGetElement(By.Id("ContractPageV2TabsTabPanel-scroll-right"));
            }
        }
        [SkipElement]
        public WebElement FeedNewMessageSubmitButton {
            get {
                return TryGetElement(By.CssSelector(".postMessage span[data-item-marker^=publishPostMessageButton]"));
            }
        }
        [SkipElement]
        public CKEEditor FeedNewMessageEditor {
            get {
                return new CKEEditor(this, () => TryGetElement(By.ClassName("social-message-edit-container")), TryGetElement(By.CssSelector(".social-message-edit-container textarea")).GetAttribute("id"));
            }
        }

        [SkipElement]
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("ContractPageV2SaveButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement ModalMsgBox {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.ClassName("ts-messagebox-box")), this);
            }
        }
        [SkipElement]
        public WebElement CloseButton {
            get {
                return TryGetElement(By.Id("ContractSectionV2CloseButtonButton-textEl"));
            }
        }
        [SkipElement]
        public WebElement PrintButton {
            get {
                return TryGetElement(By.CssSelector("span[data-item-marker^=PrintButton]"));
            }
        }
        [SkipElement]
        public WebElement CombinedModePrintButton {
            get {
                return TryGetElement(By.CssSelector("span[data-item-marker^=CombinedModePrintButton]"));
            }
        }
        [SkipElement]
        public ControlDropSelect AccountDropSelect {
            get {
                return TryGetElement(By.Id("ContractPageV2AccountLookupEdit-wrap")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect OrganizationDropSelect {
            get {
                //return TryGetElement(By.Id("ContractPageV2LOOKUP893b2693-c615-4d2c-b911-061c28f0189dContainer_Control")).ToControlDropSelect();
                return TryGetElement(By.Id("ContractPageV2UsrOrganizatione440808f-c2eb-4414-ba3f-fde05e3794a0Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect LegalCustomerDropSelect {
            get {
                return TryGetElement(By.Id("ContractPageV2LOOKUP3f97bf5c-2899-4614-b67c-92d27de6ffaeContainer_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect ContractVerDropSelect {
            get {
                return TryGetElement(By.Id("ContractPageV2LOOKUPd5a7d08b-0083-48cd-8cd7-724d33fd0ca3Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect UsrPaymentsTermsDropSelect { //Условия оплаты
            get {
                return TryGetElement(By.Id("ContractPageV2LOOKUPd99ae273-ee16-49cf-b3f1-ec2169250c08Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect UsrContractTemplateDropSelect { //Шаблон
            get {
                return TryGetElement(By.Id("ContractPageV2LOOKUPab29aeca-4b30-471d-892b-5be195bc0b23Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect UsrSubscriberDropSelect { //Подписант
            get {
                return TryGetElement(By.Id("ContractPageV2LOOKUP3db45047-fdb4-4d3d-984d-43035c3da294Container_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public ControlDropSelect CurrencyDropSelect { //Валюта
            get {
                return TryGetElement(By.Id("ContractPageV2LOOKUP9bc933d3-96fc-4546-ac47-23858e5f4b2bContainer_Control")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public Input SumInput { //Сумма
            get {
                return TryGetElement(By.Id("ContractPageV2FLOATfb84149f-23c5-4523-83ea-90ace97d8560FloatEdit-el")).ToInput();
            }
        }
        
        [SkipElement]
        public Input UsrPaymentDaysInput { //Оплата в течение, дни
                get {
                    return TryGetElement(By.Id("ContractPageV2INTEGERf126a3f6-3765-462c-832a-aca7333479d7IntegerEdit-el")).ToInput();
                }
            }
        [SkipElement]
        public Input UsrShippingDaysInput { //Срок исполнения, дни
                get {
                    return TryGetElement(By.Id("ContractPageV2INTEGER1b26f744-f9e4-4a86-b1aa-910b1adcb662IntegerEdit-el")).ToInput();
                }
            }
        public List<WebElement> SectionActionsDashboardStages {
            get {
                return TryGetElement(By.CssSelector("#DcmActionsDashboardModule #SectionActionsDashboardActionsControlContainer-wrap"))
                .FindElements(By.ClassName("stage-item"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        [SkipElement]
        public WebElement ContractActionsButton {
            get {
                return TryGetElement(By.Id("ContractSectionV2CombinedModeActionsButtonButton-wrapperEl"));
            }
        }
        [SkipElement]
        public List<WebElement> ContractActionsCombinedMode {
            get {
                return TryGetElement(By.CssSelector("ul[data-item-marker^=CombinedModeActionsButton]"))
                .FindElements(By.ClassName("menu-item"))
                .Select(iw => new WebElement(this, () => iw))
                .ToList();
            }
        }
        public WebElement HeaderCaption {
            get {
                return TryGetElement(By.Id("MainHeaderSchemaPageHeaderCaptionLabel"));
            }
        }
    }
}
