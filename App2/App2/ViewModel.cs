using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string texto;

        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;this.Notify("Texto");
            }
        }

        public ICommand ToqueCommand
        {
            get;
            set;
        }

        public ViewModel()
        {
            this.ToqueCommand = new Command(this.Toque);
        }

        private int i = 1;
        private void Toque(object parameter)
        {
            this.Texto = string.Format("Toque número {0}", i++);
            Device.OpenUri(new Uri("http://www.fatecjd.edu.br/site/"));
        }

        private void Notify(string parameter)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(parameter));
            }
        }
    }
}
