using Common.Tests.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages {
    public class BPMWelcomePage : BPMInternalBasePage {
        public BPMWelcomePage(IWebDriver driver) : base(driver) { }
        List<ContentTileElement> contentBlockElements;
        [SkipElement]
        public List<ContentTileElement> ContentBlocks { 
            get {
                if(contentBlockElements == null) {
                    contentBlockElements = TryGetElements(By.ClassName("tile"))
                        .Select(iw => new ContentTileElement(this, () => iw)).ToList();
                }
                return contentBlockElements;
            } 
        }
    }
}
