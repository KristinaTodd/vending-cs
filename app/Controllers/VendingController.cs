using vending_cs.Models;
using vending_cs.Services;
using System;
using System.Threading;

namespace vending_cs.Controllers
{
  class VendingController
  {
    private bool _running { get; set; } = true;
    private VendingService _vs { get; set; } = new VendingService();
    public void Run()
    {
      while (_running)
      {
        GetUserInput();
        Print();
      }
    }

    private void GetUserInput()
    {
      System.Console.WriteLine("What would you like to do? \n(browse, quit, buy)");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "quit":
        case "exit":
        case "q":
        case "x":
          _running = false;
          break;
        case "browse":
          _vs.ViewSelectionMessage();
          break;
        case "buy":
          Console.Write("Enter a vending number:");
          string indexString = Console.ReadLine();
          _vs.Buy(indexString);
          break;
        default:
          _vs.Messages.Add(new Message("Invalid Input"));
          break;
      }

    }

    private void Print()
    {
      _vs.Messages.Insert(0, new Message(Utils.MachineLogo));

      foreach (Message message in _vs.Messages)
      {
        Console.WriteLine(message.Body);
      }
      _vs.Messages.Clear();
    }
  }
}
