using OpenQA.Selenium;

public class WikipediaPage
{
    private IWebDriver driver;

    public WikipediaPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void NavigateTo(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public void ClickRandomLink()
    {
        var links = driver.FindElements(By.CssSelector("a[href^='/wiki/']"));
        var random = new Random();
        var randomLink = links[random.Next(links.Count)];
        randomLink.Click();
    }

    public void ClickPhilosophyLink()
    {
        var philosophyLinks = driver.FindElements(By.XPath("//a[@href='/wiki/Philosophy']"));
        if (philosophyLinks.Count > 0)
        {
            philosophyLinks.First().Click();
        }
    }

    public void GoBack()
    {
        driver.Navigate().Back();
    }
}