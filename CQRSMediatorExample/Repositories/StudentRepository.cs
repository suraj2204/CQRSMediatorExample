using CQRSMediatorExample.Data;
using CQRSMediatorExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatorExample.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextClass _dbContextClass;

        public StudentRepository(DbContextClass dbContextClass) 
        {
            _dbContextClass = dbContextClass;
        }
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _dbContextClass.StudentDetails.Add(studentDetails);
            await _dbContextClass.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            var result = _dbContextClass.StudentDetails.Where(x => x.Id == id).FirstOrDefault();
            _dbContextClass.StudentDetails.Remove(result);
           return await _dbContextClass.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int id)
        {
            return await _dbContextClass.StudentDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _dbContextClass.StudentDetails.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _dbContextClass.StudentDetails.Update(studentDetails);
            return await _dbContextClass.SaveChangesAsync();
        }
    }
}
