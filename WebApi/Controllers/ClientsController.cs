﻿using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await _clientService.GetClientsAsync();
            return Ok(result);
        }
    }
}
