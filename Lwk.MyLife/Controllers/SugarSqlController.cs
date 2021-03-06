using Lwk.MyLife.Core.CommonDtos;
using Lwk.MyLife.Dtos;
using Microsoft.Extensions.Options;

namespace Lwk.MyLife.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SugarSqlController : ControllerBase
{

    private readonly DbContext _dbContext;
    private readonly IOptions<CustomerConfigDto> _options;

    public SugarSqlController(DbContext dbContext, IOptions<CustomerConfigDto> options)
    {
        _dbContext = dbContext;
        _options = options;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentDto studentDto)
    {
        return Ok($"插入数据:{await _dbContext.StudentDto.InsertAsync(studentDto)}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] StudentDto studentDto)
    {
        return Ok($"hello world!:{await _dbContext.StudentDto.UpdateAsync(studentDto)}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok($"hello world!{await _dbContext.StudentDto.DeleteByIdAsync(id)}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var test = _options.Value;
        return Ok(await _dbContext.StudentDto.GetByIdAsync(id));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("Single/{id}")]
    public async Task<IActionResult> Single(int id)
    {
        return Ok(await _dbContext.StudentDto.GetSingleAsync(x => x.Id == id));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("List")]
    public async Task<IActionResult> List()
    {
        return Ok(await _dbContext.StudentDto.GetListAsync(x => x.Id > 10));
    }
}
