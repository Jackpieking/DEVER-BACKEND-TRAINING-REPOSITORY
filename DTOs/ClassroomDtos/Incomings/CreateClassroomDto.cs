using System.ComponentModel.DataAnnotations;

namespace FU_DEVER_BACKEND_TRAINING.DTOs.ClassroomDtos.Incomings;

public sealed class CreateClassroomDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; init; }

    [Required]
    public int NumberOfStudent { get; init; }
}
