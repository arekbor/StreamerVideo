namespace Domain.Models;

public class AppLog<TLevel>
{
    public TLevel Level { get; set; }
    public string Message { get; set; }
    public Type Type { get; set; }
}
