using BahiaRealEstate.Services;
using BahiaRealEstate.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BahiaRealEstate_Test.Tests
{
    [TestClass]
    class SolarTesting
    {
        private readonly SolarCrud service;
        public SolarTesting()
        {
            service = new SolarCrud();
        }

        [TestMethod]
        public async Task getSolares()
        {
            var resultado = await service.getSolares();
            Assert.IsNotNull(resultado);
        }
    }
}
