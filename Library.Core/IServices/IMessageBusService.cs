namespace Library.Core.IServices
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);
    }
}
