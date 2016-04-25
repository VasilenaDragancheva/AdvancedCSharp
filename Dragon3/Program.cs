namespace Dragon3
{
    // swtiched with hyperlinks
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a\b[^>]*\bhref\s*=\s*([^\s]+)[^>]*>";
        }
    }
}