using System;

namespace ExceptionsExtensionsEvents
{
    public class Subscription
    {
        public Subscription(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or whitespace", nameof(title));

            Title = title;
        }

        public string Title { get; private set; }
    }
}
