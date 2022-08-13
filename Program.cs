
/// <summary>
/// Sales predictor.
/// Predicts sales based on 3 factors compared to stats
/// </summary>

List<Stat> statList = new List<Stat>();

statList.Add(new Stat { WeatherRating = 1, IsSpecialDay = 1, TotalSale = 100, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 2, IsSpecialDay = 1, TotalSale = 50, WeekEnd = 0 });
statList.Add(new Stat { WeatherRating = 3, IsSpecialDay = 1, TotalSale = 150, WeekEnd = 0 });
statList.Add(new Stat { WeatherRating = 4, IsSpecialDay = 1, TotalSale = 200, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 5, IsSpecialDay = 1, TotalSale = 300, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 1, IsSpecialDay = 0, TotalSale = 20, WeekEnd = 0 });
statList.Add(new Stat { WeatherRating = 2, IsSpecialDay = 0, TotalSale = 120, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 3, IsSpecialDay = 0, TotalSale = 100, WeekEnd = 0 });
statList.Add(new Stat { WeatherRating = 4, IsSpecialDay = 0, TotalSale = 150, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 5, IsSpecialDay = 0, TotalSale = 100, WeekEnd = 0 });
statList.Add(new Stat { WeatherRating = 5, IsSpecialDay = 1, TotalSale = 250, WeekEnd = 0 });
statList.Add(new Stat { WeatherRating = 5, IsSpecialDay = 1, TotalSale = 280, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 5, IsSpecialDay = 1, TotalSale = 280, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 5, IsSpecialDay = 1, TotalSale = 280, WeekEnd = 1 });
statList.Add(new Stat { WeatherRating = 4, IsSpecialDay = 0, TotalSale = 250, WeekEnd = 1 });

Console.WriteLine("Please enter the weather rating from 1 to 5 for the day");        
int weatherRating = int.Parse(Console.ReadLine()); // Get input for weather rating
Console.WriteLine("Please enter 1 if the day is special or otherwise 0");
int isSpecialday = int.Parse(Console.ReadLine()); // Get whether its a special day or not
Console.WriteLine("Please enter 1 if the day is on weekend or otherwise 0");
int weekend = int.Parse(Console.ReadLine()); // Get whether its week end or week day

List<(Stat, double distance)> distance = new List<(Stat, double)>();

foreach (var stat in statList)
{
    double distanceValue = Math.Sqrt((Math.Pow(stat.WeatherRating - weatherRating, 2)) + (Math.Pow(stat.IsSpecialDay - isSpecialday, 2)) + (Math.Pow(stat.WeekEnd = weekend, 2)));
    distance.Add((stat, distanceValue));

}

int neighbours = 6;

distance = distance.OrderBy(d => d.distance).Take(neighbours).ToList(); // take 6 neares neighbours 

double averageSale = 0;

averageSale = distance.Sum(d => d.Item1.TotalSale)/ neighbours; // calculate average sale

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Average sale: {Math.Ceiling(averageSale)}"); // take ceil value
Console.ForegroundColor = ConsoleColor.White;


class Stat
{
    public int WeatherRating;
    public int WeekEnd;
    public int IsSpecialDay;
    public int TotalSale;
}
