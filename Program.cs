using System;
using vending_cs.Controllers;

namespace vending_cs
{
  class Program
  {
    static void Main(string[] args)
    {
      VendingController vend = new VendingController();
      vend.Run();
    }
  }
}
