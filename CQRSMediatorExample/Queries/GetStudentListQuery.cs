using CQRSMediatorExample.Models;
using MediatR;

namespace CQRSMediatorExample.Queries
{
    public class GetStudentListQuery:IRequest<List<StudentDetails>>
    {
    }
}
