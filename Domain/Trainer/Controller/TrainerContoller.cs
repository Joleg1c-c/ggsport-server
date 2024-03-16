using AutoMapper;
using ggsport.Domain.Trainer.Model;
using ggsport.Domain.Trainer.Model.Entity;
using ggsport.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ggsport.Domain.Trainer.Controller;

[Route("[controller]/[action]")]
[ApiController]
[Authorize(Roles = "admin")]
public class TrainerContoller(IMapper mapper, IService<TrainerModel> service) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IService<TrainerModel> _service = service;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entity = await _service.GetAsync();
        var dto = _mapper.Map<IEnumerable<TrainerRead>>(entity);
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return NotFound("Не найдено");
        var dto = _mapper.Map<TrainerRead>(entity);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TrainerCreate dto)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        var entity = _mapper.Map<TrainerModel>(dto);
        await _service.InsertAsync(entity);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TrainerCreate dto)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        var entity = _mapper.Map<TrainerModel>(dto);
        entity.Id = id;
        await _service.UpdateAsync(entity);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        await _service.DeleteAsync(id);
        return Ok();
    }
}
