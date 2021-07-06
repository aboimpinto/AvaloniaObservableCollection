using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace AvaloniaObservableCollection.ViewModels
{
    public class FullyObservableCollection<T> : ObservableCollection<T>
        where T : INotifyPropertyChanged
    {
        public FullyObservableCollection() : base()
        {
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChganged);
        }

        private void CollectionChganged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach(var item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.CollectionItemChanged);
                }
            }

            if (e.OldItems != null)
            {
                foreach(var item in e.OldItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(this.CollectionItemChanged);
                }
            }
        }

        private void CollectionItemChanged(object? sender, PropertyChangedEventArgs e)
        {
             var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
             this.OnCollectionChanged(args);
        }
    }
}
