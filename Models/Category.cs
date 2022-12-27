namespace ConstellationGarage.Models;

public partial class Category
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
