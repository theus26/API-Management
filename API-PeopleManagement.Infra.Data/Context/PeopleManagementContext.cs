using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API_PeopleManagement.Infra.Data.Context;

public class PeopleManagementContext(DbContextOptions<PeopleManagementContext> options) : DbContext(options)
{
    public DbSet<Employees> Employees { get; set; }
    public DbSet<VacationRecord> VacationRecords { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<EmployeePosition> EmployeePositions { get; set; }
    public DbSet<Positions> Positions { get; set; }
    public DbSet<ChangeRecord> ChangeRecord { get; set; }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employees>(new EmployeesMap().Configure);
        modelBuilder.Entity<VacationRecord>(new VacationRecordMap().Configure);
        modelBuilder.Entity<ChangeRecord>(new ChangeRecordMap().Configure);
        modelBuilder.Entity<Users>(new UserMap().Configure);
        modelBuilder.Entity<Unit>(new UnitMap().Configure);
        modelBuilder.Entity<EmployeePosition>(new EmployeePositionMap().Configure);
        modelBuilder.Entity<Positions>(new PositionsMap().Configure);
    }
}