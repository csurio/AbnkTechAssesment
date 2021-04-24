using AutoMapper;
using InventoryBL.DTOs;
using InventoryBL.DTOs.Commands;
using InventoryBL.Models;
using InventoryBL.Services.Interfaces;
using InventoryBL.Utils.Exceptions;
using InventoryBL.Utils.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService            _service;
        private readonly IMapper                    _mapper;
        public ProductController(ILogger<ProductController> logger,
                                 IProductService service,
                                 IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            var productsDTO = products.Select(p => _mapper.Map<ProductDTO>(p));
            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetById(id);
            if (product == null)
                return NotFound(new { message = "Resource Not Found" });

            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCommandDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product   = _mapper.Map<Product>(productDTO);
            var productDB = await _service.GetById(product.Id);

            try
            {
                if (productDB != null)
                {
                await _service.Detached(productDB);
                throw new ValidateException("Can not CREATE resource: already exists");
                }

                product.CreatedAt = DateTime.Now;
                product = await _service.Create(product);
                productDTO = _mapper.Map<ProductCommandDTO>(product);

                return Ok(productDTO);

            }
            catch (ValidateException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { message = ex.GetInnerMessages() });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.GetInnerMessages() });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProductCommandDTO productDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (productDTO.Id != id)
                    throw new ValidateException("Can not UPDATE : ID in URL not match with body resource");

                var productDB = await _service.GetById(id);

                if (productDB != null)
                    await _service.Detached(productDB);

                if (productDB == null)
                    return NotFound(new { message = "Can not UPDATE : Resource Not Found" });

            
                var product = _mapper.Map<Product>(productDTO);
                product.UpdatedAt = DateTime.Now;
                product = await _service.Update(product);
                return Ok(productDTO);
            }
            catch (ValidateException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { message = ex.GetInnerMessages() });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.GetInnerMessages() });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var product = await _service.GetById(id);

            if (product == null)
                return NotFound();
            try
            {
                if (await _service.DeleteCheckOnEntity(id))
                    throw new Exception("Can not DELETE resource: a foreign key constraint fails");
                
                await _service.Delete(id);
                return Ok(new { message = "Resource deleted successfuly" });

            }
            catch (ValidateException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { message = ex.GetInnerMessages() });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.GetInnerMessages() });
            }

        }

    }
}
