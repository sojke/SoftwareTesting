using System;

namespace PRO2ST2223PE;

public class BoredService
{
    private Random random;
    private IBoredApiService boredApiService;
    public BoredService(Random random, IBoredApiService boredApiService)
    {
        this.random = random;
        this.boredApiService = boredApiService;
    }
    public void BoredVullen()
    {
        BoredInMemoryDb.boredResponses.Clear();
        for (int i = 0; i < 10; i++)
        {
            BoredInMemoryDb.boredResponses.Add(boredApiService.GetBoredResponse());
        }
    }
    public string BoredRandom()
    {
        BoredResponse boredResponse = BoredInMemoryDb.boredResponses[random.Next(10)];
        if (boredResponse.Participants > 2)
        {
            return $"I don't have enough friends to => {boredResponse.Activity}";
        }
        else
        {
            return $"Let's do some => {boredResponse.Activity}";
        }
    }
}
