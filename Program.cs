using Async_Await;

Console.WriteLine("Alright Async Await!");

/*Console.WriteLine();
Console.WriteLine("01 Global - Knuth");
var knuth = new Knuth();
await knuth.Example();
Console.WriteLine("02 Global");

Console.WriteLine();
Console.WriteLine("03 Global - Knuth IL");
var knuthIl = new KnuthIl();
await knuthIl.Example();
Console.WriteLine("04 Global");

Console.WriteLine();
Console.WriteLine("05 Global - Graham");
var graham = new Graham();
await graham.Example();
Console.WriteLine("06 Global");

Console.WriteLine();
Console.WriteLine("07 Global - Graham IL");
var grahamIl = new GrahamIl();
await grahamIl.Example();
Console.WriteLine("08 Global");

Console.WriteLine();
Console.WriteLine("09 Global - Riemann");
var riemann = new Riemann();
await riemann.Example();
Console.WriteLine("10 Global");

Console.WriteLine();
Console.WriteLine("11 Global - Riemann IL");
var riemannIt = new RiemannIl();
await riemannIt.Example();
Console.WriteLine("11 Global");

Console.WriteLine();
Console.WriteLine("12 Global - Conway");
var conway = new Conway();
await conway.Example();
Console.WriteLine("13 Global");

Console.WriteLine();
Console.WriteLine("14 Global - Conway IL");
var conwayIl = new ConwayIl();
await conwayIl.Example();
Console.WriteLine("15 Global");

Console.WriteLine();
Console.WriteLine("16 Global - Conway Clean Code");
var conwayCleanCode = new ConwayCleanCode();
await conwayCleanCode.Example();
Console.WriteLine("17 Global");*/

Console.WriteLine();
Console.WriteLine("18 Global - Planck");
var planck = new Planck();
var result = await planck.Example();
Console.WriteLine($"19 Global: {result}");