using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CityOperation.Query;
public record GetSignalCity(long Id) : IRequest<CityVM>;
public class GetSignalCityHandelar : IRequestHandler<GetSignalCity, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    public GetSignalCityHandelar(ICityRepository cityRepository, IMapper mapper)
    {
            _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(GetSignalCity request,  CancellationToken cancellationToken)
    {
        return await _cityRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
    }
}
