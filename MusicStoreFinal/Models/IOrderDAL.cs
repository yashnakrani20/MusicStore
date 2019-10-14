namespace MusicStore.Models
{
    public interface IOrderDAL
    {
        void Dispose();
        Order FindById(int? id);
        void SaveNewOrder(Order order);
        void UpdateOrder(Order order);
    }
}