using System;
using System.Diagnostics;
using System.Drawing;
namespace TelCo.ColorCoder
{
    public class ColorCodePairHelperTests
    {
        static ColorCodePairHelper colorCodePairHelper;
        private static void Main(string[] args)
        {
            colorCodePairHelper = new ColorCodePairHelper();
            ExecuteColorFromPairNumberTests();
            ExecutePairNumberFromColorTests();
        }
        private static void ExecuteColorFromPairNumberTests()
        {
            int pairNumber = 4;
            ColorCode testPair1 = colorCodePairHelper.GetColorCodeFromPairNumber(pairNumber);
            Console.WriteLine(GetFormattedMessage( pairNumber, testPair1));
            Debug.Assert(testPair1.MajorColor == Color.White && testPair1.MinorColor == Color.Brown);
            pairNumber = 5;
            testPair1 = colorCodePairHelper.GetColorCodeFromPairNumber(pairNumber);
            Console.WriteLine(GetFormattedMessage(pairNumber, testPair1));
            Debug.Assert(testPair1.MajorColor == Color.White && testPair1.MinorColor == Color.SlateGray);
            pairNumber = 23;
            testPair1 = colorCodePairHelper.GetColorCodeFromPairNumber(pairNumber);
            Console.WriteLine(GetFormattedMessage(pairNumber, testPair1));
            Debug.Assert(testPair1.MajorColor == Color.Violet && testPair1.MinorColor == Color.Green);
        }
        private static void ExecutePairNumberFromColorTests()
        {
            ColorCode testPair2 = new ColorCode() { MajorColor = Color.Yellow, MinorColor = Color.Green };
            int pairNumber = colorCodePairHelper.GetPairNumberFromColorCode(testPair2);
            Console.WriteLine(GetFormattedMessage(testPair2, pairNumber));
            Debug.Assert(pairNumber == 18);
            testPair2 = new ColorCode() { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = colorCodePairHelper.GetPairNumberFromColorCode(testPair2);
            Console.WriteLine(GetFormattedMessage(testPair2, pairNumber));
            Debug.Assert(pairNumber == 6);
        }
        private static string GetFormattedMessage(int pairNumber,ColorCode colorCodePair)
        {
            return string.Format("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, colorCodePair);
        }
        private static string GetFormattedMessage(ColorCode colorCodePair, int pairNumber)
        {
            return string.Format("[In]Colors: {0}, [Out] PairNumber: {1}", colorCodePair, pairNumber);
        }
    }
}