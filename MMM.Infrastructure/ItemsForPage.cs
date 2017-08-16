using System.Collections.Generic;

namespace MMM.Infrastructure
{
    public static class ItemsForPage
    {
        public static List<ItemForPage> listItemsForPage = new List<ItemForPage>()
        {
            new ItemForPage(){ Id = 1, SelectValue = 4 },
            new ItemForPage(){ Id = 2, SelectValue = 8 },
            new ItemForPage(){ Id = 3, SelectValue = 12 },
            new ItemForPage(){ Id = 4, SelectValue = 16 },
            new ItemForPage(){ Id = 5, SelectValue = 20 },
            new ItemForPage(){ Id = 6, SelectValue = 28 },
            new ItemForPage(){ Id = 7, SelectValue = 40 }
        };

        //public static List<ItemForPage> listItemsForPage = new List<ItemForPage>()
        //{
        //    new ItemForPage(){ Id = 1, SelectValue = 10 },
        //    new ItemForPage(){ Id = 2, SelectValue = 15 },
        //    new ItemForPage(){ Id = 3, SelectValue = 20 },
        //    new ItemForPage(){ Id = 4, SelectValue = 25 },
        //    new ItemForPage(){ Id = 5, SelectValue = 30 },
        //    new ItemForPage(){ Id = 6, SelectValue = 40 },
        //    new ItemForPage(){ Id = 7, SelectValue = 50 }
        //};
    }
}