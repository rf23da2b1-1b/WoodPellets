using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.model.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        private WoodPellet _woodPellet;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _woodPellet = new WoodPellet();
        }


        /*
         * Brand
         */
        [TestMethod()]
        [DataRow("12")]
        [DataRow("1234567890")]
        public void WoodPelletBrandOk(string brand)
        {
            // arrange
            string expectedBrand = brand;

            // act
            _woodPellet.Brand = brand;

            // assert
            Assert.AreEqual(expectedBrand, _woodPellet.Brand);
        }

        [TestMethod()]
        [DataRow(null)]
        [DataRow("1")]
        [DataRow("")]
        [DataRow("   ")]
        public void WoodPelletBrandNotOk(string brand)
        {
            Assert.ThrowsException<ArgumentException>(  ()=> _woodPellet.Brand = brand);
        }

        /*
         * Quality
         */
        [TestMethod()]
        [DataRow(1)]
        [DataRow(5)]
        public void WoodPelletQualityOk(int quality)
        {
            // arrange
            int expectedQuality = quality;

            // act
            _woodPellet.Quality = quality;

            // assert
            Assert.AreEqual(expectedQuality, _woodPellet.Quality);
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(6)]
        [DataRow(-3)]
        public void WoodPelletQualityNotOk(int quality)
        {
            Assert.ThrowsException<ArgumentException>(() => _woodPellet.Quality = quality);
        }
    }
}