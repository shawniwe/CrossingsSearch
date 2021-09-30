using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher.Tools.Managers
{
    /// <summary>
    /// Родительский класс для Manager-классов
    /// </summary>
    public abstract class DefaultManager<T>
    {
        protected List<T> _items;
        protected List<T> _itemsToRemove;

        public DefaultManager()
        {
            _items = new List<T>();
            _itemsToRemove = new List<T>();
        }

        public void AddItems(params T[] items)
        {
            foreach (var i in items)
            {
                _items.Add(i);
            }
        }

        public void RemoveItem(params T[] items)
        {
            foreach (var i in items)
            {
                _itemsToRemove.Add(i);
            }

            foreach (var ir in _itemsToRemove)
            {
                _items.Remove(ir);
            }

            _itemsToRemove = new List<T>();
        }
    }
}
