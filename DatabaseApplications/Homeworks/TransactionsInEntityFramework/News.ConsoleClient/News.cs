namespace News.ConsoleClient
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    class News
    {
        static void Main(string[] args)
        {
            var contextOne = new NewsContext();
            var contextTwo = new NewsContext();

            ConcurrencyTest(contextOne, contextTwo);
        }

        static void ConcurrencyTest(NewsContext contextOne, NewsContext contextTwo)
        {
            var originalNews = contextTwo.News.Find(1);
            var contextOneNews = contextOne.News.Find(1);

            Console.WriteLine("Application started.\nText from DB: {0}\nEnter the corrected text:", contextOneNews.Content);

            string firstUserInput = Console.ReadLine();

            Console.WriteLine("User input: {0}", firstUserInput);
            contextOneNews.Content = firstUserInput;
            contextOne.SaveChanges();
            Console.WriteLine("Changes successfully saved in the DB.");
  
            var contextTwoNews = contextTwo.News.Find(1);

            Console.WriteLine("Application started.\nText from DB: {0}\nEnter the corrected text:", originalNews.Content);

            string secondUserInput = Console.ReadLine();

            contextTwoNews.Content = secondUserInput;

            try
            {
                contextTwo.SaveChanges();
                Console.WriteLine("Changes successfully saved in the DB.");
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Conflict! Text from DB: {0}. Enter the corrected text:", contextOneNews.Content);

                string secondUserSecondTry = Console.ReadLine();

                var newContextTwo = new NewsContext();
                var newContextTwoNews = newContextTwo.News.Find(1);

                newContextTwoNews.Content = secondUserSecondTry;
                newContextTwo.SaveChanges();
                Console.WriteLine("Changes successfully saved in the DB.");
            }
        }
    }
}
