namespace Lwk.MyLife.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly ILogger<ValuesController> _logger;
    public ValuesController(ILogger<ValuesController> logger)
    {

        _logger = logger;
    }
    // GET: api/<ValuesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInformation("有了吗！！！");
        return new string[] { "value1", "value2" };
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ValuesController>
    //[ActionFilter(IsCheck = false)]
    [HttpPost]
    public IActionResult Post([FromBody] TestModel testModel)
    {
        var list = new List<TestModel>();
        for (int i = 0; i < 10; i++)//10万条数据 数据量约100兆  测试结果表明；全局过滤器可以放心大胆的用
        {
            list.Add(new TestModel() { mKey = $"这是测试数据第{i}条key值", mValue = $"这是测试数据第{i}条value值" });
        }
        return NotFound(list);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
public class TestModel
{
    public string mKey { get; set; }
    public string mValue { get; set; }
}
