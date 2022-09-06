namespace Domain.Entities;

public class ConvertVideo<T>
{
    public T Video { get; set; }
    public string PathToSaveVideo { get; set; }
}