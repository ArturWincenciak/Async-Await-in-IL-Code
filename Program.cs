using Async_Await;

Console.WriteLine("Alright Async Await!");

Console.WriteLine();
Console.WriteLine("01 Global");
var knuth = new Knuth();
await knuth.Example();
Console.WriteLine("02 Global");

Console.WriteLine();
Console.WriteLine("03 Global");
var knuthIl = new KnuthIl();
await knuthIl.Example();
Console.WriteLine("04 Global");

Console.WriteLine();
Console.WriteLine("05 Global");
var graham = new Graham();
await graham.Example();
Console.WriteLine("06 Global");

Console.WriteLine();
Console.WriteLine("07 Global");
var grahamIl = new GrahamIl();
await grahamIl.Example();
Console.WriteLine("08 Global");