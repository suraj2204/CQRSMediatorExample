using MediatR;

namespace CQRSMediatorExample.Commands
{
    public class DeleteStudentCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
