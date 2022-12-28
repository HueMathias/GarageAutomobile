using System.Collections.Generic;
using System.Globalization;

namespace ConstellationGarage.Tools;

public class CultureSwitcher
{
    public CultureInfo CurrentUICulture { get; set; }
    public List<CultureInfo> SupportedCultures { get; set; }
}
