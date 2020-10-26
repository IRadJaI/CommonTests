using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.Pages {
    public class BPMSystemDesignerPage : BPMInternalBasePage {
        public BPMSystemDesignerPage(IWebDriver driver) : base(driver) { }
        List<ContentTileElement> contentBlockElements;
        [SkipElement]
        public List<ContentTileElement> ContentBlocks {
            get {
                if (contentBlockElements == null) {
                    contentBlockElements = TryGetElements(By.ClassName("tile"))
                        .Select(iw => new ContentTileElement(this, () => iw)).ToList();
                }
                return contentBlockElements;
            }
        }
    }
}
