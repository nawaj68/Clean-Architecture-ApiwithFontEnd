using AutoMapper;
using MediatR;
using Tactsoft.Application.Common;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StateOperation.Query;
public record GetStateList() : IRequest<List<StateVM>>;
public class GetStateListHandelar:IRequestHandler<GetStateList,List<StateVM>>
{
    private readonly IStateRepository _staterepository;
    private readonly IMapper _mapper;

    public GetStateListHandelar(IStateRepository staterepository, IMapper mapper)
    {
           
        _staterepository = staterepository;
        _mapper = mapper;
    }
    public async Task<List<StateVM>> Handle(GetStateList request, CancellationToken cancellationToken)
    {
        //var result= await _staterepository.GetPageAsync(request.PageSize,request.PageIndex,
        //    s =>(string.IsNullOrEmpty(request.SearchText)||s.Name.Contains(request.SearchText)),
        //    o =>(o.OrderBy(o=> o.Name)),
        //    a=>a);

        //return result.ToPagingModel<State, StateVM>(_mapper);
        var result = await _staterepository.GetAllAsync();
        return _mapper.Map<List<StateVM>>(result);
    }
}
