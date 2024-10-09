using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.model
{
    public class WoodPellet
    {
        // instans felter
        private int _id;
        private string _brand;
        private int _price;
        private int _qaulity;

        // properties
        public int Id { get { return _id; } set { _id = value; } }

        public String Brand { get { return _brand; } 
            set { 
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Brand skal være mindst 2 tegn");
                } 
                _brand = value; } 
        }

        public int Price { get { return _price; } 
            set { 
                if (value <= 0)
                {
                    throw new ArgumentException("Price skal være et positivt tal");
                }
                _price = value; } 
        }

        public int Quality { get { return _qaulity; } 
            set { 
                if (value < 1 || 5 < value)
                {
                    throw new ArgumentException("Quality skal være et tal mellem 1-5");
                }
                _qaulity = value; } 
        }

        public WoodPellet(int id, string brand, int price, int quality)
        {
            Id = id;
            Brand = brand;
            Price = price;
            Quality = quality;
        }

        public WoodPellet():this(-1, "dummy", 1, 1)
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}}}";
        }
    }
}
