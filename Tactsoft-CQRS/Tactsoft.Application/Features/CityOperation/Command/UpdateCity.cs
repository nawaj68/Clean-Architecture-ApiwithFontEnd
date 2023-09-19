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

namespace Tactsoft.Application.Features.CityOperation.Command;
public record UpdateCity(int Id, CityVM CityVM) : IRequest<CityVM>;
public class UpdateCityHandelar : IRequestHandler<UpdateCity, CityVM>
{
    private readonly ICityRepository _cityrepository;
    private readonly IMapper _mapper;
    public UpdateCityHandelar(ICityRepository cityRepository, IMapper mapper)
    {
        _cityrepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(UpdateCity request, CancellationToken cancellationToken)
    {
        return await _cityrepository.UpdateAsync(request.Id,_mapper.Map<City>(request.CityVM));
    }
}
