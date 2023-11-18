﻿using System.ComponentModel.DataAnnotations;

namespace Uppgift_Databasteknik.Entities;

public class ProductCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategorytName { get; set; } = null!;
}