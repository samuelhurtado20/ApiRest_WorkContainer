using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    /// <summary>
    /// Customer API
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IWorkContainer _workContainer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="workContainer"></param>
        public CustomerController(ILogger<CustomerController> logger, IWorkContainer workContainer)
        {
            _logger = logger;
            _workContainer = workContainer;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>All customers</returns>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Elements not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var customers = _workContainer.Customer.GetAll();
                if (customers.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return base.StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get a single customer by Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single customer</returns>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Element not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("GetSingle")]
        public IActionResult GetSingle(Guid id)
        {
            try
            {
                var customer = _workContainer.Customer.GetFirstOrDefault(x => x.Id == id);
                _workContainer.Customer.Remove(customer);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return base.StatusCode(500, ex.Message);
            }
        }
    }
}
