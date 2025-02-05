using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


public class Rent
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Month {get; set; }

    [Required]

    public string Name { get; set; }


    public int PreviousUnit {get; set;}

    public int NewUnit {get; set; }

    public decimal ElectrictyPrice{get; set;}

    public decimal HouseRent{ get; set; }

    public decimal WaterPrice{ get; set; }

    public decimal WastePrice{get; set;}

    public decimal Discount{get; set;}

    public decimal Total => ((NewUnit-PreviousUnit)*ElectrictyPrice+HouseRent+WaterPrice+WastePrice-Discount);

    public string Status {get; set; }

    [DataType(DataType.Date)]

    public DateTime RentDate{get; set; }
}