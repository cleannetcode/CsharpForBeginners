using System;
using System.Collections.Generic;

namespace EventsAndExtensions
{
    public delegate void NotifyEventHandler(object sender, NotifyEventArgs eventArgs);

    public class NotifyEventArgs : EventArgs
    {
        public NotifyEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    internal class Program
    {
        internal static event NotifyEventHandler OnAction;

        private static void Main(string[] args)
        {
            var cart = new Cart();
            cart.AfterItemAdded += Print;
            cart.AfterItemAdded += Info;
            cart.ItemAdding += Print;
            cart.ItemAdding += Info;
            cart.BeforeItemAdded += Print;
            cart.BeforeItemAdded += Info;

            var smartCart = new SmartCart();
            smartCart.AfterItemAdded += Print;
            smartCart.AfterItemAdded += Info;
            smartCart.ItemAdding += Print;
            smartCart.ItemAdding += Info;
            smartCart.BeforeItemAdded += Print;
            smartCart.BeforeItemAdded += Info;

            cart.AddItem("test item");
            smartCart.AddItem("test item");
        }

        private static void SetAndInvokeEvent()
        {
            OnAction = Print;

            if (OnAction != null)
                OnAction.Invoke(null, new NotifyEventArgs("Hello World!"));
            else
                Console.WriteLine($"Event {nameof(OnAction)} cannot be null");
        }

        private static void Print(object sender, NotifyEventArgs eventArgs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(eventArgs.Message);
            Console.ResetColor();
        }

        private static void Info(object sender, NotifyEventArgs eventArgs)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(eventArgs.Message);
            Console.ResetColor();
        }
    }

    public class Cart
    {
        protected List<string> _items;
        private List<NotifyEventHandler> _beforeItemAddedNotifies;

        public Cart()
        {
            _items = new List<string>();
            _beforeItemAddedNotifies = new List<NotifyEventHandler>();
        }

        public event NotifyEventHandler BeforeItemAdded
        {
            add
            {
                _beforeItemAddedNotifies.Add(value);
            }

            remove
            {
                _beforeItemAddedNotifies.Remove(value);
            }
        }

        public event NotifyEventHandler ItemAdding;
        public event NotifyEventHandler AfterItemAdded;

        public virtual void AddItem(string item)
        {
            OnBeforeItemAdded(this, new NotifyEventArgs("OnBeforeItemAdded" + item));
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException(nameof(item));

            OnItemAdding(this, new NotifyEventArgs("OnBeforeItemAdded" + item));
            _items.Add(item);

            OnAfterItemAdded(this, new NotifyEventArgs("OnBeforeItemAdded" + item));
        }

        protected virtual void OnBeforeItemAdded(object sender, NotifyEventArgs eventArgs)
        {
            foreach (var notify in _beforeItemAddedNotifies)
            {
                notify.Invoke(this, eventArgs);
            }
        }

        protected virtual void OnItemAdding(object sender, NotifyEventArgs eventArgs)
        {
            ItemAdding?.Invoke(sender, eventArgs);
        }

        protected virtual void OnAfterItemAdded(object sender, NotifyEventArgs eventArgs)
        {
            AfterItemAdded?.Invoke(sender, eventArgs);
        }
    }

    public class SmartCart : Cart
    {
        public override void AddItem(string item)
        {
            OnBeforeItemAdded(this, new NotifyEventArgs("OnBeforeItemAdded SmartCart:" + item));

            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException(nameof(item));

            OnItemAdding(this, new NotifyEventArgs("OnItemAdding SmartCart:" + item));
            _items.Add(item);

            OnAfterItemAdded(this, new NotifyEventArgs("OnAfterItemAdded SmartCart:" + item));
        }
    }
}
