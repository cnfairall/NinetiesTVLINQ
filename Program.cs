using NinetiesTV;
using System.Linq;

List<Show> shows = DataLoader.GetShows();

ResultPrinter.Print("All Names", Names(shows));
ResultPrinter.Print("Alphabetical Names", NamesAlphabetically(shows));
ResultPrinter.Print("Ordered by Popularity", ShowsByPopularity(shows));
ResultPrinter.Print("Shows with an '&'", ShowsWithAmpersand(shows));
ResultPrinter.Print("Latest year a show aired", MostRecentYear(shows));
ResultPrinter.Print("Average Rating", AverageRating(shows));
ResultPrinter.Print("Shows only aired in the 90s", OnlyInNineties(shows));
ResultPrinter.Print("Top Three Shows", TopThreeByRating(shows));
ResultPrinter.Print("Shows starting with 'The'", TheShows(shows));
ResultPrinter.Print("All But the Worst", AllButWorst(shows));
ResultPrinter.Print("Shows with Few Episodes", FewEpisodes(shows));
ResultPrinter.Print("Shows Sorted By Duration", ShowsByDuration(shows));
ResultPrinter.Print("Comedies Sorted By Rating", ComediesByRating(shows));
ResultPrinter.Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
ResultPrinter.Print("Most Episodes", MostEpisodes(shows));
ResultPrinter.Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
ResultPrinter.Print("Best Drama", BestDrama(shows));
ResultPrinter.Print("All But Best Drama", AllButBestDrama(shows));
ResultPrinter.Print("Good Crime Shows", GoodCrimeShows(shows));
ResultPrinter.Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
ResultPrinter.Print("Most Words in Title", WordieastName(shows));
ResultPrinter.Print("All Names", AllNamesWithCommas(shows));
ResultPrinter.Print("All Names with And", AllNamesWithCommasPlsAnd(shows));

/**************************************************************************************************
    The Exercises

    Above each method listed below, you'll find a comment that describes what the method should do.
    Your task is to write the appropriate LINQ code to make each method return the correct result.

**************************************************************************************************/

// 1. Return a list of each of show names.
static List<string> Names(List<Show> shows)
{
    return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
}

// 2. Return a list of show names ordered alphabetically.
static List<string> NamesAlphabetically(List<Show> shows)
{
    List<Show> names = shows.OrderBy(s => s.Name).ToList();
    return names.Select(s => s.Name).ToList();
}

// 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
static List<Show> ShowsByPopularity(List<Show> shows)
{
    return shows.OrderByDescending(s => s.ImdbRating).ToList();
}

// 4. Return a list of shows whose title contains an & character.
static List<Show> ShowsWithAmpersand(List<Show> shows)
{
    return shows.Where(s => s.Name.Contains('&')).ToList();
}

// 5. Return the most recent year that any of the shows aired.
static int MostRecentYear(List<Show> shows)
{
    List<Show> sortedByLatest = shows.OrderByDescending(s => s.EndYear).ToList();
    return sortedByLatest.First().EndYear;
}

// 6. Return the average IMDB rating for all the shows.
static double AverageRating(List<Show> shows)
{
    List<double> ratings = shows.Select(s => s.ImdbRating).ToList();
    return ratings.Average();
}

// 7. Return the shows that started and ended in the 90s.
static List<Show> OnlyInNineties(List<Show> shows)
{
    return shows.Where(s => s.StartYear > 1989 && s.EndYear < 2000).ToList();
}

// 8. Return the top three highest rated shows.
static List<Show> TopThreeByRating(List<Show> shows)
{
    List<Show> topShows = shows.OrderBy(s => s.ImdbRating).ToList();
    return topShows.Skip(shows.Count - 3).ToList();
}

// 9. Return the shows whose name starts with the word "The".
static List<Show> TheShows(List<Show> shows)
{
   return shows.Where(s => s.Name.StartsWith("The")).ToList();
}

// 10. Return all shows except for the lowest rated show.
static List<Show> AllButWorst(List<Show> shows)
{
    List<Show> almostAll = shows.OrderByDescending(s => s.ImdbRating).ToList();
    return almostAll.SkipLast(1).ToList();
}

