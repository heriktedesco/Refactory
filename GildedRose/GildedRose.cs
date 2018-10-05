using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                
                bool ageSentence = Items[i].Name == "Aged Brie";
                bool sulfurasSentence = Items[i].Name == "Sulfuras, Hand of Ragnaros";
                bool backstageSentence = Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
                
                if (!backstageSentence && !agedSentence)
                {
                    ReductionQuality(i, sulfurasSentence);
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (backstageSentence)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                UpgradeQuality(i);
                            }

                            if (Items[i].SellIn < 6)
                            {
                                UpgradeQuality(i);
                            }
                        }
                    }
                }

                if (!sulfurasSentence)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (!agedSentence)
                    {
                        if (!backstageSentence)
                        {
                            ReductionQuality(i, sulfuras);
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        UpgradeQuality(i)
                    }
                }
            }
        }
        
        private void UpgradeQuality(int i)
        {
            if (Items[i].Quality < 50)
            {
                Items[i].Quality = Items[i].Quality + 1;
            }
        }
        private void ReductionQuality(int i, bool sulfurasSentence)
        {
            if (Items[i].Quality > 0)
            {
                if (!sulfurasSentence)
                {
                    Items[i].Quality = Items[i].Quality - 1;
                }
            }
        }
    }
}
