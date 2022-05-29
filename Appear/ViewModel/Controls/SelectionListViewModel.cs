using Appear.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.ViewModel.Controls
{
    public class SelectionListViewModel : ObservableObject
    {
        private List<string> itemList { get; set; }
        public List<string> ItemList
        {
            get { return itemList; }
            set { itemList = value; OnPropertyChanged(); }
        }

        private string selectedItem { get; set; }
        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        private string id { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string text { get; set; }
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }
    }
}
