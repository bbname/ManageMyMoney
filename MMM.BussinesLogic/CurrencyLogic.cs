using MMM.Infrastructure;

namespace MMM.BussinesLogic
{
    public class CurrencyLogic
    {
        public string GetCurrencyIconById(int idCurrency)
        {
            var currencyIcon = Currencies.listCurrencies.Find(x => x.Id == idCurrency).IconCode;
            return currencyIcon;
        }
    }
}