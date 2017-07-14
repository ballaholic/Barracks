namespace Barracks.ExtensionMethods
{
    using System.Text;

    public static class StringExtensions
    {
        public static string ToPascalCase(this string str)
        {
            char firstLetter = char.ToUpper(str[0]);
            StringBuilder word = new StringBuilder();
            word.Append(firstLetter.ToString());
            word.Append(str.Substring(1, str.Length - 1));
            return word.ToString();
        }
    }
}