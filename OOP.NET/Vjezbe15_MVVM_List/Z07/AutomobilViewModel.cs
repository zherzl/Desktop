using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Z07
{
    public class AutomobilViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Automobil automobil;

        public AutomobilViewModel(Automobil automobil)
        {
            this.automobil = automobil;
        }

        public String Marka
        {
            get { return this.automobil.Marka; }
            set 
            { 
                this.automobil.Marka = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Marka"));
                }
            }
        }

        public String Registracija 
        {
            get { return this.automobil.Registracija; }
            set 
            { 
                this.automobil.Registracija = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Registracija"));
            }
        }

        public String Boja
        {
            get { return this.automobil.Boja; }
            set 
            { 
                this.automobil.Boja = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Boja"));
            }
        }

        public int GodinaPrveReg
        {
            get { return this.automobil.GodinaPrveReg; }
            set 
            { 
                this.automobil.GodinaPrveReg = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("GodinaPrveReg"));
            }
        }
    }

    public class AutomobiliViewModel
    {
        public static List<AutomobilViewModel> GetAuti()
        {
            List<AutomobilViewModel> auti = new List<AutomobilViewModel>();

            AutomobiliDatabaseList.GetAuti().ForEach(o => auti.Add(new AutomobilViewModel(o)));

            return auti;
        }
    }
}
