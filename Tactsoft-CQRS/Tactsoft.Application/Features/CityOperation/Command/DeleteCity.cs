using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.CityOperation.Command;
public record DeleteCity(int Id) : IRequest<CityVM>;

public class DeleteCityHandelar : IRequestHandler<DeleteCity, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    public DeleteCityHandelar(ICityRepository cityRepository, IMapper mapper)
    {
            _cityRepository = cityRepository;
            _mapper = mapper;
    }
    public async Task<CityVM> Handle(DeleteCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.DeleteAsync(request.Id);
    }
}
