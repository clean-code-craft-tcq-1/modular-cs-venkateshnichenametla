using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ColorCode
    {
        private static Color[] colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
        public static Color[] ColorMapMajor
        {
            get { return colorMapMajor; }
            private set { colorMapMajor = value; }
        }

        private static Color[] colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        public static Color[] ColorMapMinor
        {
            get { return colorMapMinor; }
            private set { colorMapMinor = value; }
        }

        public Color MajorColor { get; set; }

        public Color MinorColor { get; set; }

        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", MajorColor.Name, MinorColor.Name);
        }
    }
}
