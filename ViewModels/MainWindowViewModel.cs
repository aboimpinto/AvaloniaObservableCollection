using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AvaloniaObservableCollection.Models;
using ReactiveUI;

namespace AvaloniaObservableCollection.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ListItem> ListItems { get; private set; }

        public ICommand ChangeCommand { get; }

        public MainWindowViewModel()
        {
            this.ChangeCommand = ReactiveCommand.Create(this.OnChange);

            this.ListItems = new ObservableCollection<ListItem>();

            var lst = new List<ListItem>
            {
                new ListItem { Checked = false, Name="Item1" }, 
                new ListItem { Checked = true, Name="Item2" }, 
                new ListItem { Checked = false, Name="Item3" }, 
                new ListItem { Checked = false, Name="Item4" }
            };

            foreach(var item in lst)
            {
                this.ListItems.Add(item);
            }
        }

        private void OnChange()
        {
            foreach(var item in this.ListItems)
            {
                item.Checked = !item.Checked;
            }
        }
    }
}
