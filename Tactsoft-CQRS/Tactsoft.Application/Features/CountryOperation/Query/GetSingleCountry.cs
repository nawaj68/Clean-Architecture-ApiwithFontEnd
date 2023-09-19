using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CountryOperation.Query;
public record GetSingleCountry(long Id) : IRequest<CountryVM>;
public class GetSingleCountryHandle: IRequestHandler<GetSingleCountry,CountryVM>
{
    private readonly ICountryRepository _countryRepository;
    public GetSingleCountryHandle( ICountryRepository countryrepository)
    {
            _countryRepository = countryrepository;
    }

    public async Task<CountryVM> Handle(GetSingleCountry request , CancellationToken cancellationToken)
    {
        return await _countryRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
    }
}
