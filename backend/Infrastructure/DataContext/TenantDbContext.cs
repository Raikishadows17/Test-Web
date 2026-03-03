using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.DataContext
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

        #region DbSets

        // ── Catálogos ──────────────────────────────────────────
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<TripType> TripTypes { get; set; } = null!;
        public DbSet<PaymentTerms> PaymentTerms { get; set; } = null!;
        public DbSet<ContainerType> ContainerTypes { get; set; } = null!;
        public DbSet<CreditType> CreditTypes { get; set; } = null!;
        public DbSet<CreditStatus> CreditStatuses { get; set; } = null!;
        public DbSet<ShippingLine> ShippingLines { get; set; } = null!;
        public DbSet<PackagingType> PackagingTypes { get; set; } = null!;
        public DbSet<EventClassification> EventClassifications { get; set; } = null!;
        public DbSet<ItemsCatalog> ItemsCatalogs { get; set; } = null!;
        public DbSet<ClientCondition> ClientConditions { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<CustomerDocument> CustomerDocuments { get; set; } = null!;
        public DbSet<EquipmentDocument> EquipmentDocuments { get; set; } = null!;
        public DbSet<LogisticsProvider> LogisticsProviders { get; set; } = null!;
        public DbSet<IMO> IMO { get; set; } = null!;
        public DbSet<ServiceEventType> ServiceEventTypes { get; set; } = null!;
        public DbSet<StatusService> StatusServices { get; set; }
        public DbSet<EquipmentStatus> EquipmentStatus { get; set; }

        // ── Entidades principales ──────────────────────────────
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Terminal> Terminals { get; set; } = null!;
        public DbSet<EquipmentType> EquipmentTypes { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Container> Containers { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<Credit> Credits { get; set; } = null!;
        public DbSet<DateEventsType> DateEventsTypes { get; set; } = null!;

        // ── Detalle / Hijos ────────────────────────────────────
        public DbSet<ContainerSeals> ContainerSeals { get; set; } = null!;
        public DbSet<FullEmpty> FullEmpties { get; set; } = null!;
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; } = null!;
        public DbSet<EmployeeDisabled> EmployeeDisableds { get; set; } = null!;
        public DbSet<ForbiddenEmployee> ForbiddenEmployees { get; set; } = null!;
        public DbSet<EquipmentFile> EquipmentFiles { get; set; } = null!;
        public DbSet<EquipmentRepairLog> EquipmentRepairLogs { get; set; } = null!;
        public DbSet<CustomerFile> CustomerFiles { get; set; } = null!;
        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;
        public DbSet<IndustryType> IndustryTypes { get; set; } = null!;
        public DbSet<AppointmentTerminal> AppointmentTerminals { get; set; } = null!;
        public DbSet<LayoutName> LayoutNames { get; set; } = null!;
        public DbSet<LooseCommodity> LooseCommodities { get; set; } = null!;
        public DbSet<RoadRoutes> RoadRoutes { get; set; } = null!;
        public DbSet<ServicesDateEvents> ServicesDateEvents { get; set; } = null!;
        public DbSet<SchedulededAppointment> SchedulededAppointments { get; set; } = null!;
        public DbSet<TerminalTicket> TerminalTickets { get; set; } = null!;
        public DbSet<ItemsContract> ItemsContracts { get; set; } = null!;
        public DbSet<ServiceEvent> ServiceEvents { get; set; } = null;

        // ── Tablas puente (N:M) ────────────────────────────────
        public DbSet<UserRol> UserRoles { get; set; } = null!;
        public DbSet<CreditCustomer> CreditCustomers { get; set; } = null!;
        public DbSet<CustomerComment> CustomerComments { get; set; } = null!;
        public DbSet<ServicesComment> ServicesComments { get; set; } = null!;
        public DbSet<ProvideLogisticComments> ProvideLogisticComments { get; set; } = null!;
        public DbSet<AssignedEquipment> AssignedEquipments { get; set; } = null!;
        public DbSet<AssignedOperator> AssignedOperators { get; set; } = null!;
        public DbSet<OperatorEquipment> OperatorEquipments { get; set; } = null!;
        public DbSet<RoutesServices> RoutesServices { get; set; } = null!;
        public DbSet<Service_ServiceEvent> ServiceServiceEvents { get; set; } = null;

        // ── Polimórficas ───────────────────────────────────────
        public DbSet<PersonalAddress> PersonalAddresses { get; set; } = null!;
        public DbSet<PersonalContact> PersonalContacts { get; set; } = null!;

        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureEmployee(modelBuilder);
            ConfigureUser(modelBuilder);
            ConfigureUserRol(modelBuilder);
            ConfigureTerminal(modelBuilder);
            //ConfigureEquipmentType(modelBuilder);
            ConfigureEquipment(modelBuilder);
            ConfigureCustomer(modelBuilder);
            ConfigureCustomerType(modelBuilder);
            ConfigureIndustryType(modelBuilder);
            ConfigureContainer(modelBuilder);
            ConfigureContainerSeals(modelBuilder);
            ConfigureContract(modelBuilder);
            ConfigureItemsContract(modelBuilder);
            ConfigureCredit(modelBuilder);
            ConfigureCreditCustomer(modelBuilder);
            ConfigureCustomerComment(modelBuilder);
            ConfigureServicesComment(modelBuilder);
            ConfigureProvideLogisticComments(modelBuilder);
            ConfigureCustomerFile(modelBuilder);
            ConfigureEquipmentFile(modelBuilder);
            ConfigureEquipmentRepairLog(modelBuilder);
            ConfigureEmployeeCategory(modelBuilder);
            ConfigureEmployeeDisabled(modelBuilder);
            ConfigureForbiddenEmployee(modelBuilder);
            ConfigureServices(modelBuilder);
            ConfigureFullEmpty(modelBuilder);
            ConfigureAssignedEquipment(modelBuilder);
            ConfigureAssignedOperator(modelBuilder);
            ConfigureOperatorEquipment(modelBuilder);
            ConfigureLooseCommodity(modelBuilder);
            ConfigureAppointmentTerminal(modelBuilder);
            ConfigureLayoutName(modelBuilder);
            ConfigureDateEventsType(modelBuilder);
            ConfigureServicesDateEvents(modelBuilder);
            ConfigureSchedulededAppointment(modelBuilder);
            ConfigureRoadRoutes(modelBuilder);
            ConfigureRoutesServices(modelBuilder);
            ConfigureTerminalTicket(modelBuilder);
            ConfigurePersonalAddress(modelBuilder);
            ConfigurePersonalContact(modelBuilder);
            ConfigureServiceEvent(modelBuilder);
            ConfigureServiceServiceEvent(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IActivable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(IActivable.Active))
                        .HasDefaultValue(true);
                }
            }

            InsertIntoIMO(modelBuilder);
            InsertIntoTypeTrip(modelBuilder);
            InsertIntoEmployeeCategory(modelBuilder);
            InsertIntoRol(modelBuilder);
            InsertIntoEmployee(modelBuilder);
            InsertIntoUser(modelBuilder);
            InsertIntoUserRol(modelBuilder);
            InsertStatusService(modelBuilder);
            InsertIntoContainerType(modelBuilder);
            InsertIntoEquipmentType(modelBuilder);
            InsertIntoEquipmentStatus(modelBuilder);

            //TODO-INSERSIONES TEMPORALES, BORRAR
            InsertEmployeeTemporal(modelBuilder);
            InsertIntoLogisticsProviderTemporal(modelBuilder);
            InsertIntoTerminalTemporal(modelBuilder);
            InsertIntoShippingLineTemporal(modelBuilder);
            InsertIntoContainerTemporal(modelBuilder);
            InsertIntoEquipmentTemporal(modelBuilder);
        }

        #region Configure Methods

        private static void ConfigureEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(e => e.EmployeeCategory)
                      .WithMany()
                      .HasForeignKey(e => e.EmpCatId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();

                entity.HasOne(u => u.Employee)
                      .WithMany(e => e.Users)
                      .HasForeignKey(u => u.EmpId)
                      .OnDelete(DeleteBehavior.Restrict);

            });
        }

        private static void ConfigureUserRol(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRol>(entity =>
            {
                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(ur => ur.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ur => ur.Rol)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.RolId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void  ConfigureTerminal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.HasOne(t => t.LogisticsProvider)
                      .WithMany(lp => lp.Terminals)
                      .HasForeignKey(t => t.LogisticsProviderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        //private static void ConfigureEquipmentType(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EquipmentType>(entity =>
        //    {
        //        entity.HasOne(et => et.LogisticsProvider)
        //              .WithMany(lp => lp.EquipmentTypes)
        //              .HasForeignKey(et => et.LogisticsProviderId)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });
        //}

        private static void ConfigureEquipment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasOne(e => e.EquipmentType)
                      .WithMany()
                      .HasForeignKey(e => e.EquipTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Terminal)
                      .WithMany(t => t.Equipments)
                      .HasForeignKey(e => e.TerminalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.TripType)
                      .WithMany()
                      .HasForeignKey(e => e.TripTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.EquipmentStatus)
                      .WithMany()
                      .HasForeignKey(e => e.EquipmentStatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(c => c.TripType)
                      .WithMany()
                      .HasForeignKey(c => c.TripTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.PaymentTerm)
                      .WithMany(p => p.Customers)
                      .HasForeignKey(c => c.PaymentTermId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.ActualExecutive)
                      .WithMany()
                      .HasForeignKey(c => c.ActualExecutiveId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureCustomerType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasOne(ct => ct.Customer)
                      .WithMany(c => c.CustomerTypes)
                      .HasForeignKey(ct => ct.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ct => ct.ParentCustomer)
                      .WithMany()
                      .HasForeignKey(ct => ct.CustParentFF)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureIndustryType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndustryType>(entity =>
            {
                entity.HasOne(it => it.Customer)
                      .WithMany(c => c.IndustryTypes)
                      .HasForeignKey(it => it.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureContainer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>(entity =>
            {
                entity.HasOne(c => c.ContainerType)
                      .WithMany()
                      .HasForeignKey(c => c.ContainerTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.ContainerRed)
                      .WithMany()
                      .HasForeignKey(c => c.ContainerRedId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.ShippingLine)
                      .WithMany(sl => sl.Containers)
                      .HasForeignKey(c => c.ShippingLineId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureContainerSeals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContainerSeals>(entity =>
            {
                entity.HasOne(cs => cs.Container)
                      .WithMany(c => c.ContainerSeals)
                      .HasForeignKey(cs => cs.ContainerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureContract(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasOne(c => c.Customer)
                      .WithMany(cu => cu.Contracts)
                      .HasForeignKey(c => c.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.StatusCustomer)
                      .WithMany()
                      .HasForeignKey(c => c.StatusCustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.StatusContract)
                      .WithMany()
                      .HasForeignKey(c => c.StatusContractId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void ConfigureItemsContract(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsContract>(entity =>
            {
                entity.HasOne(ic => ic.Contract)
                      .WithMany(c => c.ItemsContracts)
                      .HasForeignKey(ic => ic.ContractId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ic => ic.ItemsCatalog)
                      .WithMany(cat => cat.ItemsContracts)
                      .HasForeignKey(ic => ic.ItemsCatalogId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ic => ic.ClientCondition)
                      .WithMany(cc => cc.ItemsContracts)
                      .HasForeignKey(ic => ic.ClientConditionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ic => ic.Status)
                      .WithMany()
                      .HasForeignKey(ic => ic.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureCredit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasOne(c => c.CreditType)
                      .WithMany(ct => ct.Credits)
                      .HasForeignKey(c => c.CreditTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.CreditStatus)
                      .WithMany(cs => cs.Credits)
                      .HasForeignKey(c => c.CreditStatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureCreditCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCustomer>(entity =>
            {
                entity.HasOne(cc => cc.Customer)
                      .WithMany(c => c.CreditCustomers)
                      .HasForeignKey(cc => cc.CustomerId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(cc => cc.Credit)
                      .WithMany(c => c.CreditCustomers)
                      .HasForeignKey(cc => cc.CreditId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void ConfigureCustomerComment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerComment>(entity =>
            {
                entity.HasOne(cc => cc.Customer)
                      .WithMany(c => c.CustomerComments)
                      .HasForeignKey(cc => cc.CustomerId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(cc => cc.Comment)
                      .WithMany(c => c.CustomerComments)
                      .HasForeignKey(cc => cc.CommentId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void ConfigureServicesComment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicesComment>(entity =>
            {
                entity.HasOne(sc => sc.Service)
                      .WithMany(s => s.ServicesComments)
                      .HasForeignKey(sc => sc.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sc => sc.Comment)
                      .WithMany(c => c.ServicesComments)
                      .HasForeignKey(sc => sc.ComentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureProvideLogisticComments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProvideLogisticComments>(entity =>
            {
                entity.HasOne(plc => plc.LogisticsProvider)
                      .WithMany(lp => lp.ProvideLogisticComments)
                      .HasForeignKey(plc => plc.ProvLogId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(plc => plc.Comment)
                      .WithMany(c => c.ProvideLogisticComments)
                      .HasForeignKey(plc => plc.CommentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureCustomerFile(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerFile>(entity =>
            {
                entity.HasOne(cf => cf.CustomerDocument)
                      .WithMany(cd => cd.CustomerFiles)
                      .HasForeignKey(cf => cf.CustDocId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cf => cf.Customer)
                      .WithMany(c => c.CustomerFiles)
                      .HasForeignKey(cf => cf.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureEquipmentFile(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentFile>(entity =>
            {
                entity.HasOne(ef => ef.EquipmentDocument)
                      .WithMany(ed => ed.EquipmentFiles)
                      .HasForeignKey(ef => ef.EqpmDocId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ef => ef.Equipment)
                      .WithMany(e => e.EquipmentFiles)
                      .HasForeignKey(ef => ef.EquipmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureEquipmentRepairLog(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentRepairLog>(entity =>
            {
                entity.HasOne(erl => erl.Equipment)
                      .WithMany(e => e.EquipmentRepairLogs)
                      .HasForeignKey(erl => erl.EquipmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureEmployeeCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCategory>(entity =>
            {
                entity.HasIndex(ec => ec.Category).IsUnique();
            });
        }

        private static void ConfigureEmployeeDisabled(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDisabled>(entity =>
            {
                entity.HasOne(ed => ed.Employee)
                      .WithMany(e => e.EmployeeDisableds)
                      .HasForeignKey(ed => ed.EmpId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void ConfigureForbiddenEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForbiddenEmployee>(entity =>
            {
                entity.HasOne(fe => fe.Employee)
                      .WithMany(e => e.ForbiddenEmployees)
                      .HasForeignKey(fe => fe.EmpId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(fe => fe.Terminal)
                      .WithMany(t => t.ForbiddenEmployees)
                      .HasForeignKey(fe => fe.TerminalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasOne(s => s.Equipment)
                      .WithMany()
                      .HasForeignKey(s => s.EquipamentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Container)
                      .WithMany(c => c.Services)
                      .HasForeignKey(s => s.ContainerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.TripType)
                      .WithMany()
                      .HasForeignKey(s => s.TripTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Customer)
                      .WithMany(c => c.Services)
                      .HasForeignKey(s => s.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.StatusService)
                      .WithMany()
                      .HasForeignKey(s => s.StatusServiceId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureFullEmpty(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullEmpty>(entity =>
            {
                entity.HasOne(fe => fe.Service)
                      .WithMany(s => s.FullEmpties)
                      .HasForeignKey(fe => fe.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(fe => fe.Container)
                      .WithMany(c => c.FullEmpties)
                      .HasForeignKey(fe => fe.ContainerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureAssignedEquipment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedEquipment>(entity =>
            {
                entity.HasOne(ae => ae.Equipment)
                      .WithMany(e => e.AssignedEquipments)
                      .HasForeignKey(ae => ae.EquipmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ae => ae.Service)
                      .WithMany(s => s.AssignedEquipments)
                      .HasForeignKey(ae => ae.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureAssignedOperator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedOperator>(entity =>
            {
                entity.HasOne(ao => ao.Employee)
                      .WithMany(e => e.AssignedOperators)
                      .HasForeignKey(ao => ao.EmpId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ao => ao.Service)
                      .WithMany(s => s.AssignedOperators)
                      .HasForeignKey(ao => ao.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureOperatorEquipment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperatorEquipment>(entity =>
            {
                entity.HasOne(oe => oe.AssignedOperator)
                      .WithMany(ao => ao.OperatorEquipments)
                      .HasForeignKey(oe => oe.AssignedOperatorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(oe => oe.AssignedEquipment)
                      .WithMany(ae => ae.OperatorEquipments)
                      .HasForeignKey(oe => oe.AssignedEquipmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureLooseCommodity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LooseCommodity>(entity =>
            {
                entity.HasOne(lc => lc.PackagingType)
                      .WithMany(pt => pt.LooseCommodities)
                      .HasForeignKey(lc => lc.PackagingTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(lc => lc.Service)
                      .WithMany(s => s.LooseCommodities)
                      .HasForeignKey(lc => lc.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureAppointmentTerminal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentTerminal>(entity =>
            {
                entity.HasOne(at => at.Terminal)
                      .WithMany(t => t.AppointmentTerminals)
                      .HasForeignKey(at => at.TerminalId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureLayoutName(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LayoutName>(entity =>
            {
                entity.HasOne(ln => ln.Terminal)
                      .WithMany(t => t.LayoutNames)
                      .HasForeignKey(ln => ln.TerminalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureDateEventsType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DateEventsType>(entity =>
            {
                entity.HasOne(det => det.Status)
                      .WithMany()
                      .HasForeignKey(det => det.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(det => det.UserReport)
                      .WithMany()
                      .HasForeignKey(det => det.UserReportId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureServicesDateEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicesDateEvents>(entity =>
            {
                entity.HasOne(sde => sde.Service)
                      .WithMany(s => s.ServicesDateEvents)
                      .HasForeignKey(sde => sde.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sde => sde.DateEventsType)
                      .WithMany(det => det.ServicesDateEvents)
                      .HasForeignKey(sde => sde.DateEventsTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sde => sde.EventClassification)
                      .WithMany(ec => ec.ServicesDateEvents)
                      .HasForeignKey(sde => sde.EventClassificationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureSchedulededAppointment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchedulededAppointment>(entity =>
            {
                entity.HasOne(sa => sa.AppointmentTerminal)
                      .WithMany(at => at.SchedulededAppointments)
                      .HasForeignKey(sa => sa.AppoTerminalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sa => sa.ServicesDateEvent)
                      .WithMany(sde => sde.SchedulededAppointments)
                      .HasForeignKey(sa => sa.ServicesDateEventsId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sa => sa.FullEmpty)
                      .WithMany(fe => fe.SchedulededAppointments)
                      .HasForeignKey(sa => sa.FullEmptyId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sa => sa.Container)
                      .WithMany(c => c.SchedulededAppointments)
                      .HasForeignKey(sa => sa.ContainerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureRoadRoutes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoadRoutes>(entity =>
            {
                entity.HasOne(rr => rr.TerminalOrigen)
                      .WithMany()
                      .HasForeignKey(rr => rr.TerminalOrigenId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(rr => rr.TerminalDestino)
                      .WithMany()
                      .HasForeignKey(rr => rr.TerminalDestinoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureRoutesServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoutesServices>(entity =>
            {
                entity.HasOne(rs => rs.RoadRoute)
                      .WithMany(rr => rr.RoutesServices)
                      .HasForeignKey(rs => rs.RoadRoutesId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rs => rs.Service)
                      .WithMany(s => s.RoutesServices)
                      .HasForeignKey(rs => rs.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureTerminalTicket(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TerminalTicket>(entity =>
            {
                entity.HasOne(tt => tt.Service)
                      .WithMany(s => s.TerminalTickets)
                      .HasForeignKey(tt => tt.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(tt => tt.Container1)
                      .WithMany()
                      .HasForeignKey(tt => tt.Container1Id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tt => tt.Container2)
                      .WithMany()
                      .HasForeignKey(tt => tt.Container2Id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tt => tt.Terminal)
                      .WithMany()
                      .HasForeignKey(tt => tt.TerminalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tt => tt.OperatorEquipment)
                      .WithMany(oe => oe.TerminalTickets)
                      .HasForeignKey(tt => tt.OperatorEquipmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurePersonalAddress(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalAddress>(entity =>
            {
                entity.HasOne(pa => pa.Employee)
                      .WithMany(e => e.PersonalAddresses)
                      .HasForeignKey(pa => pa.EmpId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pa => pa.Terminal)
                      .WithMany(t => t.PersonalAddresses)
                      .HasForeignKey(pa => pa.TerminalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pa => pa.Customer)
                      .WithMany(c => c.PersonalAddresses)
                      .HasForeignKey(pa => pa.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pa => pa.LogisticsProvider)
                      .WithMany(lp => lp.PersonalAddresses)
                      .HasForeignKey(pa => pa.LogisticsProviderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigurePersonalContact(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalContact>(entity =>
            {
                entity.HasOne(pc => pc.Employee)
                      .WithMany(e => e.PersonalContacts)
                      .HasForeignKey(pc => pc.EmpId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pc => pc.Terminal)
                      .WithMany(t => t.PersonalContacts)
                      .HasForeignKey(pc => pc.TerminalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pc => pc.Customer)
                      .WithMany(c => c.PersonalContacts)
                      .HasForeignKey(pc => pc.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pc => pc.LogisticsProvider)
                      .WithMany(lp => lp.PersonalContacts)
                      .HasForeignKey(pc => pc.LogisticsProviderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureServiceEvent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceEvent>(entity =>
            {
                entity.HasOne(se => se.ServiceEventType)
                      .WithMany()
                      .HasForeignKey(se => se.ServiceEventTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureServiceServiceEvent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service_ServiceEvent>(entity =>
            {
                entity.HasOne(sse => sse.Event)
                      .WithMany()
                      .HasForeignKey(sse => sse.ServiceEventId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sse => sse.Services)
                      .WithMany()
                      .HasForeignKey(sse => sse.ServiceId)
                      .OnDelete(DeleteBehavior.Restrict);

            });
        }

        #endregion

        #region InSertMethods

        private static void InsertIntoIMO(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<IMO>().HasData(
                    new IMO { Id = 1, Name = "Clase 1", Desc = "Explosivos" },
                    new IMO { Id = 2, Name = "Clase 2", Desc = "Gases (inflamables, no inflamables, tóxicos)" },
                    new IMO { Id = 3, Name = "Clase 3", Desc = "Líquidos inflamables (pinturas, gasolina)" },
                    new IMO { Id = 4, Name = "Clase 4", Desc = "Sólidos inflamables" },
                    new IMO { Id = 5, Name = "Clase 5", Desc = "Comburentes y peróxidos orgánicos" },
                    new IMO { Id = 6, Name = "Clase 6", Desc = "Tóxicos e infecciosos" },
                    new IMO { Id = 7, Name = "Clase 7", Desc = "Material radioactivo" },
                    new IMO { Id = 8, Name = "Clase 8", Desc = "Corrosivos" },
                    new IMO { Id = 9, Name = "Clase 9", Desc = "Mercancías peligrosas diversas (pilas de litio, etc.)" }
                );
        }

        private static void InsertIntoTypeTrip(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripType>().HasData(
                new TripType { Id = 1, Name = "Local", Desc = "Servicios locales", Active = true },
                new TripType { Id = 2, Name = "Foraneos", Desc = "Servicios foraneos", Active = true }
            );
        }

        private static void InsertIntoEmployeeCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCategory>().HasData(
                new EmployeeCategory
                {
                    EmpCatId = 1,
                    Category = "Administración",
                    CatDescription = "Personal administrativo del sistema",
                    Comments = "Categoría designada para el personal administrativo del sistema"
                },
                new EmployeeCategory
                {
                    EmpCatId = 2,
                    Category = "Operador",
                    CatDescription = "Personal operador de equipo",
                    Comments = "Categoría designada para el operador del equipo tracto"
                }
            );
        }

        private static void InsertIntoRol(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Name = "Administrador",
                    Descr = "Acceso total al sistema",
                    Active = true,
                    Comments = "Rol destinado para el Administrador del sistema"
                }
            );
        }

        private static void InsertIntoEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    EmpCatId = 1,
                    EmployeeNumber = "EMP-001",
                    Names = "Admin",
                    MiddleName = "Sistema",
                    LastName = "Principal",
                    FullName = "Admin Sistema Principal",
                    Email = "admin@sistema.com",
                    EntryDate = new DateTime(2026, 2, 18),
                    Company = null,
                    Guild = null,
                    Salary = null,
                    TerminationDate = null,
                    BirthDate = null,
                    MaritalStatus = null,
                    Gender = null,
                    PhotoUrl = null,
                    RFC = null,
                    CURP = null,
                    NSS = null,
                    INE = null,
                    DriveLicense = null,
                    DriveLicenseDateExp = null,
                    CertificatedForeignDriver = null,
                    BloodType = null,
                    EducationLevel = null,
                    Active = true,
                    Comments = null
                }
            );
        }

        private static void InsertIntoUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    EmpId = 1,
                    Username = "Administrador",
                    Password = "$2b$12$FiMusG28CiTnNFIQOBnxgutrY.y6ovbZINPT0IBDUw5fKvEshEg5m",
                    TokenId = null,
                    Active = true,
                    Comments = null
                }
            );
        }

        private static void InsertIntoUserRol(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRol>().HasData(
                new UserRol
                {
                    UserRolId = 1,
                    UserId = 1,
                    RolId = 1,
                    AssignDate = new DateTime(2026, 2, 18),
                    Active = true
                }
            );
        }
        
        private static void InsertStatusService(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusService>().HasData(
                new StatusService { Id = 1,  Name = "Registro ASLA",                        Desc = "Registro en ASLA",                              Clasification = "LocalLleno",   Sequence = 1 },
                new StatusService { Id = 2,  Name = "Espera Acceso",                        Desc = "En espera de acceso",                            Clasification = "LocalLleno",   Sequence = 2 },
                new StatusService { Id = 3,  Name = "Pase Terminal",                        Desc = "Pase a terminal",                                Clasification = "LocalLleno",   Sequence = 3 },
                new StatusService { Id = 4,  Name = "Ingreso Terminal",                     Desc = "Ingreso a terminal",                             Clasification = "LocalLleno",   Sequence = 4 },
                new StatusService { Id = 5,  Name = "Proceso Carga",                        Desc = "Proceso de carga del contenedor",                Clasification = "LocalLleno",   Sequence = 5 },
                new StatusService { Id = 6,  Name = "Salida Ruta Fiscal",                   Desc = "Salida por ruta fiscal",                         Clasification = "LocalLleno",   Sequence = 6 },
                new StatusService { Id = 7,  Name = "En Fila para Modular",                 Desc = "En fila para modulación",                        Clasification = "LocalLleno",   Sequence = 7 },
                new StatusService { Id = 8,  Name = "Ingreso Aduana",                       Desc = "Ingreso a aduana",                               Clasification = "LocalLleno",   Sequence = 8 },
                new StatusService { Id = 9,  Name = "Revisión Aduana",                      Desc = "Revisión en aduana",                             Clasification = "LocalLleno",   Sequence = 9 },
                new StatusService { Id = 10, Name = "Salida de Puerto y Resguardo a Patio", Desc = "Salida de puerto y resguardo a patio",           Clasification = "LocalLleno",   Sequence = 10 },
                new StatusService { Id = 11, Name = "Finalizado",                           Desc = "Servicio local lleno finalizado",                Clasification = "LocalLleno",   Sequence = 11 },
                
                new StatusService { Id = 12, Name = "Recolección en Patio",                 Desc = "Recolección de contenedor en patio",             Clasification = "LocalVacio",   Sequence = 1 },
                new StatusService { Id = 13, Name = "Registro ASLA",                        Desc = "Registro en ASLA",                               Clasification = "LocalVacio",   Sequence = 2 },
                new StatusService { Id = 14, Name = "Espera Acceso",                        Desc = "En espera de acceso",                            Clasification = "LocalVacio",   Sequence = 3 },
                new StatusService { Id = 15, Name = "Pase a Terminal",                      Desc = "Pase a terminal",                                Clasification = "LocalVacio",   Sequence = 4 },
                new StatusService { Id = 16, Name = "Ingreso a Terminal",                   Desc = "Ingreso a terminal",                             Clasification = "LocalVacio",   Sequence = 5 },
                new StatusService { Id = 17, Name = "Proceso de Descarga",                  Desc = "Proceso de descarga del contenedor",             Clasification = "LocalVacio",   Sequence = 6 },
                new StatusService { Id = 18, Name = "Salida a Puerto",                      Desc = "Salida a puerto",                                Clasification = "LocalVacio",   Sequence = 7 },
                new StatusService { Id = 19, Name = "Finalizado",                           Desc = "Servicio local vacío finalizado",                Clasification = "LocalVacio",   Sequence = 8 },
                
                new StatusService { Id = 20, Name = "Documentación",                        Desc = "Proceso de documentación",                       Clasification = "ForaneoLleno", Sequence = 1 },
                new StatusService { Id = 21, Name = "Recolección en Patio",                 Desc = "Recolección de contenedor en patio",             Clasification = "ForaneoLleno", Sequence = 2 },
                new StatusService { Id = 22, Name = "Inicio de Ruta",                       Desc = "Inicio de ruta foránea",                         Clasification = "ForaneoLleno", Sequence = 3 },
                new StatusService { Id = 23, Name = "Traslado",                             Desc = "Traslado a destino",                             Clasification = "ForaneoLleno", Sequence = 4 },
                new StatusService { Id = 24, Name = "Arribo a Bodega",                      Desc = "Arribo a bodega de destino",                     Clasification = "ForaneoLleno", Sequence = 5 },
                new StatusService { Id = 25, Name = "Proceso de Descarga",                  Desc = "Proceso de descarga en bodega",                  Clasification = "ForaneoLleno", Sequence = 6 },
                new StatusService { Id = 26, Name = "Retorno Unidad",                       Desc = "Retorno de la unidad",                           Clasification = "ForaneoLleno", Sequence = 7 },
                new StatusService { Id = 27, Name = "Resguardo de Contenedor",              Desc = "Resguardo del contenedor",                       Clasification = "ForaneoLleno", Sequence = 8 },
                new StatusService { Id = 28, Name = "Finalizado",                           Desc = "Servicio foráneo lleno finalizado",              Clasification = "ForaneoLleno", Sequence = 9 }
            );
        }

        private static void InsertIntoContainerType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContainerType>().HasData(
                new ContainerType { Id = 1, Name = "20'", Descr = "Contenedor de 20 pies", Active = true },
                new ContainerType { Id = 2, Name = "40'", Descr = "Contenedor de 40 pies" , Active = true },
                new ContainerType { Id = 3, Name = "45'", Descr = "Contenedor de 45 pies", Active = true },
                new ContainerType { Id = 4, Name = "OT", Descr = "Contenedor Open Top", Active = true },
                new ContainerType { Id = 5, Name = "RF", Descr = "Contenedor Refrigerado", Active = true },
                new ContainerType { Id = 6, Name = "TK", Descr = "Contenedor Tanque", Active = true }
            );
        }
        private static void InsertIntoEquipmentType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentType>().HasData(
                new EquipmentType { Id = 1, Name = "Tracto", Descr = "Equipo tipo tracto", Active = true },
                new EquipmentType { Id = 2, Name = "Caja seca", Descr = "Equipo tipo caja seca", Active = true },
                new EquipmentType { Id = 3, Name = "Plataforma", Descr = "Equipo tipo plataforma", Active = true },
                new EquipmentType { Id = 4, Name = "Lowboy", Descr = "Equipo tipo lowboy", Active = true },
                new EquipmentType { Id = 5, Name = "Refrigerado", Descr = "Equipo tipo refrigerado", Active = true },
                new EquipmentType { Id = 6, Name = "Tanque", Descr = "Equipo tipo tanque", Active = true },
                new EquipmentType { Id = 7, Name = "Chasis", Descr = "Chasis portacontenedor", FuelType = null, Comments = null, Active = true },
                new EquipmentType { Id = 8, Name = "Dolly", Descr = "Remolque auxiliar dolly", FuelType = null, Comments = null, Active = true }

            );
        }

        private static void InsertIntoEquipmentStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentStatus>().HasData(
                new EquipmentStatus { Id = 1, Name = "Disponible", Descr = "Equipo disponible para asignar a servicio", Active = true },
                new EquipmentStatus { Id = 2, Name = "En Ruta", Descr = "Equipo actualmente asignado a un servicio", Active = true },
                new EquipmentStatus { Id = 3, Name = "Mantenimiento", Descr = "Equipo en mantenimiento, no disponible para asignar a servicio", Active = true },
                new EquipmentStatus { Id = 4, Name = "Reparacion", Descr = "Equipo en reparacion, no disponible para asignar a servicio", Active = true },
                new EquipmentStatus { Id = 5, Name = "Red", Descr = "Equipo retenido por las autoridades, no disponible para asignar a servicio", Active = true },
                new EquipmentStatus { Id = 6, Name = "Fuera de Servicio", Descr = "Equipo fuera de servicio por daño o retiro, no disponible para asignar a servicio", Active = true }
            );
        }            

        private static void InsertEmployeeTemporal(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Employee>().HasData(
                // ===== OPERADORES LOCALES =====
                new Employee { Id = 2, EmpCatId = 2, Names = "Erineo", MiddleName = "Carranza", LastName = "Gonzales", FullName = "Erineo Carranza Gonzales", EntryDate = new DateTime(2023, 11, 14), Active = true },
                new Employee { Id = 3, EmpCatId = 2, Names = "Jeremias", MiddleName = "Salamanca", LastName = "Espinoza", FullName = "Jeremias Salamanca Espinoza", EntryDate = new DateTime(2024, 6, 25), Active = true },
                new Employee { Id = 4, EmpCatId = 2, Names = "Oliver Miguel", MiddleName = "Arellano", LastName = "Bravo", FullName = "Oliver Miguel Arellano Bravo", EntryDate = new DateTime(2025, 2, 24), Active = true },
                new Employee { Id = 5, EmpCatId = 2, Names = "Braian Ismael", MiddleName = "Castillo", LastName = "Gonzales", FullName = "Braian Ismael Castillo Gonzales", EntryDate = new DateTime(2025, 5, 10), Active = true },
                new Employee { Id = 6, EmpCatId = 2, Names = "Rafael Alejandro", MiddleName = "Torres", LastName = "Espino", FullName = "Rafael Alejandro Torres Espino", EntryDate = new DateTime(2025, 8, 2), Active = true },
                new Employee { Id = 7, EmpCatId = 2, Names = "Miguel Angel", MiddleName = "Torres", LastName = "Lugo", FullName = "Miguel Angel Torres Lugo", EntryDate = new DateTime(2025, 9, 23), Active = true },
                new Employee { Id = 8, EmpCatId = 2, Names = "Juan Carlos", MiddleName = "Medina", LastName = "Hernandez", FullName = "Juan Carlos Medina Hernandez", EntryDate = new DateTime(2025, 10, 1), Active = true },
                new Employee { Id = 9, EmpCatId = 2, Names = "Abraham", MiddleName = "Moreno", LastName = "Sanchez", FullName = "Abraham Moreno Sanchez", EntryDate = new DateTime(2025, 11, 13), Active = true },
                new Employee { Id = 10, EmpCatId = 2, Names = "Jairo Miguel", MiddleName = "Garcia", LastName = "Hernandez", FullName = "Jairo Miguel Garcia Hernandez", EntryDate = new DateTime(2025, 12, 6), Active = true },
                new Employee { Id = 11, EmpCatId = 2, Names = "David", MiddleName = "Romero", LastName = "Arteaga", FullName = "David Romero Arteaga", EntryDate = new DateTime(2025, 12, 15), Active = true },
                new Employee { Id = 12, EmpCatId = 2, Names = "Oliver Misael", MiddleName = "Rivera", LastName = "Fuentes", FullName = "Oliver Misael Rivera Fuentes", EntryDate = new DateTime(2025, 12, 17), Active = true },
                new Employee { Id = 13, EmpCatId = 2, EmployeeNumber = "035", Names = "Yair Alejandro", MiddleName = "Bautista", LastName = "Flores", FullName = "Yair Alejandro Bautista Flores", EntryDate = new DateTime(2025, 11, 21), Active = true },
                new Employee { Id = 14, EmpCatId = 2, EmployeeNumber = "034", Names = "Lucio Antonio", MiddleName = "Salazar", LastName = "Baltazar", FullName = "Lucio Antonio Salazar Baltazar", EntryDate = new DateTime(2025, 3, 20), Active = true },

                // ===== OPERADORES FORÁNEOS =====
                new Employee { Id = 15, EmpCatId = 2, Names = "Gustavo Fernando", MiddleName = "Pazarin", LastName = "Mejia", FullName = "Gustavo Fernando Pazarin Mejia", EntryDate = new DateTime(2024, 12, 18), CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 16, EmpCatId = 2, Names = "Rafael", MiddleName = "Regueyra", LastName = "Gomez", FullName = "Rafael Regueyra Gomez", EntryDate = new DateTime(2025, 7, 31), CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 17, EmpCatId = 2, Names = "Kevin Axel", MiddleName = "Coria", LastName = "Torres", FullName = "Kevin Axel Coria Torres", EntryDate = new DateTime(2025, 8, 10), CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 18, EmpCatId = 2, Names = "Luis Antonio", MiddleName = "Perez", LastName = "Serrano", FullName = "Luis Antonio Perez Serrano", EntryDate = new DateTime(2025, 12, 9), CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 19, EmpCatId = 2, Names = "Antonio", MiddleName = "Gutierrez", LastName = "Aguilar", FullName = "Antonio Gutierrez Aguilar", EntryDate = new DateTime(2026, 2, 17), CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 20, EmpCatId = 2, Names = "Ramon Alberto", MiddleName = "Zamarripa", LastName = "Rodriguez", FullName = "Ramon Alberto Zamarripa Rodriguez", CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 21, EmpCatId = 2, Names = "Luis Antonio", MiddleName = "Perez", LastName = "Cardenas", FullName = "Luis Antonio Perez Cardenas", EntryDate = new DateTime(2025, 12, 9), CertificatedForeignDriver = true, Active = true },
                new Employee { Id = 22, EmpCatId = 2, Names = "Josafat", MiddleName = "Villa", LastName = "Villaseñor", FullName = "Josafat Villa Villaseñor", EntryDate = new DateTime(2024, 11, 13), CertificatedForeignDriver = true, Active = true }
            );
        }

        private static void InsertIntoLogisticsProviderTemporal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogisticsProvider>().HasData(
                new LogisticsProvider { Id = 1, Name = "ASLA", FullName = "ASLA LOGISTICS", Active = true }
            );
        }

        private static void InsertIntoTerminalTemporal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().HasData(
                new Terminal { Id = 1, LogisticsProviderId = 1, TerminalCode = "SET", NameTerminal = "SETRASA", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 2, LogisticsProviderId = 1, TerminalCode = "BEL", NameTerminal = "BELUGA", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 3, LogisticsProviderId = 1, TerminalCode = "ATP", NameTerminal = "AT PACIFIC", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 4, LogisticsProviderId = 1, TerminalCode = "RI", NameTerminal = "RESGUARDO INTELIGENTE (RI)", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 5, LogisticsProviderId = 1, TerminalCode = "MAN", NameTerminal = "MANPORT", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 6, LogisticsProviderId = 1, TerminalCode = "LPC", NameTerminal = "LA PALMA CONTAINER", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 7, LogisticsProviderId = 1, TerminalCode = "VAS", NameTerminal = "VAS CONTAINER", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 8, LogisticsProviderId = 1, TerminalCode = "DAM", NameTerminal = "DAMCO", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 9, LogisticsProviderId = 1, TerminalCode = "CIM", NameTerminal = "CIMA", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 10, LogisticsProviderId = 1, TerminalCode = "MAO", NameTerminal = "MAOSA", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 11, LogisticsProviderId = 1, TerminalCode = "VAL", NameTerminal = "VALMARQ", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 12, LogisticsProviderId = 1, TerminalCode = "CAL", NameTerminal = "CALA", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 13, LogisticsProviderId = 1, TerminalCode = "HUT", NameTerminal = "HUTCHISON PORTS", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 14, LogisticsProviderId = 1, TerminalCode = "APM", NameTerminal = "APM TERMINALS", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 15, LogisticsProviderId = 1, TerminalCode = "NKS", NameTerminal = "NKS", Comments = null, UrlImage = null, Active = true },
                new Terminal { Id = 16, LogisticsProviderId = 1, TerminalCode = "UTT", NameTerminal = "UTTSA", Comments = null, UrlImage = null, Active = true }
            );
        }

        private static void InsertIntoShippingLineTemporal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingLine>().HasData(
                new ShippingLine { ShippingLineId = 1, Name = "Maersk", ShortName = "MAEU", Description = "A.P. Moller-Maersk", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 2, Name = "MSC", ShortName = "MSCU", Description = "Mediterranean Shipping Company", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 3, Name = "CMA CGM", ShortName = "CMDU", Description = "CMA CGM S.A.", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 4, Name = "Hapag-Lloyd", ShortName = "HLCU", Description = "Hapag-Lloyd AG", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 5, Name = "COSCO", ShortName = "COSU", Description = "COSCO Shipping Lines", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 6, Name = "Evergreen", ShortName = "EGLV", Description = "Evergreen Marine Corporation", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 7, Name = "ONE", ShortName = "ONEY", Description = "Ocean Network Express", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 8, Name = "Yang Ming", ShortName = "YMLU", Description = "Yang Ming Marine Transport Corp.", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 9, Name = "ZIM", ShortName = "ZIMU", Description = "ZIM Integrated Shipping Services", Comments = null, Active = true },
                new ShippingLine { ShippingLineId = 10, Name = "HMM", ShortName = "HDMU", Description = "Hyundai Merchant Marine", Comments = null, Active = true }
            );
        }

        private static void InsertIntoContainerTemporal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>().HasData(
                new Container { Id = 1, ContainerTypeId = 1, ContainerRedId = null, ShippingLineId = 1, ContainerNumber = "MAEU1234567", Size = "20", WeightKg = 2200m, ContainerTypeName = "Dry", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 2, ContainerTypeId = 1, ContainerRedId = null, ShippingLineId = 1, ContainerNumber = "MAEU7654321", Size = "40", WeightKg = 3800m, ContainerTypeName = "Dry", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 3, ContainerTypeId = 2, ContainerRedId = null, ShippingLineId = 2, ContainerNumber = "MSCU9876543", Size = "40", WeightKg = 3900m, ContainerTypeName = "High Cube", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 4, ContainerTypeId = 3, ContainerRedId = null, ShippingLineId = 3, ContainerNumber = "CMDU1122334", Size = "20", WeightKg = 2500m, ContainerTypeName = "Reefer", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 5, ContainerTypeId = 1, ContainerRedId = null, ShippingLineId = 4, ContainerNumber = "HLCU5566778", Size = "40", WeightKg = 3800m, ContainerTypeName = "Dry", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 6, ContainerTypeId = 2, ContainerRedId = null, ShippingLineId = 5, ContainerNumber = "COSU3344556", Size = "40", WeightKg = 3900m, ContainerTypeName = "High Cube", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 7, ContainerTypeId = 4, ContainerRedId = null, ShippingLineId = 6, ContainerNumber = "EGLV9988776", Size = "20", WeightKg = 2400m, ContainerTypeName = "Open Top", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 8, ContainerTypeId = 1, ContainerRedId = null, ShippingLineId = 7, ContainerNumber = "ONEY4455667", Size = "20", WeightKg = 2200m, ContainerTypeName = "Dry", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 9, ContainerTypeId = 5, ContainerRedId = null, ShippingLineId = 8, ContainerNumber = "YMLU6677889", Size = "40", WeightKg = 4000m, ContainerTypeName = "Flat Rack", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true },
                new Container { Id = 10, ContainerTypeId = 1, ContainerRedId = null, ShippingLineId = 9, ContainerNumber = "ZIMU1133557", Size = "40", WeightKg = 3800m, ContainerTypeName = "Dry", CntrDocumentRecuest = null, ArchieveRequest = null, CntrDocumentRfc = null, RfcCompany = null, CompanyName = null, RedEntryDate = null, RedLiberationDate = null, Active = true }
            );
        }

        private static void InsertIntoEquipmentTemporal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(
                // ==================== CHASIS LOCALES (32) ====================
                new Equipment { Id = 1, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM01", Plates = "6MM-828-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 2, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM04", Plates = "1MN-288-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 3, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM06", Plates = "7MM-529-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 4, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM07", Plates = "969-WR-2", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 5, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM08", Plates = "97-UM-6Y", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 6, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM09", Plates = "6MM-818-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 7, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM10", Plates = "6MM-827-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 8, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM13", Plates = "38-UN-4Y", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 9, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM14", Plates = "37-UA-4V", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 10, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM15", Plates = "7MM973-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 11, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM16", Plates = "8MM-321-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 12, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM21", Plates = "7MM-477-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 13, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM22", Plates = "7MM-473-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 14, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM23", Plates = "7MM-468-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 15, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM26 PLANA", Plates = "09-UP-5X", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 16, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM29", Plates = "7MM-960-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 17, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM30", Plates = "7MM-961-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 18, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM31", Plates = "6ML-081-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 19, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM33", Plates = "MM-969-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 20, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM34", Plates = "7MM-970-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 21, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM35", Plates = "MM-962-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 22, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM39", Plates = "8MM-325-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 23, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM41", Plates = "28-AP-6V", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 24, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM44", Plates = "9MM-710-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 25, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM45", Plates = "9MM-711-D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 26, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM46", Plates = "81-AP-6V", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 27, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "CH01JM", Plates = "2GK003A", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 28, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "CH57", Plates = "38-UN-4Y", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 29, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "CH54", Plates = "37-UA-4V", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 30, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "CH55", Plates = "NH-4360-C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 31, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "CHAZUL NUEVO58", Plates = "NH-4710-C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 32, EquipTypeId = 7, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "CHNUEVO59", Plates = "SIN PLACAS", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },

                // ==================== CHASIS FORANEOS (25) ====================
                new Equipment { Id = 33, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM11", Plates = "74-UU-7P", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 34, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM12", Plates = "75-UU-7P", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 35, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM18", Plates = "59-UP-3Z", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 36, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM19", Plates = "30-UP-3Z", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 37, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM20", Plates = "29-UP-3Z", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 38, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM24", Plates = "697-YH-7", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 39, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM36", Plates = "79UX5C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 40, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM37", Plates = "78UXSC", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 41, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM38", Plates = "80-UX-5C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 42, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM40", Plates = "77UX5C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 43, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM42", Plates = "ARENDADO", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 44, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM43", Plates = "023-YJ-3", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 45, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM48", Plates = "94UY8F", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 46, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM49", Plates = "93UY8T", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 47, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM50", Plates = "46-UZ-2M", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 48, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM51", Plates = "47-UZ-2M", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 49, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM52", Plates = "31VA1M", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 50, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM53", Plates = "28VA1M", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 51, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM56", Plates = "26VA1M", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 52, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM47", Plates = "65UU6D", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 53, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM54", Plates = "37-UA-4V", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 54, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM55", Plates = "NH-4360-C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 55, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM57", Plates = "38-UN-4Y", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 56, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM58", Plates = "NH-4710-C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 57, EquipTypeId = 7, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "VM59", Plates = "NH-4360-C", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },

                // ==================== DOLLYS LOCALES (15) ====================
                new Equipment { Id = 58, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD02", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 59, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD03", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 60, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD04", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 61, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD04", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 62, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD05", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 63, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "DL S/N JM PONER EL ECO VMD06", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 64, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD07", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 65, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD08", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 66, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VM09", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 67, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD10", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 68, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD13", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 69, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD14", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 70, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD15", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 71, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD16", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 72, EquipTypeId = 8, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "VMD17", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },

                // ==================== DOLLYS FORANEOS (7) ====================
                new Equipment { Id = 73, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL02", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 74, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL03", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 75, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL11", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 76, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL12", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 77, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL15", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 78, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL16", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 79, EquipTypeId = 8, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "DL D-03 (DL18)", Plates = "", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },

                // ==================== TRACTOS LOCALES (13) ====================
                new Equipment { Id = 80, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "001VM", Plates = "NC0379C", Color = "#FFFFFF", Active = true },
                new Equipment { Id = 81, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "004VM", Plates = "NS6913C", Color = "#0000FF", Active = true },
                new Equipment { Id = 82, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "006VM", Plates = "NN9650B", Color = "#0000FF", Active = true },
                new Equipment { Id = 83, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "007VM", Plates = "NB2438D", Color = "#FFFFFF", Active = true },
                new Equipment { Id = 84, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "009VM", Plates = "NS6908C", Color = "#FFFFFF", Active = true },
                new Equipment { Id = 85, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "010VM", Plates = "68BJ8L", Color = "#800080", Active = true },
                new Equipment { Id = 86, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "011VM", Plates = "NS6980C", Color = "#FF0000", Active = true },
                new Equipment { Id = 87, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "012VM", Plates = "NH3940C", Color = "#FFFFFF", Active = true },
                new Equipment { Id = 88, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "013VM", Plates = "NS7083C", Color = "#FFFFFF", Active = true },
                new Equipment { Id = 89, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "014VM", Plates = "NH4608C", Color = "#808080", Active = true },
                new Equipment { Id = 90, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "033VM", Plates = "NT9927B", Color = "#000000", Active = true },
                new Equipment { Id = 91, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "035VM", Plates = "NH9069B", Color = "#808080", Active = true },
                new Equipment { Id = 92, EquipTypeId = 1, TerminalId = 11, TripTypeId = 1, EquipmentStatusId = 1, EconomicNumber = "034VM", Plates = "NH9069B", Color = "#FF0000", Active = true },

                // ==================== TRACTOS FORANEOS (10) ====================
                new Equipment { Id = 93, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "101VM", Plates = "66-BG-9F", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 94, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "02VM", Plates = "67-BJ-8L", Color = "#FF0000", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 95, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "103VMF", Plates = "30-AX-8E", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 96, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "104VMF", Plates = "91AY4M", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null,  AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 97, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "105VM", Plates = "79-BG-4X", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 98, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "106VM", Plates = "87-BG-7A", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 99, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "107VM", Plates = "86-BG-7A", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 100, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "108VM", Plates = "82BL2C", Color = "#FF0000", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 101, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "109VM", Plates = "98BL2C", Color = "#FFFFFF", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true },
                new Equipment { Id = 102, EquipTypeId = 1, TerminalId = 11, TripTypeId = 2, EquipmentStatusId = 1, EconomicNumber = "110VM", Plates = "66-BJ-8L", Color = "#FF0000", PlatesEstate = null, DieselCapacity = null, TowingCapacity = null, AvailablePartners = false, LabeledUnit = false, Active = true }

            ); 
        }


        #endregion


    }
}
