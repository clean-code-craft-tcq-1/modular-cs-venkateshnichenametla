using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TelCo.ColorCoder
{
    public class ColorCodeIdentifier
    {
        private Dictionary<int, ColorCode> ColorCodeReferences { get; set; }
        public ColorCodeIdentifier()
        {
            ColorCodeReferences = new Dictionary<int, ColorCode>();
            int pairNumber = 1;
            for (int i = 0; i < ColorCode.ColorMapMajor.Length; i++)
            {
                for (int j = 0; j < ColorCode.ColorMapMinor.Length; j++)
                {
                    ColorCodeReferences.Add(pairNumber, new ColorCode() { MajorColor = ColorCode.ColorMapMajor[i], MinorColor = ColorCode.ColorMapMinor[j] });
                    pairNumber++;
                }
            }
        }
        internal string GetColorCodeReferenceManual()
        {
            StringBuilder colorCodeReferenceManual = new StringBuilder();
            colorCodeReferenceManual.AppendLine("PairNumber : Major Color - Minor Color");
            foreach (KeyValuePair<int, ColorCode> colorCodeReference in ColorCodeReferences)
            {
                colorCodeReferenceManual.AppendLine(string.Format("{0} : {1} - {2}", colorCodeReference.Key, colorCodeReference.Value.MajorColor, colorCodeReference.Value.MinorColor));
            }
            return colorCodeReferenceManual.ToString();
        }
        internal ColorCode GetColorFromPairNumber(int pairNumber)
        {
            if (!ColorCodeReferences.ContainsKey(pairNumber))
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            return ColorCodeReferences[pairNumber];
        }
        internal int GetPairNumberFromColor(ColorCode pair)
        {
            if (ColorCodeReferences.Where(x => x.Value.MajorColor.Equals(pair.MajorColor) && x.Value.MinorColor.Equals(pair.MinorColor)).Count() == 0)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            return ColorCodeReferences.FirstOrDefault(x => x.Value.MajorColor.Equals(pair.MajorColor) && x.Value.MinorColor.Equals(pair.MinorColor)).Key;
        }
    }
}