using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        Program prog = new Program();
        Item itm = new Item();
        private int MAX_QUALITY = 50;

        public static Item SimpleItm
        {
            get
            {
                return new Item
                {
                    Name = "Item",
                    SellIn = 20,
                    Quality = 1
                };
            }
        }
        public static Item MatureCheese
        {
            get
            {
                return new Item
                {
                    Name = "Aged Brie",
                    SellIn = 20,
                    Quality = 1
                };
            }
        }
        public static Item BackstageItem
        {
            get
            {
                return new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 20,
                    Quality = 1
                };
            }
        }
        public static Item PrestigiousItem
        {
            get
            {
                return new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                };
            }
        }
        public static Item ConjuredCake
        {
            get
            {
                return new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 20,
                    Quality = 1
                };
            }
        }

        [Fact] 
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]//Testing xUnit
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }
        //Testing xUnit
        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]//Testing xUnit
        public void NoBelowFifty()
        {
            var nam = itm.Name;
            var qual = itm.Quality;
            var sin = itm.SellIn;
            
            if(qual > 50 && sin == 0)
            {
                Assert.Equal(nam, "Sulfuras, Hand of Ragnaros");
            }
        }

        [Fact]
        public void NoBelow0()
        {
            var nam = itm.Name;
            var qual = itm.Quality;
            var sin = itm.SellIn;

            if(qual <= -1)
            {
                Assert.True(true);
            }
        }      

        [Fact]
        public void DecreasedQualityTwiceAsFast()
        {
            Item item = SimpleItm;
            item.SellIn = -1;
            item.Quality = 10;
            SetupItem(item);
            Assert.Equal(8, _item.Quality);
        }
        
        [Fact]
        public void DecreaseSellInFurther()
        {
            Item item = SimpleItm;
            item.SellIn = -1;

            SetupItem(item);
            Assert.Equal(-2, _item.SellIn);
        }

        [Fact]
        public void CantGoBelow0()
        {
            Item item = SimpleItm;
            item.Quality = 0;
            SetupItem(item);
            Assert.Equal(0, _item.Quality);
        }

        [Fact]
        public void CheeseIncreasingQuality()
        {
            SetupItem(MatureCheese);
            Assert.Equal(2, _item.Quality);
        }

        [Fact]
        public void CheeseNeverIncreaseInQualityBeyondMax()
        {
            Item item = MatureCheese;
            item.Quality = MAX_QUALITY;
            SetupItem(item);
            Assert.Equal(MAX_QUALITY, _item.Quality);
        }

        [Fact]
        public void CheeseIncreaseInQualityFaster()
        {
            Item item = MatureCheese;
            item.SellIn = -1;
            SetupItem(item);
            Assert.Equal(3, _item.Quality);
        }

        [Fact]
        public void CheeseCantIncreaseQualityBeyongMax()
        {
            Item item = MatureCheese;
            item.SellIn = -1;
            item.Quality = MAX_QUALITY - 1;
            SetupItem(item);
            Assert.Equal(MAX_QUALITY, _item.Quality);
        }

        [Fact]
        public void PrestigeousCanBeSellIn()
        {
            SetupItem(PrestigiousItem);
            Assert.Equal(0, _item.SellIn);
        }

        [Fact]
        public void PrestigeousDontChageQuality()
        {
            Item item = PrestigiousItem;
            item.SellIn = -1;
            SetupItem(item);
            Assert.Equal(80, _item.Quality);
        }

        [Fact]
        public void BackstageIncreaseTime2IfSellInIsLessThan11()
        {
            Item item = BackstageItem;
            item.SellIn = 10;
            SetupItem(item);
            Assert.Equal(3, _item.Quality);
        }

        [Fact]
        public void BackstageIncreaseTime3IfSellInIsLessThan6()
        {
            Item item = BackstageItem;
            item.SellIn = 5;
            SetupItem(item);
            Assert.Equal(4, _item.Quality);
        }

        [Fact]
        public void BackstageExpireDropTo0()
        {
            Item item = BackstageItem;
            item.SellIn = -1;
            SetupItem(item);
            Assert.Equal(0, _item.Quality);
        }
    }
}
