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

    public void Buy(string indexString)
    {
      if (int.TryParse(indexString, out int index) && index - 1 > -1 && index - 1 < _store.Options.Count)
      {
        Options optionToBuy = _store.Options[index - 1];
        if (optionToBuy.IsAvailable)
        {
          optionToBuy.IsAvailable = false;
          Messages.Add(new Message("You purchased " + optionToBuy.Name + " for $" + optionToBuy.Price));
          return;
        }
      }
    }

  }
}