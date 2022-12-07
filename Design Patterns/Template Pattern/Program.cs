using System;

namespace Template_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sourdought sourdought = new Sourdought();
            sourdought.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
