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
      System.Console.WriteLine("What would you like to do? \n(add quarter, browse, buy, quit)");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "quit":
        case "exit":
        case "q":
        case "x":
          Console.Clear();
          _running = false;
          break;
        case "add quarter":
          Console.Clear();
          _vs.AddQuarter();
          break;
        case "browse":
          Console.Clear();
          _vs.ViewSelectionMessage();
          break;
        case "buy":
          Console.Write("Enter a vending number:");
          string indexString = Console.ReadLine();
          _vs.Buy(indexString);
          Console.Clear();
          break;
        default:
          _vs.Messages.Add(new Message("Invalid Input"));
          break;
      }

    }

    private void Print()
    {
      _vs.Messages.Insert(0, new Message(Utils.MachineLogo, ConsoleColor.Cyan));

      foreach (Message message in _vs.Messages)
      {
        Console.ForegroundColor = message.Color;
        Console.WriteLine(message.Body);
      }
      Console.ForegroundColor = ConsoleColor.White;
      _vs.Messages.Clear();
    }
  }
}
