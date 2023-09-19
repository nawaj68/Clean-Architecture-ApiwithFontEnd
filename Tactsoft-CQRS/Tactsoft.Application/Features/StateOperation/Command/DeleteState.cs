using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.StateOperation.Command;
public record DeleteState(int Id) : IRequest<StateVM>;

public class DeleteStateHandelar : IRequestHandler<DeleteState, StateVM>
{
    private readonly IStateRepository _saterepository;
    private readonly IMapper _mapper;

    public DeleteStateHandelar(IStateRepository stateRepository, IMapper mapper)
    {
            _saterepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<StateVM> Handle(DeleteState request, CancellationToken cancellationToken)
    {
        return await _saterepository.DeleteAsync(request.Id);
    }
}
