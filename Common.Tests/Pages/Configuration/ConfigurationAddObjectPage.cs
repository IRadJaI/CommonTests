using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;

namespace Common.Tests.Pages {
    public class ConfigurationAddObjectPage : BasePage {
        public ConfigurationAddObjectPage(IWebDriver driver) : base(driver, pageIndicator: By.Id("ObjectInspectorLayout")) { }
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("SaveButton"));
            }
        }
        ObjectTree tree;
        public ObjectTree Tree {
            get{
                if(tree == null) {
                    tree = TryGetElement(By.Id("EntitySchemaTree"))
                        .ToObjectTree(this);
                }
                return tree;
            }
        }
        SchemaProperties propertiesTab;
        [SkipElement]
        public SchemaProperties PropertiesTab {
            get {
                if(propertiesTab == null) {
                    propertiesTab = TryGetElement(By.Id("EntitySchemaPropertiesTabPanel"))
                        .ToSchemaProperties(this);
                }
                return propertiesTab;
            }
        }
        QuestionAlert question;
        [SkipElement]
        public QuestionAlert Question {
            get {
                if(question == null) {
                    question = TryGetElement(By.ClassName("ext-mb-question"))
                        .ToQuestionAlert(this);
                }
                return question;
            }
        }
        [SkipElement]
        public InformationDialog SaveCompliteDialog {
            get {
                return TryGetElement(By.ClassName("ext-mb-info"))
                    .ToInformationDialog();
            }
        }
    }
}
