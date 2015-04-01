using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;
using System;

namespace Visivel
{
    public class RedisManager
    {
        private readonly ConnectionMultiplexer _redisConn;

        private const string Channel = "visivel";
        private const string HostAndPort = "cod.redistogo.com:10725";


        public RedisManager()
        {
            var configurationOptions = new ConfigurationOptions { Password = "be61827946a5d7a6b7333875104d4a26" };
            configurationOptions.EndPoints.Add(HostAndPort);

            _redisConn = ConnectionMultiplexer.Connect(configurationOptions);

        }

        public void Subscribe(Action<string> action)
        {
            var subscriber = _redisConn.GetSubscriber();
            subscriber.Subscribe(Channel, (channel, message) => action(message));
        }

        public void Publish(string value)
        {
            var subscriber = _redisConn.GetSubscriber();
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
        private readonly IDatabase _windowDatabase;
        private readonly IServer _redisServer;
        private readonly string _userName;
        private const string UserNameKeyPrefix = "UserName:";

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
            var value = _windowDatabase.StringGet(_userName);

            int windowCount;
            int.TryParse(value, out windowCount);

            _windowDatabase.StringSet(_userName, ++windowCount);
        }

        public int GetWindowCount()
        {
            var value = _windowDatabase.StringGet(_userName);

            int windowCount;
            int.TryParse(value, out windowCount);

            return windowCount;
        }

        public void RemoveWindow()
        {
            var value = _windowDatabase.StringGet(_userName).ToString();

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
            var redisKeys = _redisServer.Keys(_windowDatabase.Database, UserNameKeyPrefix + "*", 100);

            var userNames = redisKeys.Select(x => x.ToString().Replace(UserNameKeyPrefix,"")).ToList();
            
            return userNames;
        }
    }

}