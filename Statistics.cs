using System;
using System.Collections.Generic; // Add other necessary namespaces

using Bookface.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bookface
{
    public class Statistics
    {
        private static Statistics _instance;
        private static int brojKorisnika;
        private static int brojAdministratora;
        private static int brojModeratora;

        public static Statistics GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Statistics();
            }
            return _instance;
        }

        public int DajBrojKorisnika() {
            return brojKorisnika;
        }

        public int DajBrojKorisnika() {
            return brojKorisnika;
        }
        
        public int DajBrojKorisnika() {
            return brojKorisnika;
        }
    }
}
