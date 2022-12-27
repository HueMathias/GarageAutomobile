namespace ConstellationGarage.Models;

public partial class Car
{
    public int Id { get; set; }

    public string? CodeCategorie { get; set; }

    public string? CodeBrand { get; set; }

    public string? Essence { get; set; }

    public string? Color { get; set; }

    public bool? New { get; set; }

    public virtual Brand? CodeBrandNavigation { get; set; }

    public virtual Category? CodeCategorieNavigation { get; set; }
}
