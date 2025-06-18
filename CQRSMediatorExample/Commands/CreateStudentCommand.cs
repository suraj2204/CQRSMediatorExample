using CQRSMediatorExample.Models;
using MediatR;

namespace CQRSMediatorExample.Commands
{
    public class CreateStudentCommand:IRequest<StudentDetails>
    {   
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }

        public CreateStudentCommand(string studentName, string studenrEmail,string studentAddress,int studentAge)
        {   
            StudentName = studentName;
            StudentEmail = studenrEmail;
            StudentAddress = studentAddress;
            StudentAge = studentAge;
        }

    }
}
