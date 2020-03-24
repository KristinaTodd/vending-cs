namespace vending_cs.Models
{
  class Message
  {
    public Message(string body)
    {
      Body = body;
    }
    public string Body { get; set; }
  }
}