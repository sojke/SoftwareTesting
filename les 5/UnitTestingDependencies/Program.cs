// See https://aka.ms/new-console-template for more information
using UnitTestingDependencies;

var die = new Die();
var numberGame = new NumberGame(die);
var score = numberGame.RateGuess(5);
Console.WriteLine($"Uw score: {score}");
