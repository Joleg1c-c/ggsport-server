using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ggsport.Domain.Course;

[Table("exercise")]
public class ExerciseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    [Required]
    [Column("decription")]
    public required string Decription { get; set; }

    [Required]
    [Column("course_id")]
    public required int CourseId { get; set; }

    [Required]
    [ForeignKey(nameof(CourseId))]
    public required CourseModel Course { get; set; }
}
