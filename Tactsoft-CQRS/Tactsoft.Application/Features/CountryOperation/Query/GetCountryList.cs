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

namespace Tactsoft.Application.Features.CountryOperation.Query;
public record GetCountryList() : IRequest<List<CountryVM>>;

public class GetCountryListHandler : IRequestHandler<GetCountryList, List<CountryVM>>
{
    private readonly ICountryRepository _countryrepository;
    private readonly IMapper _mapper;

    public GetCountryListHandler(ICountryRepository countryRepository,IMapper mapper)
    {
        _countryrepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<List<CountryVM>> Handle(GetCountryList request, CancellationToken cancellationToken)
    {
        //var result = await _countryrepository.GetPageAsync(request.PageIndex,request.PageSize,
        //    p=>(string.IsNullOrEmpty(request.SearchText)||p.Name.Contains(request.SearchText)),
        //    o=>o.OrderBy(o=>o.Name),
        //    se=>se);
        //var result = await _countryrepository.GetAllAsync();
        //return _mapper.Map<List<CountryVM>>(result);
        return await _countryrepository.GetAllAsync();
    }
}

