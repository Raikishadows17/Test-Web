using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class EmployeeRepository : CreateRepository<EmployeeDTO,Employee> , IEmployeeRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public EmployeeRepository(IDbContextFactory dbContextFactory,IMapper mapper):base (dbContextFactory,mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllOperatorsAsync()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var result = await dbContext.Employees.Where(e => e.Active && e.EmployeeCategory.EmpCatId == 2)
                        .ProjectToType<EmployeeDTO>()
                        .ToListAsync();

            return result;

        }

        public async override Task UpdateAsync(EmployeeDTO entity)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var rowAffected = await dbContext.Employees.Where(e => e.Id == entity.EmpId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(e => e.EmpCatId, entity.EmpCatId)
                    .SetProperty(e => e.EmployeeNumber, entity.EmployeeNumber)
                    .SetProperty(e => e.Names, entity.Names)
                    .SetProperty(e => e.MiddleName, entity.MiddleName)
                    .SetProperty(e => e.LastName, entity.LastName)
                    .SetProperty(e => e.FullName, entity.FullName)
                    .SetProperty(e => e.Email, entity.Email)
                    .SetProperty(e => e.EntryDate, entity.EntryDate)
                    .SetProperty(e => e.Company, entity.Company)
                    .SetProperty(e => e.Guild, entity.Guild)
                    .SetProperty(e => e.Salary, entity.Salary)
                    .SetProperty(e => e.TerminationDate, entity.TerminationDate)
                    .SetProperty(e => e.BirthDate, entity.BirthDate)
                    .SetProperty(e => e.MaritalStatus, entity.MaritalStatus)
                    .SetProperty(e => e.Gender, entity.Gender)
                    .SetProperty(e => e.PhotoUrl, entity.PhotoUrl)
                    .SetProperty(e => e.RFC, entity.RFC)
                    .SetProperty(e => e.CURP, entity.CURP)
                    .SetProperty(e => e.NSS, entity.NSS)
                    .SetProperty(e => e.INE, entity.INE)
                    .SetProperty(e => e.DriveLicense, entity.DriveLicense)
                    .SetProperty(e => e.DriveLicenseDateExp, entity.DriveLicenseDateExp)
                    .SetProperty(e => e.CertificatedForeignDriver, entity.CertificatedForeignDriver)
                    .SetProperty(e => e.BloodType, entity.BloodType)
                    .SetProperty(e => e.EducationLevel, entity.EducationLevel)
                    .SetProperty(e => e.Comments, entity.Comments)
                );

            if (rowAffected == 0)
                throw new NotFoundException("No se pudo actualizar el empleado, talvez no exista un empleado con el id proporcionado");
            
            await dbContext.SaveChangesAsync();
        }
    }
}
