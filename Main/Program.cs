using AOC_2022.Day_1;
using AOC2022.Day_3;
using AOC2022.Day_4;
using AOC2022.Day2;

var startTime = DateTime.Now;
DateTime previousTime = startTime;
DateTime time;
#region Day 4
Console.WriteLine("------------------------");
Console.WriteLine("Day 4");
Console.WriteLine("totalFullyContainedPairs: " + Day4.AmountOfFullyContained());
Console.WriteLine("totalOverlaps: " + Day4.AmountOfOverlaps());
time = DateTime.Now;
Console.WriteLine("runTime: " + (time - previousTime).Milliseconds + "ms");
previousTime = time;
#endregion

#region Day 3
Console.WriteLine("------------------------");
Console.WriteLine("Day 3");
Console.WriteLine("prioritySum: " + Day3.GetPrioritySum());
Console.WriteLine("badgeSum: " + Day3.GetBadgeGroupSum());
time = DateTime.Now;
Console.WriteLine("runTime: " + (time - previousTime).Milliseconds + "ms");
previousTime = time;
#endregion

#region Day 2
Console.WriteLine("------------------------");
Console.WriteLine("Day 2");
Console.WriteLine("onMatch: " + Day2.CalculateStrategyPoints());
Console.WriteLine("onResult: " + Day2.CalculateStrategyPoints(true));
time = DateTime.Now;
Console.WriteLine("runTime: " + (time - previousTime).Milliseconds + "ms");
previousTime = time;
#endregion

#region Day 1
Console.WriteLine("------------------------");
Console.WriteLine("Day 1");
Console.WriteLine("sumCalories " + Day1.GetTopCalories());
Console.WriteLine("SumCaloriesTop3: " + Day1.GetTopCalories(3));
time = DateTime.Now;
Console.WriteLine("runTime: " + (time - previousTime).Milliseconds + "ms");
Console.WriteLine("------------------------");
#endregion

time = DateTime.Now;
Console.Write("totalRunTime: " + (time - startTime).Milliseconds + "ms");