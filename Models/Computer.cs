using System.ComponentModel.DataAnnotations;

namespace MvcLabManager.Models;

public class Computer
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Ram { get; set; }

    [Required]
    [StringLength(25)]
    public string Processor { get; set; }

    public Computer() {}

    public Computer(int id, string ram, string processor)
    {
        Id = id;
        Ram = ram;
        Processor = processor;
    }
}