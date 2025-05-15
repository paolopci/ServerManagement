using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;


namespace ServerManagement.Models
{
    public class ServersEFCoreRepository : IServersEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> _contextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void AddServer(Server server)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Servers.Add(server);
            db.SaveChanges();
        }

        public List<Server> GetAllServers()
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers
                .Select(s => new Server
                {
                    ServerId = s.ServerId,
                    Name = s.Name,
                    City = s.City,
                    IsOnline = s.IsOnline
                })
                .ToList();
        }

        public Server? GetServerById(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            var server = db.Servers.FirstOrDefault(s => s.ServerId == id);
            if (server is null)
                return null;

            return new Server
            {
                ServerId = server.ServerId,
                Name = server.Name,
                City = server.City,
                IsOnline = server.IsOnline
            };
        }

        public void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerId)
                return;

            using var db = _contextFactory.CreateDbContext();
            var existing = db.Servers.FirstOrDefault(s => s.ServerId == serverId);
            if (existing is null)
                return;

            existing.Name = server.Name;
            existing.City = server.City;
            existing.IsOnline = server.IsOnline;

            db.SaveChanges();
        }

        public void DeleteServer(int serverId)
        {
            using var db = _contextFactory.CreateDbContext();
            var toDelete = db.Servers.FirstOrDefault(s => s.ServerId == serverId);
            if (toDelete is null)
                return;

            db.Servers.Remove(toDelete);
            db.SaveChanges();
        }
    }

}
