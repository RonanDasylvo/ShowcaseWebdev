using System.ComponentModel.DataAnnotations.Schema;

namespace Showcase.Models;

[Table("Lists")]
public class ItemListModel
{
    public int Id { get; set; }
    public List<string> Content { get; set; } = [];
}