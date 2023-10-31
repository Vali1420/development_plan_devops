using CarBillingApp.Data;
using CarBillingApp.Entities;
using CarBillingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBillingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarBillingController : ControllerBase
    {
        private DataContext _dataContext;

        public CarBillingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("addBill")]
        public async Task<IActionResult> AddBill([FromBody] AddBillModel addBillModel)
        {
            await _dataContext.BillingEntity.AddAsync(new BillingEntity
            {
                CustomerId = addBillModel.CustomerId,
                CustomerInformations = addBillModel.CustomerInformations,
                PurchasedDateTime = DateTime.Now,
                VIN = addBillModel.VIN
            });

            await _dataContext.SaveChangesAsync();

            return Ok(addBillModel.CustomerId);
        }

        [HttpGet]
        [Route("getBills")]
        public async Task<IActionResult> GetBills()
        {
            var firstEntity = _dataContext.BillingEntity.FirstOrDefault();
            IList<GetBillsModel> billingEntities = null;

            if (firstEntity != null)
            {
                billingEntities = _dataContext.BillingEntity.Select(x => new GetBillsModel()
                {
                    CustomerId = x.CustomerId,
                    CustomerInformations = x.CustomerInformations,
                    PurchasedDateTime = x.PurchasedDateTime,
                    VIN = x.VIN

                }).ToList();
            }

            return Ok(billingEntities);
        }
    }
}