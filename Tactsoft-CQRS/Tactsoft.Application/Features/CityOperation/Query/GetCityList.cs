using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Common;
using Tactsoft.Application.Common.Collection;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Application.Features.CityOperation.Query;
public record GetCityList() : IRequest<List<CityVM>>;
public class GetCityListHandelar: IRequestHandler<GetCityList,List<CityVM>>
{
    private readonly ICityRepository _cityrepository;
    private readonly IMapper _mapper;
    public GetCityListHandelar(ICityRepository cityRepository, IMapper mapper)
    {
        _cityrepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<List<CityVM>> Handle(GetCityList request, CancellationToken cancellationToken)
    {
        //var result = await _cityrepository.GetPageAsync(request.PageIndex,request.PageSize,
        //    s => (string.IsNullOrEmpty(request.SearchText) || s.Name.Contains(request.SearchText)),
        //    p => p.OrderBy(p => p.Name),
        //    se => se);

        //return result.ToPagingModel<City, CityVM>(_mapper);
        var result = await _cityrepository.GetAllAsync();
        return _mapper.Map<List<CityVM>>(result);
    }
}
