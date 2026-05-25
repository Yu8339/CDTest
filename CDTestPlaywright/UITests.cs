using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTestPlaywright
{
    public  class UITests : PageTest
    {

        [Fact]
        public async Task Test_UI()
        {
            //var playwrightCore = await Microsoft.Playwright.Playwright.CreateAsync();
            //var launchOptions = new BrowserTypeLaunchOptions
            //{
            //    Headless = false,
            //    SlowMo = 1500
            //};

            //await using var browser = await playwrightCore.Chromium.LaunchAsync(launchOptions);
            //var page = await browser.NewPageAsync();

            // 步驟 1：打開網頁 (網址請依你 .NET 專案實際啟動的 port 調整，通常是 5000 或 5173)
            await Page.GotoAsync("http://localhost:5114");

            // 步驟 2：利用網頁上的 id (NumA 和 NumB) 輸入模擬數字
            // Playwright 會自動等待網頁載入完成才輸入
            await Page.Locator("#NumA").FillAsync("1");
            await Page.Locator("#NumB").FillAsync("2");

            // 步驟 3：模擬點擊「計算」按鈕
            // 這裡用文字搜尋按鈕，語意非常直覺
            await Page.Locator("button:has-text('計算')").ClickAsync();

            // 步驟 4：驗證結果是否正確
            // 尋找 class 為 text-primary 的 h2 標籤，確認裡面的文字是「計算結果123：46」
            await Expect(Page.Locator("h2.text-primary"))
                .ToHaveTextAsync("計算結果123：3");
        }
    }


}
