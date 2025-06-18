using CQRSMediatorExample.Models;

namespace CQRSMediatorExample.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<StudentDetails>> GetStudentListAsync();
        public Task<StudentDetails> GetStudentByIdAsync(int id);
        public Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        public Task<int> UpdateStudentAsync(StudentDetails studentDetails);
        public Task<int> DeleteStudentAsync(int id);
    }
}
