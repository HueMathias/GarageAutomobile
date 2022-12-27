namespace ConstellationGarage.Models;

public partial class Brand
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public byte[]? Icon { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
