﻿using DatabaseMicroService.DTO;
using DatabaseMicroService.Extensions;
using DatabaseMicroService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityPriceDataController : ControllerBase
    {
        private ElectricityDbContext _electricityDbContext;
        private ILogger<ElectricityPriceDataController> _logger;
        public ElectricityPriceDataController(ElectricityDbContext electricityDbContext, ILogger<ElectricityPriceDataController> logger)
        {
            //tähän servicet

            _electricityDbContext = electricityDbContext;
            _logger = logger;
        }   

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ElectricityPriceDataIn data)
        {
            // Tässä kohtaa voit tallentaa datan tietokantaan tai suorittaa jonkin muun toiminnon
            // Esimerkki: await _dataStorageService.StoreData(data);

            // Palautetaan vastaus, että data on vastaanotettu ja käsitelty

            if(data == null)
            {
                return BadRequest("Dataa ei vastaanotettu.");
            }

            try
            {
                foreach (var hourPrice in data.Prices)
                {
                    _electricityDbContext.ElectricityPriceDatas.Add(hourPrice.ToEntity());
                }

                await _electricityDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.LogError("Virhe tallennettaessa dataa tietokantaan.");

                return StatusCode(StatusCodes.Status500InternalServerError, "Virhe tallennettaessa dataa tietokantaan.");
                throw;
            }

            return Ok("Data vastaanotettu ja käsitelty.");
        }
    
    }
}
