using System.Collections.Generic;

namespace MMM.Infrastructure
{
    public static class Currencies
    {
        public static List<Currency> listCurrencies = new List<Currency>()
        {
            new Currency {Id = 1, Name = "PLN", IconCode = "zł"},
            new Currency {Id = 2, Name = "USD", IconCode = "$"},
            new Currency {Id = 3, Name = "EUR", IconCode = "€"},
            new Currency {Id = 4, Name = "GBP", IconCode = "£"},
            new Currency {Id = 5, Name = "JPY", IconCode = "¥"}
        };
    }
}