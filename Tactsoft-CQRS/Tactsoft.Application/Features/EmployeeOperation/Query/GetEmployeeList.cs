using AutoMapper;
using MediatR;
using Tactsoft.Application.Common;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.EmployeeOperation.Query;

public record GetEmployeeList(int PageIndex = CommonVariables.pageIndex, int PageSize = CommonVariables.pageSize, string SearchText = null) : IRequest<Paging<EmployeeVM>>;


public class GetEmployeeListHandler : IRequestHandler<GetEmployeeList, Paging<EmployeeVM>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeListHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<Paging<EmployeeVM>> Handle(GetEmployeeList request, CancellationToken cancellationToken)
    {
        var data = await _employeeRepository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) ||
            p.FirstName.Contains(request.SearchText) ||
            p.LastName.Contains(request.SearchText) ||
            p.Email.Contains(request.SearchText)),
            o => o.OrderBy(o => o.Id),
            se => se, i => i.Country, i => i.State, i => i.City);
        return data.ToPagingModel<Employee, EmployeeVM>(_mapper);
    }
}