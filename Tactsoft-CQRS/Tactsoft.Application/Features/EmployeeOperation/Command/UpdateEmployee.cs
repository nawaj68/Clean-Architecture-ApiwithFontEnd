using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Tactsoft.Application.Common;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Application.Repositories.EntityRepository;

namespace Tactsoft.Application.Features.EmployeeOperation.Command;

public record UpdateEmployee(int Id, EmployeeVM EmployeeVM) : IRequest<EmployeeVM>;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, EmployeeVM>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<EmployeeVM> Handle(UpdateEmployee request, CancellationToken cancellationToken)
    {
        if (request.EmployeeVM.PictureFile.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, CommonVariables.PictureLocation);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.EmployeeVM.PictureFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create, access: FileAccess.ReadWrite))
            {
                request.EmployeeVM.PictureFile.CopyTo(fileStream);
            }
            request.EmployeeVM.Picture = uniqueFileName;
        }
        return await _employeeRepository.UpdateAsync(request.Id, _mapper.Map<Domain.Entities.Employee>(request.EmployeeVM));
    }
}