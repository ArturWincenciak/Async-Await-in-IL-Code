using Async_Await;

Console.WriteLine("Alright Async Await!");

Console.WriteLine();
Console.WriteLine($"{Log.TimeNow} 01 Global");
var joy = new Joy();
await joy.Example();
Console.WriteLine($"{Log.TimeNow} 02 Global");

Console.WriteLine();
Console.WriteLine($"{Log.TimeNow} 03 Global");
var joyIl = new JoyIl();
await joyIl.Example();
Console.WriteLine($"{Log.TimeNow} 04 Global");