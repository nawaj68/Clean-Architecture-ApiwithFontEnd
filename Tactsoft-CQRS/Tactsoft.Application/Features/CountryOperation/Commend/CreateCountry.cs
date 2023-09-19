using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CountryOperation.Commend;
public record CreateCountry(CountryVM CountryVM) : IRequest<CountryVM>;
public class CreateCountryHandelar: IRequestHandler<CreateCountry, CountryVM>
{
    private readonly ICountryRepository _countryrepository;
    private readonly IMapper _mapper;

    public CreateCountryHandelar(ICountryRepository countryrepository, IMapper mapper)
    {
        _countryrepository=countryrepository;
        _mapper=mapper;
    }

    public async Task<CountryVM> Handle(CreateCountry request, CancellationToken cancellationToken)
    {
        return await _countryrepository.InsertAsync(_mapper.Map<Domain.Entities.Country>(request.CountryVM));
    }
}

