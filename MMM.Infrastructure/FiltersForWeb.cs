using System.Collections.Generic;

namespace MMM.Infrastructure
{
    public static class FiltersForWeb
    {
        public static List<FilterForWeb> listFiltersForWeb = new List<FilterForWeb>()
        {
            new FilterForWeb {Id = 0, SelectValue = "Wybierz filtr", Name = "", Value = ""},
            new FilterForWeb {Id = 1, SelectValue = "Przychód: od największego", Name = "+Amount", Value = "desc"},
            new FilterForWeb {Id = 2, SelectValue = "Przychód: od najmniejszego", Name = "+Amount", Value = "asc"},
            new FilterForWeb {Id = 3, SelectValue = "Wydatek: od największego", Name = "-Amount", Value = "asc"},
            new FilterForWeb {Id = 4, SelectValue = "Wydatek: od najmniejszego", Name = "-Amount", Value = "desc"},
            new FilterForWeb {Id = 5, SelectValue = "Saldo: od największego", Name = "AccountBalance", Value = "desc"},
            new FilterForWeb {Id = 6, SelectValue = "Saldo: od najmniejszego", Name = "AccountBalance", Value = "asc"},
            new FilterForWeb {Id = 7, SelectValue = "Data: od najwcześniej", Name = "SetDate", Value = "desc"},
            new FilterForWeb {Id = 8, SelectValue = "Data: od najpoźniej", Name = "SetDate", Value = "asc"},
            new FilterForWeb {Id = 9, SelectValue = "Nazwa: od A-Z", Name = "Name", Value = "asc"},
            new FilterForWeb {Id =10, SelectValue = "Nazwa: od Z-A", Name = "Name", Value = "desc"}
        };
    }
}