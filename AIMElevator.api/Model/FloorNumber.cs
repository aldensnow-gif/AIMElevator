using System.ComponentModel.DataAnnotations;

public class FloorNumber
{
    [Range(1, 13)]
    public int Floor { get; set; }
}