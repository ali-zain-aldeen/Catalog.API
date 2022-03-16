namespace Catalog.Emails.Models
{
    public class EmailMessage
    {
        public string ToAddress { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
