using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ggsport.Domain.Course;

[Table("course")]
public class CourseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    public List<ExerciseModel> Exercises { get; set; } = [];
}
