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
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _service;
        private readonly IMapper _mapper;
        public ItemController(ILogger<ItemController> logger,
                                 IItemService service,
                                 IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var items = await _service.GetAll();
            var items = await _service.GetAllItems();
            var itemsDTO = items.Select(i => _mapper.Map<ItemDTO>(i));
            return Ok(itemsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var item = await _service.GetById(id);
            var item = await _service.GetItemById(id);
            if (item == null)
                return NotFound(new { message = "Resource Not Found" });

            var itemDTO = _mapper.Map<ItemDTO>(item);
            return Ok(itemDTO);

        }

        [HttpGet]
        [Route("sku/{search}")]
        public async Task<IActionResult> GetBySku(String search)
        {
            if ("*".Equals(search))
                search = "";

            //var item = await _service.GetById(id);
            var items = await _service.GetItemsBySku(search);
            if (items == null)
                return NotFound(new { message = "Resource Not Found" });

            var itemsDTO = items.Select(i => _mapper.Map<ItemDTO>(i));
            return Ok(itemsDTO);

        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemCommandDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _mapper.Map<Item>(itemDTO);
            try
            {
                item = await _service.CreateItem(item);
                itemDTO = _mapper.Map<ItemCommandDTO>(item);
                return Ok(itemDTO);
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
        public async Task<IActionResult> Put([FromBody] ItemCommandDTO itemDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            try
            {
                if (itemDTO.Id != id)
                throw new ValidateException("Can not UPDATE : ID in URL not match with body resource");

                var itemDB = await _service.GetById(id);

                if (itemDB == null)
                  return NotFound(new { message = "Can not UPDATE : Resource Not Found" });

                await _service.Detached(itemDB);

            
                var item = _mapper.Map<Item>(itemDTO);
                item.UpdatedAt = DateTime.Now;
                item = await _service.Update(item);
                return Ok(itemDTO);

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
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _service.GetById(id);

            if (item == null)
                return NotFound(new { message = "Resource Not Found" });
            try
            {
                await _service.Delete(id);
                return Ok(new { message = "Resource deleted successfuly" });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
