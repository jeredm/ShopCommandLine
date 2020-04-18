using System.CommandLine.Rendering;

namespace ShopCommandLine
{
    internal static class ColorExtensions
    {
        public static TextSpan Underline(this string value) =>
            new ContainerSpan(StyleSpan.UnderlinedOn(),
                              new ContentSpan(value),
                              StyleSpan.UnderlinedOff());

        public static TextSpan UnderlineRgb(this string value, byte r, byte g, byte b) =>
            new ContainerSpan(StyleSpan.UnderlinedOn(),
                              ForegroundColorSpan.Rgb(r, g, b),
                              new ContentSpan(value),
                              ForegroundColorSpan.Reset(),
                              StyleSpan.UnderlinedOff());  

        public static TextSpan UnderlineRed(this string value) =>
            new ContainerSpan(StyleSpan.UnderlinedOn(),
                              ForegroundColorSpan.Rgb(237, 90, 90),
                              new ContentSpan(value),
                              ForegroundColorSpan.Reset(),
                              StyleSpan.UnderlinedOff());  

        public static TextSpan Rgb(this string value, byte r, byte g, byte b) =>
            new ContainerSpan(ForegroundColorSpan.Rgb(r, g, b),
                              new ContentSpan(value),
                              ForegroundColorSpan.Reset());

        public static TextSpan LightGreen(this string value) =>
            new ContainerSpan(ForegroundColorSpan.LightGreen(),
                              new ContentSpan(value),
                              ForegroundColorSpan.Reset());

        public static TextSpan Red(this string value) =>
            new ContainerSpan(ForegroundColorSpan.Red(),
                              new ContentSpan(value),
                              ForegroundColorSpan.Reset());

        public static TextSpan White(this string value) =>
            new ContainerSpan(ForegroundColorSpan.White(),
                              new ContentSpan(value),
                              ForegroundColorSpan.Reset());
    }
}