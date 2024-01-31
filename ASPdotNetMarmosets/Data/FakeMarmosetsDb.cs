using System.Security.Cryptography.X509Certificates;
using ASPdotNetMarmosets.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPdotNetMarmosets.Data
{
    public class FakeMarmosetsDb
    {
        private List<Marmosets> _marmosets;
        private int _lastId=0;


        public FakeMarmosetsDb() {

            _marmosets = new List<Marmosets>()
            {
                new Marmosets() {Id = ++_lastId, Nom = "Jo", Age = 8, Poids =14, Taille = 12 },
                new Marmosets() {Id = ++_lastId, Nom = "Fluti", Age = 4, Poids =7, Taille = 37 },
                new Marmosets() {Id = ++_lastId, Nom = "Clico", Age = 3, Poids =11, Taille = 42 },
            };
          
        }                                

 public List<Marmosets> GetAll()
        {
            return _marmosets;
        }

public Marmosets? GetById(int id) 
        {
            return _marmosets.FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Marmosets marmoset)
        {
            marmoset.Id = ++_lastId;
            _marmosets.Add(marmoset);
            return true;   
        }

        public bool Edit(Marmosets marmoset)
        {
            var marmosetFromDb = GetById(marmoset.Id);

            if(marmosetFromDb == null)
            {
                return false; 
            }
            else 
            {
                marmosetFromDb.Nom = marmoset.Nom;
                marmosetFromDb.Poids = marmoset.Poids;
                marmosetFromDb.Taille = marmoset.Taille;
                marmosetFromDb.Age = marmoset.Age;

                return true;
            }
        }
        public bool Delete(int x)
        {
            var marmoset = GetById(x);

            if(marmoset == null)
                return false;

			_marmosets.Remove(marmoset);
			return true;

		}

	}
}
