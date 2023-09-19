using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CountryOperation.Commend;
public record DeleteCountry(long Id) : IRequest<CountryVM>;

public class DeleteCountryHandelar : IRequestHandler<DeleteCountry,CountryVM>
{
    private readonly ICountryRepository _countryrepository;
    private readonly IMapper _mapper;

    public DeleteCountryHandelar(ICountryRepository countryRepository, IMapper mapper)
    {
         _countryrepository = countryRepository;
        _mapper = mapper;
    }
    public async Task<CountryVM> Handle (DeleteCountry request, CancellationToken cancellationToken)
    {
        return await _countryrepository.DeleteAsync(request.Id);
    }
}
