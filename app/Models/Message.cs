using System;

namespace vending_cs.Models
{
  class Message
  {
    public Message(string body, ConsoleColor color = ConsoleColor.White)
    {
      Body = body;
      Color = color;
    }
    public string Body { get; set; }
    public ConsoleColor Color { get; set; }
  }
}