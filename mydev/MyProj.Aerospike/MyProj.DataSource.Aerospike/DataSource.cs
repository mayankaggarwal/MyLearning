using Aerospike.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyProj.DataSource.Aerospike.Models;
using MyProj.DataSource.Contracts;
using System;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace MyProj.DataSource.Aerospike
{
    public class DataSource : IDataSource
    {
        private readonly IAerospikeClient _client;
        private readonly IAerospikeConfig _config;
        private readonly ILogger _logger;

        public DataSource(IAerospikeClient aerospikeClient,IAerospikeConfig config,ILogger<DataSource> logger)
        {
            _client = aerospikeClient;
            _config = config;
            _logger = logger;
        }
        public async Task<DbResponse> Create<T>(string key, T value, TimeSpan? expiration = null) where T : class
        {
            try
            {
                _client.Add(null, new Key(_config._namespace, _config._setname, key), new Bin(_config._binname, value));
                _logger.LogInformation($"Insert record with key :{key}");
                return await Task.Run(() => new DbResponse { Success = true });
            } catch(Exception exp)
            {
                _logger.LogError(exp.Message);
                return await Task.Run(() => new DbResponse { Success = false });
            }
        }

        public T Get<T>(string documentId) where T : class
        {
            var record = _client.Get(null, new Key(_config._namespace, _config._setname, documentId));
            if (record != null)
            {
                return ConvertToType<T>(record.GetString(_config._binname));
            }

            _logger.LogInformation($"Get failed, Document Id {documentId}");
            return null;
        }

        public void Remove(string documentId)
        {
            if(_client.Exists(null, new Key(_config._namespace, _config._setname, documentId)))
            {
                _client.Delete(null, new Key(_config._namespace, _config._setname, documentId));
            }
            else
            {
                _logger.LogInformation($"No Document to Delete with id {documentId}");
            }
        }

        public async Task<DbResponse> Set<T>(string key, T value) where T : class
        {
            try
            {
                _client.Put(null, new Key(_config._namespace, _config._setname, key), new Bin(_config._binname, value));
                _logger.LogInformation($"Insert record with key :{key}");
                return await Task.Run(() => new DbResponse { Success = true });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return await Task.Run(() => new DbResponse { Success = false });
            }
        }

        private T ConvertToType<T>(string value) where T : class
        {
            return typeof(T) == typeof(string) ? value as T : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
