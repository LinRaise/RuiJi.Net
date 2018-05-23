﻿using RuiJi.Node.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuiJi.Node.Feed
{
    public class FeedManager
    {
        private static FeedManager _elector = null;
        private static object _lck = new object();

        private List<string> serverMap = new List<string>();

        private ulong count = 0;

        public static FeedManager Instance
        {
            get
            {
                return _elector;
            }
        }

        static FeedManager()
        {
            _elector = new FeedManager();
        }

        private FeedManager()
        {
        }

        public void AddServer(string baseUrl)
        {
            lock (_lck)
            {
                if (!serverMap.Contains(baseUrl))
                    serverMap.Add(baseUrl);
            }
        }

        public void ClearAndAddServer(string[] baseUrls)
        {
            lock (_lck)
            {
                serverMap.Clear();
                foreach (var baseUrl in baseUrls)
                {
                    serverMap.Add(baseUrl);
                }
            }
        }

        public void RemoveServer(string baseUrl)
        {
            lock (_lck)
            {
                serverMap.Remove(baseUrl);
            }
        }

        public void Clear()
        {
            lock (_lck)
            {
                serverMap.Clear();
            }
        }
    }
}
