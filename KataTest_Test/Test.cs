using KataTest_Domain.domain;
using KataTest_Domain.interfaces;
using KataTest_Domain.repos;

namespace KataTest_Test
{
    public class Test
    {
        [Fact]
        public void Test_SingleItem_Price()
        {
            var pricingRules = new Dictionary<string, Rule>
            {
                { "A", new Rule(50, 3, 130) },
                { "B", new Rule(30, 2, 45) },
                { "C", new Rule(20) },
                { "D", new Rule(15) }
            };

            ICheckout checkout = new Checkout(pricingRules);
            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());
        }

        [Fact]
        public void Test_MultipleItems_WithSpecialPrice()
        {
            var pricingRules = new Dictionary<string, Rule>
            {
                { "A", new Rule(50, 3, 130) },
                { "B", new Rule(30, 2, 45) },
                { "C", new Rule(20) },
                { "D", new Rule(15) }
            };

            ICheckout checkout = new Checkout(pricingRules);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A"); // Special price should apply: 3 for 130
            checkout.Scan("B");
            checkout.Scan("B"); // Special price should apply: 2 for 45
            checkout.Scan("C");

            Assert.Equal(195, checkout.GetTotalPrice()); // 130 (A) + 45 (B) + 20 (C)
        }


        [Fact]
        public void Test_MixedItems()
        {
            var pricingRules = new Dictionary<string, Rule>
            {
                { "A", new Rule(50, 3, 130) },
                { "B", new Rule(30, 2, 45) },
                { "C", new Rule(20) },
                { "D", new Rule(15) }
            };

            ICheckout checkout = new Checkout(pricingRules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            Assert.Equal(115, checkout.GetTotalPrice()); // 50 (A) + 30 (B) + 20 (C) + 15 (D)
        }

        [Fact]
        public void Test_EmptyCart()
        {
            var pricingRules = new Dictionary<string, Rule>
        {
            { "A", new Rule(50, 3, 130) },
            { "B", new Rule(30, 2, 45) },
            { "C", new Rule(20) },
            { "D", new Rule(15) }
        };

            ICheckout checkout = new Checkout(pricingRules);
            Assert.Equal(0, checkout.GetTotalPrice());
        }
    }
}