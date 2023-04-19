using OpenQA.Selenium;

public class WikipediaPage
{
    private IWebDriver driver;

    public WikipediaPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void GoToUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public void ClickRandomLink()
    {
        // finds all links on the page with href starts with "wiki"
        var links = driver.FindElements(By.CssSelector("a[href^='/wiki/']"));
        // from previous step  choose link in click on it
        var random = new Random();
        var randomLink = links[random.Next(links.Count)];
        randomLink.Click();
    }

    public void ClickPhilosophyLink()
    {
        // Find the first link which his href equal to "wiki/Philosophy"

        var philosophyLinks = driver.FindElements(By.XPath("//a[@href='/wiki/Philosophy']"));
        if (philosophyLinks.Count > 0)
        {
            //click on first philosophy link found
            philosophyLinks.First().Click();
        }
    }

    public void GoBack()
    {
        driver.Navigate().Back();
    }
}