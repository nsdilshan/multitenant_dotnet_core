using Core.Interfaces;
using Core.Options;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientSettings _clientSettings;
        private readonly HttpContext _httpContext;
        private Client _currentClient;
        private readonly SystemDbContext _context;

        public ClientService(IOptions<ClientSettings> clientSettings, IHttpContextAccessor contextAccessor, SystemDbContext context)
        {
            _context = context;
            _clientSettings = clientSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("tenant", out var clientId))
                {
                    SetClient(clientId);
                }
                else
                {
                    throw new Exception("Invalid Client!");
                }
            }
        }

        private void SetClient(string clientId)
        {
            _currentClient = _context.Clients.Where(a => a.ClientId == clientId).FirstOrDefault();

            if (_currentClient == null) throw new Exception("Invalid Client!");
            if (string.IsNullOrEmpty(_currentClient.DbName))
            {
                SetDefaultConnectionStringToCurrentClient();
            }
        }

        private void SetDefaultConnectionStringToCurrentClient()
        {
            _currentClient.ConnectionString = _clientSettings.Defaults.ConnectionString;
        }

        public string GetConnectionString()
        {
            return _currentClient?.ConnectionString;
        }

        public Client GetClient()
        {
            return _currentClient;
        }
    }
}