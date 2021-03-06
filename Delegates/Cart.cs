using System.Collections.Generic;

namespace Delegates
{
    internal class Cart
    {
        private List<string> _products;
        private Notify _notify;

        public Cart(Notify notify) : this()
        {
            _notify = notify;
        }

        public Cart()
        {
            _products = new List<string>();
        }

        public void Add(string newProduct)
        {
            if (string.IsNullOrWhiteSpace(newProduct))
            {
                _notify?.Invoke("product cannot be null or whitespace!");
                return;
            }

            if (IsProductExists(newProduct))
            {
                _notify?.Invoke($"{newProduct}: product already exists!");
                return;
            }

            _products.Add(newProduct);
        }
        
        internal string Find(Checker checker)
        {
            foreach (var product in _products)
            {
                if (checker(product))
                {
                    return product;
                }
            }

            return null;
        }

        internal string GetProducts()
        {
            return string.Join("\n", _products);
        }

        internal void SetNotifier(Notify notify)
        {
            _notify = notify;
        }

        private bool IsProductExists(string newProduct)
        {
            foreach (var product in _products)
            {
                if (newProduct == product)
                    return true;
            }

            return false;
        }
    }
}
