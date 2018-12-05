using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAssignment.Models;
using System.Data.Entity;

namespace SAssignment.DAL
{
    public class ExerciseRepository : IExerciseRepository, IDisposable
    {

        private AssignmentEntities content;

        public ExerciseRepository(AssignmentEntities content)
        {
            this.content = content;
        }

        public IEnumerable<ExerciseRecord> GetExerciseRecords()
        {
            return content.ExerciseRecords.ToList();
        }

        public ExerciseRecord GetExerciseRecordByID(int id)
        {
            return content.ExerciseRecords.Find(id);
        }


        public void InsertStudent(ExerciseRecord obj)
        {
            content.ExerciseRecords.Add(obj);
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(ExerciseRecord obj)
        {
            content.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            content.SaveChanges();
        }



        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    content.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

               this.disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ExerciseRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}