using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using OTUS_Reflection;

//var sw100 = new Stopwatch();
//sw100.Start();
//for (var i = 0; i < 100; i++)
//{
//    var str =  MySerializer.Serialize(F.Get());
//}
//sw100.Stop();
//var sw100000 = new Stopwatch();
//sw100000.Start();
//for (var i = 0; i < 100000; i++)
//{
//    var str =  MySerializer.Serialize(F.Get());
//}
//sw100000.Stop();
//Console.WriteLine($"{nameof(sw100)}: {sw100.ElapsedTicks}");
//Console.WriteLine($"{nameof(sw100000)}: {sw100000.ElapsedTicks}");

var sw100JsonSerializer = new Stopwatch();
sw100JsonSerializer.Start();
for (var i = 0; i < 100; i++)
{
    var str =  JsonSerializer.Serialize(F.Get());
    Console.WriteLine(str);
}
sw100JsonSerializer.Stop();
var sw100000JsonSerializer = new Stopwatch();
sw100000JsonSerializer.Start();
for (var i = 0; i < 100000; i++)
{
    var str =  MySerializer.Serialize(F.Get());
    Console.WriteLine(str);
}
sw100000JsonSerializer.Stop();
Console.WriteLine($"{nameof(sw100JsonSerializer)}: {sw100JsonSerializer.ElapsedTicks}");
Console.WriteLine($"{nameof(sw100000JsonSerializer)}: {sw100000JsonSerializer.ElapsedTicks}");

var sw100Deserialize = new Stopwatch();
var jsonString = MySerializer.Serialize(F.Get());
sw100Deserialize.Start();
for (var i = 0; i < 100; i++)
{
    var obj = MySerializer.Deserialize<F>(jsonString);
}
sw100Deserialize.Stop();

var sw10000Deserialize = new Stopwatch();
sw10000Deserialize.Start();
for (var i = 0; i < 10000; i++)
{
    var obj = MySerializer.Deserialize<F>(jsonString);
}
sw10000Deserialize.Stop();
Console.WriteLine($"{nameof(sw100Deserialize)}: {sw100Deserialize.ElapsedTicks}");
Console.WriteLine($"{nameof(sw10000Deserialize)}: {sw10000Deserialize.ElapsedTicks}");