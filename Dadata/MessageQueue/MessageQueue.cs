using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using DaData.Singleton;

namespace DaData.MessageQueue
{
    public class MessageQueue : ConcurrentQueue<HttpRequestMessage>
    {
        protected static object MLock { get; } = new object();

        protected Timer Timer { get; }

        protected HttpClient Client => HttpClientSingleton.GetInstance();

        public MessageQueue()
        {
            Timer = new Timer(SendMessages, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        public void Enqueue(HttpRequestMessage message)
        {
            lock (MLock)
            {
                base.Enqueue(message);    
            }
        }

        protected virtual void SendMessages(object optional)
        {
            if (!IsEmpty)
            {
                lock (MLock)
                {
                    lock (Client)
                    {
                        while (TryDequeue(out HttpRequestMessage message))
                        {
                            Client.sen
                        }
                    }
                }
            }
        }
    }
}