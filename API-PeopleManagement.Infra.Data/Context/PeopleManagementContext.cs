using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API_PeopleManagement.Infra.Data.Context;

public class PeopleManagementContext(DbContextOptions<PeopleManagementContext> options) : DbContext(options)
{
    public DbSet<Employees> Employees { get; set; }
    public DbSet<VacationRecord> VacationRecords { get; set; }
    public DbSet<ChangeRecord> ChangeRecord { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employees>(new EmployeesMap().Configure);
        modelBuilder.Entity<VacationRecord>(new VacationRecordMap().Configure);
        modelBuilder.Entity<ChangeRecord>(new ChangeRecordMap().Configure);
    }
}