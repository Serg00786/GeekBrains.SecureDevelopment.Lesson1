using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using GeekBrains._SecureDevelopment._Lesson1.Interfaces;
using System.Threading.Tasks;
using GeekBrains._SecureDevelopment._Lesson1.Models;

namespace GeekBrains._SecureDevelopment._Lesson1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankCardController : ControllerBase
    {
        private readonly IDBRequest _dbRequest;

        public BankCardController(
            IDBRequest dBRequest)
        {
            _dbRequest = dBRequest;
        }

        [HttpPost]
        [Route("createbankcard")]
        public IActionResult CreateOrder([FromBody] Bankcard bankcard)
        {
            _dbRequest.InsertRows(bankcard);

            return Ok("Success");
        }

        [HttpGet]
        [Route("getall")]
        public async Task<List<Bankcard>> GetAll()
        {
            return await _dbRequest.SelectRows(1);
        }
    }
}
