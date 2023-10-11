using System;

namespace FU_DEVER_BACKEND_TRAINING.DTOs.ClassroomDtos.Outgoings;

public sealed class GetAllStudentsDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public int NumberOfStudents { get; init; }
}
