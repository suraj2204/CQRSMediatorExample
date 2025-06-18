using CQRSMediatorExample.Models;
using MediatR;

namespace CQRSMediatorExample.Queries
{
    public class GetStudentByIdQuery: IRequest<StudentDetails>
    {   
        public int Id { get; set; }
    }
}
