using AOC_2022.Day_1;
using AOC2022.Day_3;
using AOC2022.Day_4;
using AOC2022.Day_5;
using AOC2022.Day_6;
using AOC2022.Day2;

var startTime = DateTime.Now;
var previousTime = startTime;
DateTime time;

#region Day 6
Console.WriteLine("------------------------");
Console.WriteLine("Day 6");
Console.WriteLine("getStartOfPacketWith4: " + Day6.GetStartOfPacket(4));
Console.WriteLine("getStartOfPacketWith14: " + Day6.GetStartOfPacket(14));
time = DateTime.Now;
Console.WriteLine("runTime: " + (time - previousTime).Milliseconds + "ms");
previousTime = time;
#endregion

#region Day 5
Console.WriteLine("------------------------");
Console.WriteLine("Day 5");
Console.WriteLine("getTopOrder: " + Day5.GetTopOrder());
Console.WriteLine("getTopOrderCrateMover9001: " + Day5.GetTopOrder(true));
time = DateTime.Now;
Console.WriteLine("runTime: " + (time - previousTime).Milliseconds + "ms");
previousTime = time;
#endregion

#region Day 4
Console.WriteLine("------------------------");
Console.WriteLine("Day 4");
Console.WriteLine("totalFullyContainedPairs: " + Day4.GetTotal(true));
Console.WriteLine("totalOverlaps: " + Day4.GetTotal());
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