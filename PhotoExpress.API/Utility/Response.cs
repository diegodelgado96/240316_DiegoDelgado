namespace PhotoExpress.API.Utility
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Value { get; set; }
        public string msg { get; set; }
    }
}
