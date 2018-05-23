using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DesignPatterns.Intermediate
{    
    /*
    Define a one-to-many dependency between objects so that when one object changes state, 
        all its dependents are notified and updated automatically. 

    Note: This can be achieve using pub-sub, observable collection, IObserver/IObservable, INotifyPropertyChanged and etc.
     */
    
    /// <summary>
    /// Observable
    /// </summary>
    public class WatchedCollection
    {
        public ObservableCollection<string> _collection = new ObservableCollection<string>();
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public WatchedCollection()
        {
            _collection.CollectionChanged += CollectionChanged;
        }
        public void AddItem(string item) 
        {
            _collection.Add(item);
        }

        public void RemoveItem(string item){
            _collection.Remove(item);
        }
    }

    /// <summary>
    /// Observer
    /// </summary>
    public class Watcher {
        public void Watch(WatchedCollection _collection)
        {
            _collection.CollectionChanged += Act;
        }

        public void Act(object sender, NotifyCollectionChangedEventArgs args)
        {
            Console.WriteLine($"Item from collection was :{args.Action}.");
        }
    }
}
