using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BowlingScores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            var bowlerNameScore = new Dictionary<string, int>();
            while (true)
            {
                Console.WriteLine("Please enter your Name");
                var bowlerName = Console.ReadLine();
                if (bowlerNameScore.ContainsKey(bowlerName))
                {
                    Console.WriteLine("Bowler names must be unique, please pick a new name");
                    continue;
                }else if(bowlerName == ""){
                    var max = -1;
                    var min = 301;
                    var sum = 0;
                    var highScorers = new List<string>();
                    var lowScorers = new List<string>();
                    foreach (KeyValuePair<string,int> kvp in bowlerNameScore)
                    {
                        if(kvp.Value > max)
                        {
                            max = kvp.Value;
                            highScorers.Clear();
                            highScorers.Add(kvp.Key);
                        }else if(kvp.Value == max)
                        {
                            highScorers.Add(kvp.Key);
                        }
                        if(kvp.Value < min)
                        {
                            min = kvp.Value;
                            lowScorers.Clear();
                            lowScorers.Add(kvp.Key);
                        }
                        else if(kvp.Value == min)
                        {
                            lowScorers.Add(kvp.Key);
                        }

                        sum += kvp.Value;
                    }
                    var avg = sum / bowlerNameScore.Count;
                    if(highScorers.Count == 1)
                    {
                        Console.WriteLine($"High Score {highScorers.First()}:{max}");

                    }
                    else
                    {
                        foreach(var name in highScorers)
                        {
                            Console.WriteLine($"High Scores {name}: {max}");
                        }
                    }
                    if (lowScorers.Count == 1)
                    {
                        Console.WriteLine($"low Score {lowScorers.First()}:{min}");

                    }
                    else
                    {
                        foreach (var name in lowScorers)
                        {
                            Console.WriteLine($"low Scores {name}: {min}");
                        }
                    }
 
                    Console.WriteLine($"Average Score: {avg}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter your score");
                    var bowlerScore = int.Parse(Console.ReadLine());
                    if(bowlerScore > 300 || bowlerScore < 0)
                    {
                        Console.WriteLine("This Score is not possible");
                        continue;
                    }
                    bowlerNameScore.Add(bowlerName, bowlerScore);
                }
                
            }
        }
    }
}
