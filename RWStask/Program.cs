using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V110.WebAuthn;

class Program
{
    static void Main()
    {
        var driver = new ChromeDriver();
        var wikipediaPage = new WikipediaPage(driver);

        wikipediaPage.NavigateTo("https://en.wikipedia.org/…age");

        var reached = false;
        var redirects = 0;
        while (!reached)
        {
            try
            {
                wikipediaPage.ClickRandomLink();
            }
            catch (ElementNotInteractableException)
            {
                wikipediaPage.GoBack();
                continue;
            }

            redirects++;
            wikipediaPage.ClickPhilosophyLink();
            if (driver.Url.EndsWith("/Philosophy"))
            {
                reached = true;
                Console.Clear();
                Console.WriteLine($"Philosophy found after {redirects} redirects.");
                Console.ReadKey();
            }
        }
        driver.Quit();
    }
}
