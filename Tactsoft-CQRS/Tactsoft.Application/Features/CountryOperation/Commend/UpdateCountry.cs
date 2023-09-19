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

namespace Tactsoft.Application.Features.CountryOperation.Commend;
public record UpdateCountry(long Id,CountryVM CountryVM):IRequest<CountryVM>;
public class UpdateCountryHandle :IRequestHandler<UpdateCountry, CountryVM>
{
    private readonly ICountryRepository _countryrepository;
    private readonly IMapper _mapper;
    public UpdateCountryHandle(ICountryRepository countryRepository, IMapper mapper)
    {
            _countryrepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryVM> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        return await _countryrepository.UpdateAsync(request.Id, _mapper.Map<Country>(request.CountryVM));
    }
}
