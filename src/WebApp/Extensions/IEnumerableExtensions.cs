namespace WebApp.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var random = new Random();
            return list.OrderBy(x => random.Next());
        }
    }
}
