namespace ServerManagement.Models
{
    public interface IServersEFCoreRepository
    {
        void AddServer(Server server);

        List<Server> GetAllServers();

        Server? GetServerById(int id);

        void UpdateServer(int serverId, Server server);

        void DeleteServer(int serverId);
    }
}
