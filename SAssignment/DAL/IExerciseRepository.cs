using SAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAssignment.DAL
{
    public interface IExerciseRepository : IDisposable
    {
        IEnumerable<ExerciseRecord> GetExerciseRecords();
        ExerciseRecord GetExerciseRecordByID(int id);
        void InsertStudent(ExerciseRecord obj);
        void DeleteStudent(int id);
        void UpdateStudent(ExerciseRecord obj);
        void Save();
    }
}