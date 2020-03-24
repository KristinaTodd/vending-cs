using System.Collections.Generic;

namespace vending_cs.Models
{
  class Store
  {
    public List<Options> Options { get; set; }

    public Store()
    {
      Options = new List<Options>(){
    new Candy("Twix Bar", 2),
    new Candy("Twizzlers", 4),
    new Candy("Almond Joy", 1),
    new Candy("M&Ms", 3)
  };
    }
  }
}