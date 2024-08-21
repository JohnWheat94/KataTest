namespace KataTest_Domain.domain
{
    public class Rule
    {
        public int UnitPrice { get; }
        public int? SpecialQuantity { get; }
        public int? SpecialPrice { get; }

        public Rule(int unitPrice, int? specialQuantity = null, int? specialPrice = null)
        {
            UnitPrice = unitPrice;
            SpecialQuantity = specialQuantity;
            SpecialPrice = specialPrice;
        }
    }
}
}
