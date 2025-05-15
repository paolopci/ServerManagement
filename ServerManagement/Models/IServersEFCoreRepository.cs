namespace ServerManagement.Models
{
    public interface IServersEFCoreRepository
    {
        List<Server> GetServersByCity(string city);
        void AddServer(Server server);
        List<Server> GetAllServers();
        Server? GetServerById(int id);
        void UpdateServer(int serverId, Server server);
        void DeleteServer(int serverId);
        List<Server> SearchServers(string serverFilter);
    }
}
