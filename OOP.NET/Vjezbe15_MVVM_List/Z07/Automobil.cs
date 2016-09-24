using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Z07
{
    public class Automobil
    {
        //Marka, RegistarskaOznaka, Boja, GodinaPrveRegistracije
        public String Marka { get; set; }
        public String Registracija { get; set; }
        public String Boja { get; set; }
        public int GodinaPrveReg { get; set; }

    }





    public class AutomobiliDatabaseList
    {
        public static List<Automobil> GetAuti()
        {
            List<Automobil> auti = new List<Automobil>();

            auti.Add(new Automobil { Marka = "Honda", GodinaPrveReg = 2012, Boja = "Bijela", Registracija = "ZG-125 RR" });
            auti.Add(new Automobil { Marka = "Mercedes", GodinaPrveReg = 2006, Boja = "Crvena", Registracija = "KT-111 HH" });
            auti.Add(new Automobil { Marka = "Mazda", GodinaPrveReg = 2004, Boja = "Plava", Registracija = "PU-125 LA" });
            auti.Add(new Automobil { Marka = "Aston Martin", GodinaPrveReg = 2008, Boja = "Žuta", Registracija = "ZG-125 RR" });

            return auti;
        }
    }
}
