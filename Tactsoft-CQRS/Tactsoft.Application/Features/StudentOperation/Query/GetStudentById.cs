using AutoMapper;
using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;

namespace Tactsoft.Application.Features.StudentOperation.Query;

public record GetStudentById(int Id) : IRequest<StudentVM>;

public class GetStudentByIdHandler : IRequestHandler<GetStudentById, StudentVM>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentVM> Handle(GetStudentById request, CancellationToken cancellationToken)
    {
        return await _studentRepository.FirstOrDefaultAsync(request.Id);
    }
}