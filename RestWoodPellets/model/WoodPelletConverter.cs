using System.Net.Sockets;
using WoodPelletsLib.model;

namespace RestWoodPellets.model
{
    public static class WoodPelletConverter
    {
        public static WoodPellet DTO2WoodPellet(WoodPelletDTO dto)
        {
            WoodPellet pellet = new WoodPellet();
            pellet.Id = dto.Id;
            pellet.Brand = dto.Brand;
            pellet.Price = dto.Price;
            pellet.Quality = dto.Quality;

            return pellet;
        }
    }
}
