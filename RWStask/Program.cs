using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        // new instance of chrome
        var driver = new ChromeDriver();
        
        // create a new  wikipediaPage instance using chromedrive instance
        var wikipediaPage = new WikipediaPage(driver);
        
        // Navigate to the Wikipedia main page
        wikipediaPage.GoToUrl("https://en.wikipedia.org/Main_Page");

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
