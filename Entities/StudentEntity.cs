using System;

namespace FU_DEVER_BACKEND_TRAINING.Entities;

public sealed class StudentEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public Guid ClassroomId { get; set; }

    public ClassroomEntity ClassroomEntity { get; set; }
}
