using System.Collections.ObjectModel;

namespace SfDataGridDemo
{
    public class Formula
    {
        public ObservableCollection<LineItem> LineItems { get; set; } = new ObservableCollection<LineItem>();
    }
}
