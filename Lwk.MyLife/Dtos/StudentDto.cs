using SqlSugar;

namespace Lwk.MyLife.Dtos;

/// <summary>
/// 学生Dto
/// </summary>
[SugarTable("Student")]
public class StudentDto
{
    [SugarColumn(IsPrimaryKey = true)]
    public int Id { get; set; }

    public string? SchoolId { get; set; }

    public string? Name { get; set; }

}