// 11. Return the names of the shows that had fewer than 100 episodes.
static List<string> FewEpisodes(List<Show> shows)
{
    List<Show> shortRuns = shows.Where(s => s.EpisodeCount < 100).ToList();
    return shortRuns.Select(s => s.Name).ToList();
}

// 12. Return all shows ordered by the number of years on air.
//     Assume the number of years between the start and end years is the number of years the show was on.
static List<Show> ShowsByDuration(List<Show> shows)
{
    return shows.OrderBy(s => s.EndYear - s.StartYear).ToList();
}

// 13. Return the names of the comedy shows sorted by IMDB rating.
static List<string> ComediesByRating(List<Show> shows)
{
    List<Show> sortedComedies = shows.Where(s => s.Genres.Contains("Comedy")).OrderBy(s => s.ImdbRating).ToList();
    return sortedComedies.Select(s => s.Name).ToList();
}

// 14. Return the shows with more than one genre ordered by their starting year.
static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
{
    return shows.Where(s => s.Genres.Count > 1).OrderBy(s => s.StartYear).ToList();
}

// 15. Return the show with the most episodes.
static Show MostEpisodes(List<Show> shows)
{
    List<Show> mostEpisodes = shows.OrderByDescending(s => s.EpisodeCount).ToList();
    return mostEpisodes.First();
}

// 16. Order the shows by their ending year then return the first 
//     show that ended on or after the year 2000.
static Show EndedFirstAfterTheMillennium(List<Show> shows)
{
    List<Show> byEnding = shows.OrderBy(s => s.EndYear).ToList();
    return byEnding.First(s => s.EndYear >= 2000);
}

// 17. Order the shows by rating (highest first) 
//     and return the first show with genre of drama.
static Show BestDrama(List<Show> shows)
{
    List<Show> bestShows = shows.OrderByDescending(s => s.ImdbRating).ToList();
    return bestShows.First(s => s.Genres.Contains("Drama"));
}

// 18. Return all dramas except for the highest rated.
static List<Show> AllButBestDrama(List<Show> shows)
{
    List<Show> sortedDramas = shows.Where(s => s.Genres.Contains("Drama")).OrderByDescending(s => s.ImdbRating).ToList();
    return sortedDramas.Skip(10).ToList();
}

// 19. Return the number of crime shows with an IMDB rating greater than 7.0.
static int GoodCrimeShows(List<Show> shows)
{
    List<Show> crimeShows = shows.Where(s => s.Genres.Contains("Crime") && s.ImdbRating > 7).ToList();
    return crimeShows.Count;
}

// 20. Return the first show that ran for more than 10 years 
//     with an IMDB rating of less than 8.0 ordered alphabetically.
static Show FirstLongRunningTopRated(List<Show> shows)
{
    List<Show> longBadShows = shows.Where(s => s.EndYear -  s.StartYear > 10 && s.ImdbRating < 8).OrderBy(s => s.Name).ToList();
    return longBadShows.First();
}

// 21. Return the show with the most words in the name.
static Show WordieastName(List<Show> shows)
{
    List<Show> longNames = shows.OrderByDescending(s => s.Name.Split(" ").Length).ToList();

    Show wordiestShow = longNames.First();

    return wordiestShow;
}

// 22. Return the names of all shows as a single string seperated by a comma and a space.
static string AllNamesWithCommas(List<Show> shows)
{
 List<string> names = shows.Select(s => s.Name).ToList();
    string nameString = String.Join(", ", names);
    return nameString;

}

// 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
static string AllNamesWithCommasPlsAnd(List<Show> shows)
{
    List<string> names = shows.Select(s => s.Name).ToList();
    names.Insert(names.Count - 1, "and");
    string nameString = String.Join(", ", names);
    return nameString;
}


/**************************************************************************************************
    CHALLENGES

    These challenges are very difficult and may require you to research LINQ methods that we haven't
    talked about. Such as:

    GroupBy()
    SelectMany()
    Count()

**************************************************************************************************/

// 1. Return the genres of the shows that started in the 80s.
// 2. Print a unique list of geners.
// 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
// 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
// 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.



/**************************************************************************************************
 There is no code to write or change below this line, but you might want to read it.
**************************************************************************************************/
class ResultPrinter
{
    public static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

    public static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

    public static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

    public static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

    public static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

    public static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

    public static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
        Console.WriteLine("--------------------------------------------");
    }
}