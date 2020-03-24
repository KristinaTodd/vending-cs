namespace vending_cs.Models
{
  class Options
  {
    public Options(string name, int price)
    {
      Name = name;
      Price = price;
      IsAvailable = true;
    }

    public string Name { get; set; }
    public int Price { get; set; }
    public bool IsAvailable { get; set; }

  }
}