using MediatR;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repository.EntityRepository;

namespace Tactsoft.Application.Features.StudentOperation.Query;

public record GetStudentList() : IRequest<IEnumerable<StudentVM>>;


public class GetStudentListHandler : IRequestHandler<GetStudentList, IEnumerable<StudentVM>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<StudentVM>> Handle(GetStudentList request, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetAllAsync();
    }
}