using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace CommentBot
{
    class Program
    {    
        static void Main(string[] args)
        {
            string postLink;
            string userName;
            string password;
       


            Console.WriteLine("Enter the post link: ");
            postLink = Console.ReadLine();

            Console.WriteLine("Enter the username: ");
            userName = Console.ReadLine();

            Console.WriteLine("Enter the password: ");
            password = Console.ReadLine();

            Console.WriteLine("Bot Started!");

            InitAttack(postLink, userName, password);

        }


        private static void InitAttack(string PL,string UN, string Pass)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");

            IWebDriver webDriver = new ChromeDriver(@"C:\ChromeDriver", options);

            //LOGIN
            webDriver.Navigate().GoToUrl(PL);
            webDriver.FindElement(By.Name("email")).SendKeys(UN);
            webDriver.FindElement(By.Name("pass")).SendKeys(Pass);
            webDriver.FindElement(By.Id("loginbutton")).Click();
            Thread.Sleep(2000);
            webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[2]/div[2]/div/div/div/div/div/div/div/div[1]/div/div[2]/div[2]/form/div/div[2]/div[2]/div/span[2]/a")).
            Click();
            Thread.Sleep(10000);
            Random _random = new Random();

            for (int a = 0; a < 500; a++)
            {
                webDriver.SwitchTo().ActiveElement().SendKeys(GetRandomSentence(_random.Next(3, 10)) + $"({a + 1})");
                Thread.Sleep(500);
                webDriver.SwitchTo().ActiveElement().SendKeys(Keys.Return);
                Thread.Sleep(1000);
            }
        }
        static string GetRandomSentence(int wordCount)
        {
            Random random = new Random();
            string[] words = { "an", "automobile", "or", "motor", "car", "is", "a", "wheeled", "motor", "vehicle", "used", "for",
                "transporting", "passengers", "which", "also", "carries", "its", "own", "engine", "or" };

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < wordCount; i++)
            {
                // Select a random word from the array
                builder.Append(words[random.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim() + ". ";

            // Set the first letter of the first word in the sentenece to uppercase
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
        }
    }
    
}
