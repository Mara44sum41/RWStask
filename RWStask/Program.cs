using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class Program
{
    static void Main()
    {
        // new instance of chrome
        var driver = new ChromeDriver();
        
        // create a new  wikipediaPage instance using chromedrive instance
        var wikipediaPage = new WikipediaPage(driver);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        // Navigate to the Wikipedia 
        wikipediaPage.GoToUrl("https://en.wikipedia.org/wiki/Special:Random");
        //wikipediaPage.GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
     

        var reached = false;
        var redirects = 0;
        while (!reached)
        {
            try
            {
                //  Click on a random link on the current page
                wikipediaPage.ClickRandomLink();
            }
            catch (ElementNotInteractableException)
            {
                // If the random link is not clickable, go back to the previous page
                wikipediaPage.GoBack();
                continue;
            }

            // Keep track of the number of redirects
            redirects++;

            // Click on the philosophy link on the current page
            wikipediaPage.ClickPhilosophyLink();
            if (driver.Url.EndsWith("/Philosophy")) //If the current URL ends with "Philosophy"
            {
                reached = true; //Set "reached" to true

                // Output the number of redirects needed to reach the philosophy page

                Console.Clear();
                Console.WriteLine($"Philosophy found after {redirects} redirects.");
                Console.ReadKey();
            }
        }
        driver.Quit();
    }
}
