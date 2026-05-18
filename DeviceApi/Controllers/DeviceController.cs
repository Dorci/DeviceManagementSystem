using DeviceApi.Models;
using DeviceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _service;
        public DeviceController(IDeviceService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeviceResponseDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));
      
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeviceResponseDto>> GetById(Guid id, CancellationToken ct)
        {
            var device = await _service.GetByIdAsync(id, ct);
            return device is null ? NotFound() : Ok(device);
        }

        [HttpPost]
        public async Task<ActionResult<DeviceResponseDto>> Create(
            CreateDeviceRequestDto request, CancellationToken ct)
        {
            var newDevice = await _service.CreateAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = newDevice.SerialNumber }, newDevice);
        }
 
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id, UpdateDeviceRequestDto request, CancellationToken ct)
        {
            var updated = await _service.UpdateAsync(id, request, ct);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var deleted = await _service.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
