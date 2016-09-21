namespace Lib.Tests.DecomposingPageObjects
{
    public static class TestConfig
    {
        public static string UrlBase =
#if DEBUG
            "http://localhost:7104";
#else
            "http://codeduiexamples.com";
#endif
    }
}