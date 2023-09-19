using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.StateOperation.Query;
public record GetSingleState(int Id) : IRequest<StateVM>;
public class GetSingleStateHandelar:IRequestHandler<GetSingleState, StateVM>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    public GetSingleStateHandelar(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }
    public async Task<StateVM> Handle(GetSingleState request, CancellationToken cancellationToken)
    {
        return await _stateRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
    }
}
