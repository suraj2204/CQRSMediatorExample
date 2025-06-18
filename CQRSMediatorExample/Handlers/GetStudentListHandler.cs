﻿using CQRSMediatorExample.Models;
using CQRSMediatorExample.Queries;
using CQRSMediatorExample.Repositories;
using MediatR;

namespace CQRSMediatorExample.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetails>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<StudentDetails>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
