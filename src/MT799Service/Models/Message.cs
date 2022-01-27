namespace MT799Service.Models
{
    public class Message
    {
        public Message() => this.Id = Guid.NewGuid().ToString();

        public string Id { get; set; }

        // 20 - Transaction Reference Number - Mandatory
        public string TransactionReferenceNumber { get; set; } = default!;

        // 21 - Related Reference - Optional
        public string? RelatedReference { get; set; }

        // 79 - Narrative - Mandatory
        public string Narrative { get; set; } = default!;
    }
}