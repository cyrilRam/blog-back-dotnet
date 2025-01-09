using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("category")]
public class Category
{
    public Guid id { get; set; }
    public string name { get; set; }
}