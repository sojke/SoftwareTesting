﻿Console.WriteLine("Wat is je naam?");
var name = Console.ReadLine();
Console.WriteLine("Hoe vaak wil je deze naam tonen?");
var repeat = int.Parse(Console.ReadLine());
for (int i = 0; i < repeat; i++)
{
    Console.WriteLine(name);
}
Console.ReadLine();
