using System;
using System.Diagnostics;
using System.Drawing;
namespace TelCo.ColorCoder
{
    public class ColorCodeMapperTests
    {
        static ColorCodeMapper colodCodeMapper;
        private static void Main(string[] args)
        {
            colodCodeMapper = new ColorCodeMapper();
            ExecuteColorFromPairNumberTests();
            ExecutePairNumberFromColorTests();
        }
        private static void ExecuteColorFromPairNumberTests()
        {
            int pairNumber = 4;
            ColorCode testPair1 = colodCodeMapper.GetColorCodeFromPairNumber(pairNumber);
            DisplayMessageInConsole(pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White && testPair1.MinorColor == Color.Brown);
            pairNumber = 5;
            testPair1 = colodCodeMapper.GetColorCodeFromPairNumber(pairNumber);
            DisplayMessageInConsole(pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White && testPair1.MinorColor == Color.SlateGray);
            pairNumber = 23;
            testPair1 = colodCodeMapper.GetColorCodeFromPairNumber(pairNumber);
            DisplayMessageInConsole(pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.Violet && testPair1.MinorColor == Color.Green);
        }
        private static void ExecutePairNumberFromColorTests()
        {
            ColorCode testPair2 = new ColorCode() { MajorColor = Color.Yellow, MinorColor = Color.Green };
            int pairNumber = colodCodeMapper.GetPairNumberFromColorCode(testPair2);
            DisplayMessageInConsole(testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);
            testPair2 = new ColorCode() { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = colodCodeMapper.GetPairNumberFromColorCode(testPair2);
            DisplayMessageInConsole(testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
        private static void DisplayMessageInConsole(int pairNumber, ColorCode colorCodePair)
        {
            Console.WriteLine(string.Format("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, colorCodePair));
        }
        private static void DisplayMessageInConsole(ColorCode colorCodePair, int pairNumber)
        {
            Console.WriteLine(string.Format("[In]Colors: {0}, [Out] PairNumber: {1}", colorCodePair, pairNumber));
        }
    }
}