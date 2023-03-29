namespace RaquunProject.DataAccess.Result
{
    public class Result<T>
    {
        public Result()
        {
            Success = false;
            Message = string.Empty;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
