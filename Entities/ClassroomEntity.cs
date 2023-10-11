using System;
using System.Collections.Generic;

namespace FU_DEVER_BACKEND_TRAINING.Entities;

public sealed class ClassroomEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int NumberOfStudents { get; set; }

    public IEnumerable<StudentEntity> StudentEntities { get; set; }
}
