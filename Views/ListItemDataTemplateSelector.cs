using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaObservableCollection.Models;

namespace AvaloniaObservableCollection.Views
{
    public class ListItemDataTemplateSelector : IDataTemplate
    {
        public IDataTemplate Normal { get; set; }

        public IDataTemplate Checked { get; set; }

        public IControl Build(object param)
        {
            var obj = (ListItem)param;

            if (obj == null)
            {
                return this.Normal.Build(param);
            }

            if (obj.Checked)
            {
                return this.Checked.Build(param);
            }

            return this.Normal.Build(param);
        }

        public bool Match(object data)
        {
            return true;
        }
    }
}
