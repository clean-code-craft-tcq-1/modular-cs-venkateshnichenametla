using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TelCo.ColorCoder
{
    public class ColorCodeMapper
    {
        private Dictionary<int, ColorCode> colorCodeReferences { get; set; }
        public ColorCodeMapper()
        {
            colorCodeReferences = new Dictionary<int, ColorCode>();
            int pairNumber = 1;
            for (int i = 0; i < ColorCode.ColorMapMajor.Length; i++)
            {
                for (int j = 0; j < ColorCode.ColorMapMinor.Length; j++)
                {
                    colorCodeReferences.Add(pairNumber, new ColorCode() { MajorColor = ColorCode.ColorMapMajor[i], MinorColor = ColorCode.ColorMapMinor[j] });
                    pairNumber++;
                }
            }
        }
        internal string GetColorCodeReferenceManual()
        {
            StringBuilder colorCodeReferenceManual = new StringBuilder();
            colorCodeReferenceManual.AppendLine("PairNumber : Major Color - Minor Color");
            foreach (KeyValuePair<int, ColorCode> colorCodeReference in colorCodeReferences)
            {
                colorCodeReferenceManual.AppendLine(string.Format("{0} : {1} - {2}", colorCodeReference.Key, colorCodeReference.Value.MajorColor, colorCodeReference.Value.MinorColor));
            }
            return colorCodeReferenceManual.ToString();
        }
        internal ColorCode GetColorCodeFromPairNumber(int pairNumber)
        {
            if (!colorCodeReferences.ContainsKey(pairNumber))
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            return colorCodeReferences[pairNumber];
        }
        internal int GetPairNumberFromColorCode(ColorCode pair)
        {
            if (colorCodeReferences.Where(x => x.Value.MajorColor.Equals(pair.MajorColor) && x.Value.MinorColor.Equals(pair.MinorColor)).Count() == 0)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            return colorCodeReferences.FirstOrDefault(x => x.Value.MajorColor.Equals(pair.MajorColor) && x.Value.MinorColor.Equals(pair.MinorColor)).Key;
        }
    }
}