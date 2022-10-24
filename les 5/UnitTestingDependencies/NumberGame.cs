using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDependencies;

public class NumberGame
{
    private readonly IDie die;
    public NumberGame(IDie die)
    {
        this.die = die;
    }

    public int RateGuess(int guess)
    {
        var result = die.Roll();
        if (result == guess)
        {
            return 2;
        }
        if (result - 1 == guess || result + 1 == guess)
        {
            return 1;
        }
        return 0;
    }
}
