namespace Restaurant.Services.ProductApi.Models.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }=true;
        public object Result { get; set; }
        public string Message { get; set; } = "";
        public List<string> ErrorMessages { get; set; } 
    }
}
