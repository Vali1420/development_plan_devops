using CarWebApp.Data;
using CarWebApp.Entities;
using CarWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebCarController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly HttpClient _httpClient;
        private readonly string _carBillingURI;

        public WebCarController(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _httpClient = new HttpClient();
            _carBillingURI = configuration["CarBillingAppUri"];
        }

        [HttpPost]
        [Route("addCar")]
        public async Task<IActionResult> AddCar([FromBody] AddCarModel addCarModel)
        {
            await _dataContext.CarEntity.AddAsync(new CarEntity()
            {
                VIN = addCarModel.VIN,
                Name = addCarModel.Name,
                Price = addCarModel.Price,
                Available = true
            });

            await _dataContext.SaveChangesAsync();

            return Ok(addCarModel.VIN);
        }

        [HttpPost]
        [Route("buyCar")]
        public async Task<IActionResult> BuyCar([FromQuery] Guid customerId, [FromBody] BuyCarModel buyCarModel)
        {
            var car = await _dataContext.CarEntity.FindAsync(buyCarModel.VIN);

            if (car != null && car.Available)
            {

                // connect to billing MicroService
                _httpClient.BaseAddress = new Uri(_carBillingURI);

                var response = await _httpClient.PostAsJsonAsync("addBill", new
                {
                    customerId = customerId,
                    vin = buyCarModel.VIN,
                    customerInformations = "Audi a4 143 kp 2.0 TDI"
                });

                var json = await response.Content.ReadAsStringAsync();

                //...

                car.Available = false;
                await _dataContext.SaveChangesAsync();

                return Ok($"Car was sold successfully and the customer ${customerId} received an invoice on his email address.");
            }
            else
            {
                return StatusCode(400, "Car is not available anymore");
            }
        }

        [HttpGet]
        [Route("getCars")]
        public async Task<IActionResult> GetCars()
        {
            var firstEntity = _dataContext.CarEntity.FirstOrDefault();
            IList<CarEntity> carEntities = null;

            if (firstEntity != null)
            {
                carEntities = _dataContext.CarEntity.Select(x => new CarEntity()
                {
                    VIN = x.VIN,
                    Name = x.Name,
                    Price = x.Price,
                    Available = x.Available

                }).ToList();
            }

            return Ok(carEntities);
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test()
        {
            return Ok("Test");
        }
    }
}