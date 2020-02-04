using System;
using System.ComponentModel.DataAnnotations;
using burgershack.Interfaces;

namespace burgershack.Models
{
  public class Burger : IMenuItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    public float Price { get; set; }
    public string Description { get; set; }




    public Burger()
    {
    }
    public Burger(string name, string desc, float price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}