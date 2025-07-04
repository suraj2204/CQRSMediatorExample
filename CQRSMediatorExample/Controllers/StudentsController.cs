﻿using CQRSMediatorExample.Commands;
using CQRSMediatorExample.Models;
using CQRSMediatorExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatorExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            var studentDetails =await  _mediator.Send(new GetStudentListQuery());
            return studentDetails;
        }

        [HttpGet("studentId")]
        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            var studentDetails = await _mediator.Send(new GetStudentByIdQuery() { Id = studentId });

            return studentDetails;
        }

        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var studentDetail = await _mediator.Send(new CreateStudentCommand(
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge));
            return studentDetail;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var isStudentDetailUpdated = await _mediator.Send(new UpdateStudentCommand(
               studentDetails.Id,
               studentDetails.StudentName,
               studentDetails.StudentEmail,
               studentDetails.StudentAddress,
               studentDetails.StudentAge));
            return isStudentDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await _mediator.Send(new DeleteStudentCommand() { Id = Id });
        }

    }
}
