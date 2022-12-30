namespace RecycleCoinMvc.Models
{
    public class Toastr
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }

        public Toastr(string title, string message , string messageType)
        {
            Title = title;
            Message = message;
            MessageType = messageType;
        }
    }
}