using System.Collections.Generic;

namespace GildedRose.Application
{
    public static class Shop
    {
        public static IList<Item> Items;

        public static void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name.StartsWith("Conjured"))
                {
                    Conjured(Items[i]);
                }
                else
                {
                    Quality(Items[i]);
                    UpdateSell(Items[i]);
                }
                
            }
        }
        private static void Conjured(Item item)
        {
            if (item.Name.StartsWith("Conjured") && item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
                item.Quality = item.Quality - 1;
            }
        }
        
        private static void Quality(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                DecQualIfHasQuality(item);
            }
            else
            {
                IncQualWithBackstagePasses(item);
            }
        }

        private static void DecQualIfHasQuality(Item item)
        {
            if (item.Quality > 0)
            {
                DecreaseQuality(item);
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros" && item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void IncQualWithBackstagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                IncreaseQuality(item);
                IncQualBackstagePasses(item);
            }
        }

        private static void IncQualBackstagePasses(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncQualIfFarFromExpiry(item);
                IncQualIfCloseExpiry(item);
            }
        }

        private static void IncQualIfCloseExpiry(Item item)
        {
            if (item.SellIn < 6)
            {
                IncreaseQualityIfNotMax(item);
            }
        }
        private static void IncQualIfFarFromExpiry(Item item)
        {
            if (item.SellIn < 11)
            {
                IncreaseQualityIfNotMax(item);
            }
        }
        private static void IncreaseQualityIfNotMax(Item item)
        {
            if (item.Quality < 50)
            {
                IncreaseQuality(item);
            }
        }
        private static void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private static void UpdateSell(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }
            ifExpired(item);
        }

        private static void ifExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                Expired(item);
            }
        }

        private static void Expired(Item item)
        {
            if (item.Name != "Aged Brie")
            {
                ExpiredIfNotAgedBrie(item);
            }
            else
            {
                IncreaseQualityIfNotMax(item);
            }
        }

        private static void ExpiredIfNotAgedBrie(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                DecQualIfHasQuality(item);
            }
        }
     
    }

}

