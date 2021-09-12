namespace Server.Models
{
    public class PagedResponseModel<T>
    {
        public T[] Items { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
