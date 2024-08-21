using KataTest_Domain.domain;
using KataTest_Domain.interfaces;

namespace KataTest_Domain.repos
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, Rule> rules;
        private readonly Dictionary<string, int> _items;

        public Checkout(Dictionary<string, Rule> pricingRules)
        {
            rules = pricingRules;
            _items = new Dictionary<string, int>();
        }

        public void Scan(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item]++;
            }
            else
            {
                _items[item] = 1;
            }
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _items)
            {
                var sku = item.Key;
                var quantity = item.Value;
                var rule = rules[sku];

                if (rule.SpecialQuantity.HasValue && rule.SpecialPrice.HasValue)
                {
                    int specialBundles = quantity / rule.SpecialQuantity.Value;
                    int remainingItems = quantity % rule.SpecialQuantity.Value;

                    totalPrice += specialBundles * rule.SpecialPrice.Value;
                    totalPrice += remainingItems * rule.UnitPrice;
                }
                else
                {
                    totalPrice += quantity * rule.UnitPrice;
                }
            }

            return totalPrice;
        }
    }
}
