using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using WoodPelletsLib.model;

namespace WoodPelletsLib.repositories
{
    public class WoodPelletRepository
    {
        // instans felter
        private readonly List<WoodPellet> _woodPellets;

        public WoodPelletRepository(bool mockData = false)
        {
            _woodPellets = new List<WoodPellet>();

            if (mockData)
            {
                PopulateWoodPellets();
            }
        }

        private void PopulateWoodPellets()
        {
            Add(new WoodPellet(0, "BioWood", 4995, 4));
            Add(new WoodPellet(0, "BioWood", 5195, 4));
            Add(new WoodPellet(0, "BilligPille", 4125, 1));
            Add(new WoodPellet(0, "GoldenWoodPellet", 5995, 5));
            Add(new WoodPellet(0, "GoldenWoodPellet", 5795, 5));

        }

        public List<WoodPellet> GetAll()
        {
            return new List<WoodPellet>(_woodPellets);
        }

        public WoodPellet GetById(int id)
        {
            WoodPellet? pellet = _woodPellets.Find(w => w.Id == id);

            if (pellet == null)
            {
                throw new KeyNotFoundException();
            }
            return pellet;
        }

        public WoodPellet Add(WoodPellet pellet)
        {
            pellet.Id = GenerateNewId();
            _woodPellets.Add(pellet);
            return pellet;
        }

        private int GenerateNewId()
        {
            return (_woodPellets.Count == 0)? 1 : _woodPellets.Max(w => w.Id) + 1;
        }

        public WoodPellet Update(int id, WoodPellet pellet)
        {
            WoodPellet updatePellet = GetById(id); // throw KeyNotFoundException
            _woodPellets[_woodPellets.IndexOf(updatePellet)] = pellet;
            return pellet;
        }



    }
}
