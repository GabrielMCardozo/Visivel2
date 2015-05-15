using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace Visivel
{
    public class RedisManager
    {
        private const string Channel = "visivel";
        private const string HostAndPort = "cod.redistogo.com:10725";
        private readonly ConnectionMultiplexer _redisConn;


        public RedisManager()
        {
            var configurationOptions = new ConfigurationOptions {Password = "be61827946a5d7a6b7333875104d4a26"};
            configurationOptions.EndPoints.Add(HostAndPort);

            _redisConn = ConnectionMultiplexer.Connect(configurationOptions);
        }

        public void Subscribe(Action<string> action)
        {
            ISubscriber subscriber = _redisConn.GetSubscriber();
            subscriber.Subscribe(Channel, (channel, message) => action(message));
        }

        public void Publish(string value)
        {
            ISubscriber subscriber = _redisConn.GetSubscriber();
            subscriber.Publish(Channel, value);
        }

        public IDatabase GetWindowCounterDatabase()
        {
            return _redisConn.GetDatabase();
        }

        public IServer GetServer()
        {
            return _redisConn.GetServer(HostAndPort);
        }
    }

    public class WindowCounter
    {
        private const string UserNameKeyPrefix = "UserName:";
        private readonly IServer _redisServer;
        private readonly string _userName;
        private readonly IDatabase _windowDatabase;

        public WindowCounter(string userName, IDatabase windowDatabase, IServer redisServer)
        {
            _windowDatabase = windowDatabase;
            _redisServer = redisServer;

            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            _userName = UserNameKeyPrefix + userName;
        }

        public void AddWindow()
        {
            RedisValue value = _windowDatabase.StringGet(_userName);

            int windowCount;
            int.TryParse(value, out windowCount);

            _windowDatabase.StringSet(_userName, ++windowCount);
        }

        public int GetWindowCount()
        {
            RedisValue value = _windowDatabase.StringGet(_userName);

            int windowCount;
            int.TryParse(value, out windowCount);

            return windowCount;
        }

        public void RemoveWindow()
        {
            string value = _windowDatabase.StringGet(_userName).ToString();

            int windowCount;
            int.TryParse(value, out windowCount);

            if (windowCount > 0)
                _windowDatabase.StringSet(_userName, --windowCount);
        }

        public void ResetCounter()
        {
            _windowDatabase.StringSet(_userName, "0");
        }

        public IEnumerable<string> GetAllUsers()
        {
            IEnumerable<RedisKey> redisKeys = _redisServer.Keys(_windowDatabase.Database, UserNameKeyPrefix + "*", 100);

            List<string> userNames = redisKeys.Select(x => x.ToString().Replace(UserNameKeyPrefix, "")).ToList();

            return userNames;
        }
    }
}