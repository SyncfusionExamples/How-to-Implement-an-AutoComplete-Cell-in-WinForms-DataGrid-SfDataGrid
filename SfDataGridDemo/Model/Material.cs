using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SfDataGridDemo
{
    public class Material : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _synonyms;
        private string _cas;

        public string ID
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Synonyms
        {
            get => _synonyms;
            set
            {
                if (_synonyms != value)
                {
                    _synonyms = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CAS
        {
            get => _cas;
            set
            {
                if (_cas != value)
                {
                    _cas = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
