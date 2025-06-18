using CQRSMediatorExample.Commands;
using CQRSMediatorExample.Repositories;
using MediatR;

namespace CQRSMediatorExample.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetails == null) return default;

            return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
        }
    }
}
