using Lwk.MyLife.Dtos;

namespace Lwk.MyLife.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SugarSqlController : ControllerBase
{

    private readonly DbContext _dbContext;

    public SugarSqlController(DbContext dbContext)
    {
        _dbContext = dbContext;
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
    public async Task<IActionResult> Update()
    {
        return Ok("hello world!");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        return Ok("hello world!");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Get hello world!");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("List")]
    public async Task<IActionResult> List()
    {
        return Ok("hello world!");
    }
}
