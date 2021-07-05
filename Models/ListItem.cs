using ReactiveUI;

namespace AvaloniaObservableCollection.Models
{
    public class ListItem : ReactiveObject
    {
        private bool _checked;
        private string _name = string.Empty;

        public bool Checked
        {
            get => this._checked;
            set => this.RaiseAndSetIfChanged(ref this._checked, value);
        }

        public string Name 
        { 
            get => this._name; 
            set => this.RaiseAndSetIfChanged(ref this._name, value); 
        }
    }
}
