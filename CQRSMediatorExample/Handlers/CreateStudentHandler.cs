using CQRSMediatorExample.Commands;
using CQRSMediatorExample.Models;
using CQRSMediatorExample.Repositories;
using MediatR;

namespace CQRSMediatorExample.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDetails> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = request.StudentName,
                StudentEmail = request.StudentEmail,
                StudentAddress = request.StudentAddress,
                StudentAge = request.StudentAge
            };
            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
