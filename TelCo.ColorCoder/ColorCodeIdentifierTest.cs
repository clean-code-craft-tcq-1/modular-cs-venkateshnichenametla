using System;
using System.Diagnostics;
using System.Drawing;
namespace TelCo.ColorCoder
{
    public class ColorCodeIdentifierTest
    {
        private static void Main(string[] args)
        {
            ColorCodeIdentifier colorCodeIdentifier = new ColorCodeIdentifier();
            int pairNumber = 4;
            ColorCode testPair1 = colorCodeIdentifier.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White);
            Debug.Assert(testPair1.MinorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = colorCodeIdentifier.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White);
            Debug.Assert(testPair1.MinorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = colorCodeIdentifier.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.Violet);
            Debug.Assert(testPair1.MinorColor == Color.Green);

            ColorCode testPair2 = new ColorCode() { MajorColor = Color.Yellow, MinorColor = Color.Green };
            pairNumber = colorCodeIdentifier.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorCode() { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = colorCodeIdentifier.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}