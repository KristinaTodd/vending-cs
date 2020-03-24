using System;
using System.Threading;
using System.Collections.Generic;
using vending_cs.Models;

namespace vending_cs.Services
{
  class VendingService
  {
    private Store _store { get; set; } = new Store();
    public List<Message> Messages { get; set; } = new List<Message>();

    public void ViewSelectionMessage()
    {
      for (int i = 0; i < _store.Options.Count; i++)
      {
        var option = _store.Options[i];
        if (option.IsAvailable)
        {
          string message = $"{i + 1}. {option.Name} -- ${option.Price}";
          Messages.Add(new Message(message));
          continue;
        }
      }
    }

    public void AddQuarter()
    {
      _store.Quarters += 0.25;
      Messages.Add(new Message("You currently have $" + _store.Quarters));
    }

    public void Buy(string indexString)
    {
      if (int.TryParse(indexString, out int index) && index - 1 > -1 && index - 1 < _store.Options.Count)
      {
        Options optionToBuy = _store.Options[index - 1];
        if (_store.Quarters >= optionToBuy.Price)
        {
          if (optionToBuy.IsAvailable)
          {
            Messages.Add(new Message("Vending..."));
            optionToBuy.IsAvailable = false;
            Messages.Add(new Message("You purchased " + optionToBuy.Name + " for $" + optionToBuy.Price + "\n", ConsoleColor.Green));
            _store.Quarters = _store.Quarters - optionToBuy.Price;
            Messages.Add(new Message("You now have $" + _store.Quarters + "\n"));
            return;
          }
          else
          {
            Messages.Add(new Message("Sorry, that item is sold out!\n", ConsoleColor.Red));
          }
        }
        else
        {
          Messages.Add(new Message("Sorry, you don't have enough money to buy that item! \n Add more money or select a different item!", ConsoleColor.Red));
        }
      }
    }

  }
}