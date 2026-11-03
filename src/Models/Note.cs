namespace Sample.Models;

[Table("note")]
public class Note : BaseEntity
{
    public Note()
    {
    }

    [Column("title")]
    public string Title { get; set; } = "";

    [Column("content")]
    public string Content { get; set; } = "";
}
