using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionsExtensionsEvents
{
    public class UserSubcriptions
    {
        private List<Subscription> _subscriptions;

        public UserSubcriptions(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace", nameof(name));

            _subscriptions = new List<Subscription>();
            Name = name;
        }

        public string Name { get; private set; }

        public void Add(Subscription subscription)
        {
            if (subscription == null)
                throw new ArgumentNullException("Subscription cannot be null", nameof(subscription));

            if (_subscriptions.Any(x => x.Title == subscription.Title))
                throw new DuplicationException("Название подписки должно быть уникальным");

            _subscriptions.Add(subscription);
        }

        public Subscription[] GetSubscriptions()
        {
            return _subscriptions.ToArray();
        }
    }

    public class DuplicationException : Exception
    {
        public DuplicationException() : base()
        {
        }

        public DuplicationException(string message) : base(message)
        {
        }

        public DuplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
