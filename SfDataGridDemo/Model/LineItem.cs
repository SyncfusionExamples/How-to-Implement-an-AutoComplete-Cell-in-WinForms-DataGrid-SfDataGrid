using System.ComponentModel;

namespace SfDataGridDemo
{
    public class LineItem : INotifyPropertyChanged
    {
        private Material _material;
        public Material Material
        {
            get => _material;
            set
            {
                if (!Equals(_material, value))
                {
                    _material = value;
                    OnPropertyChanged(nameof(Material));
                    OnPropertyChanged(nameof(MaterialID));
                }
            }
        }

        public string MaterialID
        {
            get => Material?.ID;
            set
            {
                if (Material?.ID != value)
                {
                    OnPropertyChanged(nameof(MaterialID));
                }
            }
        }

        public double Parts { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
