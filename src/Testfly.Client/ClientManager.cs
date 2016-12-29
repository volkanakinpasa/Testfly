namespace Testfly.Client
{
    public class ClientManager : IClientManager
    {
        private readonly IClientDataLayer _clientDataLayer;

        public ClientManager()
        {
            _clientDataLayer = new ClientDataLayer();
        }

        public ClientManager(IClientDataLayer clientDataLayer)
        {
            _clientDataLayer = clientDataLayer;
        }

        string IClientManager.GetData(int id)
        {
            return _clientDataLayer.GetData(id);
        }
    }
}
