using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// The 25-pair color code, originally known as even-count color code, 
    /// is a color code used to identify individual conductors in twisted-pair 
    /// wiring for telecommunications.
    /// This class provides the color coding and 
    /// mapping of pair number to color and color to pair number.
    /// </summary>
    class ColorCodeIdentifier
    {
        internal static string GetColorCodeReference()
        {
            StringBuilder colorCodeReferenceManual = new StringBuilder();
            int pairNumber = 1;
            colorCodeReferenceManual.AppendLine("PairNumber : Major Color - Minor Color" + Environment.NewLine);
            for (int i = 0; i < ColorCode.ColorMapMajor.Length; i++)
            {
                for (int j = 0; j < ColorCode.ColorMapMinor.Length; j++)
                {
                    colorCodeReferenceManual.AppendLine(string.Format("{0} : {1} - {2}", pairNumber, ColorCode.ColorMapMajor[i].Name, ColorCode.ColorMapMinor[j].Name));
                    pairNumber++;
                }
            }
            return colorCodeReferenceManual.ToString();
        }

        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        internal static ColorCode GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorCode.ColorMapMinor.Length;
            int majorSize = ColorCode.ColorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;
            ColorCode pair = new ColorCode()
            {
                MajorColor = ColorCode.ColorMapMajor[majorIndex],
                MinorColor = ColorCode.ColorMapMinor[minorIndex]
            };
            return pair;
        }

        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        internal static int GetPairNumberFromColor(ColorCode pair)
        {
            int majorIndex = -1;
            for (int i = 0; i < ColorCode.ColorMapMajor.Length; i++)
            {
                if (ColorCode.ColorMapMajor[i] == pair.MajorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            int minorIndex = -1;
            for (int i = 0; i < ColorCode.ColorMapMinor.Length; i++)
            {
                if (ColorCode.ColorMapMinor[i] == pair.MinorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            }
            return (majorIndex * ColorCode.ColorMapMinor.Length) + (minorIndex + 1);
        }

        private static void Main(string[] args)
        {
            int pairNumber = 4;
            ColorCode testPair1 = GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White);
            Debug.Assert(testPair1.MinorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.White);
            Debug.Assert(testPair1.MinorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}", pairNumber, testPair1);
            Debug.Assert(testPair1.MajorColor == Color.Violet);
            Debug.Assert(testPair1.MinorColor == Color.Green);

            ColorCode testPair2 = new ColorCode() { MajorColor = Color.Yellow, MinorColor = Color.Green };
            pairNumber = GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorCode() { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}