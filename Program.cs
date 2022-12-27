using Async_Await;

Console.WriteLine("Alright Async Await!");

Console.WriteLine();
Console.WriteLine($"{Log.TimeNow} 01 Global");
var knuth = new Knuth();
await knuth.Example();
Console.WriteLine($"{Log.TimeNow} 02 Global");

Console.WriteLine();
Console.WriteLine($"{Log.TimeNow} 03 Global");
var knuthIl = new KnuthIl();
await knuthIl.Example();
Console.WriteLine($"{Log.TimeNow} 04 Global");

Console.WriteLine();
Console.WriteLine($"{Log.TimeNow} 05 Global");
var graham = new Graham();
await graham.Example();
Console.WriteLine($"{Log.TimeNow} 06 Global");

Console.WriteLine();
Console.WriteLine($"{Log.TimeNow} 07 Global");
var grahamIl = new GrahamIl();
await grahamIl.Example();
Console.WriteLine($"{Log.TimeNow} 08 Global");