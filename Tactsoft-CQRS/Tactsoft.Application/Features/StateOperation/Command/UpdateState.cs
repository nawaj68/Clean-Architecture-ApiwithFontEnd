using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.StateOperation.Command;
public record UpdateState(int Id, StateVM StateVM ):IRequest<StateVM>;
public class UpdateStateHandelar:IRequestHandler<UpdateState, StateVM>
{
    private readonly IStateRepository _staterepository;
    private readonly IMapper _mapper;
    public UpdateStateHandelar(IStateRepository stateRepository, IMapper mapper)
    {
        _staterepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<StateVM> Handle(UpdateState request, CancellationToken cancellationToken)
    {
        return await _staterepository.UpdateAsync(request.Id,_mapper.Map<State>(request.StateVM));
    }
}