

using BenchmarkDotNet.Running;
using hedgehog;

int neededHedgehog = 2;
                       
var hedgehogPopulation = new List<int> { 456, 153, 4 };

var ServiceHedgehog = new ServiceHedgehog();

var countOperation = ServiceHedgehog.MinimumMeetings(neededHedgehog, hedgehogPopulation);

Console.WriteLine(countOperation);
