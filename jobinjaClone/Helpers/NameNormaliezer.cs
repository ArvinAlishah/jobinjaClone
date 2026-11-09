namespace jobinjaClone.Helpers
{
    public  static class NameNormaliezer
    {
        public static string Normalize(string username)
        {
            return username.Trim().ToUpperInvariant();
        }

    }
}
