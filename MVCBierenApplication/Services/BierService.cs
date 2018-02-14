using MVCBierenApplication.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Services
{
   
    public class BierService
    {
        private static Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();
        static BierService()
        {
            bieren[1] = (new Bier { Id = 1, Naam = "jupiler", Alcohol = 6.5f });
            bieren[2] = (new Bier { Id = 2, Naam = "Grimbergen", Alcohol = 7.2f });
            bieren[3] = (new Bier { Id = 3, Naam = "Duvel", Alcohol = 9.0f });
            bieren[4] = (new Bier { Id = 4, Naam = "Maes", Alcohol = 0.0f });
            bieren[5] = (new Bier { Id = 5, Naam = "Kriek", Alcohol = 4.5f });
        }
        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }
        public Bier Read (int id)
        {
            return bieren[id];
        }
        public void Delete(int id)
        {
            bieren.Remove(id);
        }
    }
}