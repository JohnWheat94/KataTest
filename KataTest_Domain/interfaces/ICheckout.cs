namespace KataTest_Domain.interfaces
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
