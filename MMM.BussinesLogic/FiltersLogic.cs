using System;
using System.Linq;

namespace MMM.BussinesLogic
{
    public class FiltersLogic
    {
        public void GetFilterNameFilterValueById(int? selectedFilterId, out string filterName, out string filterValue)
        {
            filterName = "";
            filterValue = "";

            if (selectedFilterId != null && selectedFilterId > 0)
            {
                filterName = Infrastructure.FiltersForWeb.listFiltersForWeb
                    .SingleOrDefault(f => f.Id == selectedFilterId).Name;
                filterValue = Infrastructure.FiltersForWeb.listFiltersForWeb
                    .SingleOrDefault(f => f.Id == selectedFilterId).Value;
            }
        }

        public int GetItemsForPageById(int? selectedItemsForPage)
        {
            int itemsForPage = 20;

            if (selectedItemsForPage != null)
            {
                itemsForPage = Infrastructure.ItemsForPage.listItemsForPage
                    .SingleOrDefault(i => i.Id == selectedItemsForPage.Value).SelectValue;
            }

            return itemsForPage;
        }

        public DateTime? GetDateTimeByDateStringWithDots(string stringDateToConvert)
        {
            if (!String.IsNullOrEmpty(stringDateToConvert))
            {
                return DateTime.ParseExact(stringDateToConvert, "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            return null;
        }

        public DateTime? GetEndDateTimeDateStringWithDots(string stringEndDateToConvert)
        {
            if (!String.IsNullOrEmpty(stringEndDateToConvert))
            {
                var endDateTime = DateTime.ParseExact(stringEndDateToConvert, "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                var time = new TimeSpan(23, 59, 59);
                endDateTime += time;
                return endDateTime;
            }
            return null;
        }
    }
}