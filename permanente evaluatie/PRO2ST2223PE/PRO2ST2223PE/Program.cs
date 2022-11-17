using System;

namespace PRO2ST2223PE;

class Program
{
    static void Main(string[] args)
    {
        BoredService boredService = new BoredService(new Random(), new BoredApiService());
        boredService.BoredVullen();
        Console.WriteLine(boredService.BoredRandom());
    }
}
