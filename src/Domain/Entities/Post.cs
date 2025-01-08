using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("post")]  
public class Post
{
    public Guid id { get; set; }
    public string title { get; set; }
     
    public string content { get; set; }
    [Column("created_date")]
    public DateTime createdDate { get; set; }
    [Column("category_id")]
    public Guid categoryId { get; set; }
  
    public Category Category { get; set; }
}