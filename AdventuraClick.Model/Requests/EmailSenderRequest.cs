namespace AdventuraClick.Model.Requests
{
    public class EmailSenderRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
