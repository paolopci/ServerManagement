using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServerManagement.Models;


namespace ServerManagement.StateStorage
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage _protectedSessionStorage;
        public SessionStorage(ProtectedSessionStorage protectedSessionStorage)
        {
            this._protectedSessionStorage = protectedSessionStorage;
        }

        public async Task<Server?> GetServerAsync()
        {
            var result = await _protectedSessionStorage.GetAsync<Server>("server");
            if (result.Success)
            {
                return result.Value;
            }
            return null;
        }

        public async Task SetServerAsync(Server? server)
        {
            await _protectedSessionStorage.SetAsync("server", server);
        }

        //public async Task<Server?> GetCityAsync()
        //{
        //    var result = await _protectedSessionStorage.GetAsync<Server>("city");
        //    if (result.Success)
        //    {
        //        return result.Value;
        //    }
        //    return null;
        //}

        //public async Task SetCityAsync(string? cityName)
        //{
        //    await _protectedSessionStorage.SetAsync("city", cityName);
        //}
    }
}
