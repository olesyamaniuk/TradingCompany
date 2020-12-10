using BusinessLogic.Interfaces;
using Dal.Interfaces;
using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Adress:IAdress
    {
        private readonly IAdressDal _adressDal;
        public Adress(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public AdressDTO AddAdress(int CountryId, string city, string street)
        {
            return _adressDal.CreateAdress(new AdressDTO { City = city, Street = street });
        }

        public List<AdressDTO> GetAllAdresses()
        {
            return _adressDal.GetAllAdresses();
        }
    }
}
