using System;

namespace Minesweeper.Helper;

public static class RandomProvider
{ 
    static RandomProvider()
    {
        Random = new Random();
    }

    public static Random Random { get; }
}