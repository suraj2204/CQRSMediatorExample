using CQRSMediatorExample.Commands;
using CQRSMediatorExample.Repositories;
using MediatR;

namespace CQRSMediatorExample.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetails == null) return default;

            studentDetails.StudentName = request.StudentName;
            studentDetails.StudentEmail = request.StudentEmail;
            studentDetails.StudentAddress = request.StudentAddress;
            studentDetails.StudentAge = request.StudentAge;
            
            return await _studentRepository.UpdateStudentAsync(studentDetails);
        }
    }
}
