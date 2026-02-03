using Application.Interface.Repository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private List<Customer> _customers = new List<Customer>()
        {
            new Customer { customerId = 1, Name = "Transportes López S.A.", Razon_Social = "Transportes López S.A.", RFC = "TLA900101ABC", Email = "contacto@transporteslopez.com", Phone = "+1-809-555-0101", Alternative_Phone = "+1-809-555-0102", Address = "Av. Independencia 123, Santo Domingo", Alternative_Address = "Calle Secundaria 45, Santo Domingo" },
            new Customer { customerId = 2, Name = "Logística Norte SRL", Razon_Social = "Logística Norte SRL", RFC = "LNS801202XYZ", Email = "info@logisticanorte.com", Phone = "+1-809-555-0201", Alternative_Phone = "+1-809-555-0202", Address = "Km 10 Autopista Duarte, Santiago", Alternative_Address = "Parque Industrial, Santiago" },
            new Customer { customerId = 3, Name = "Carga Express", Razon_Social = "Carga Express SRL", RFC = "CEX850303DEF", Email = "ventas@cargaexpress.com", Phone = "+1-809-555-0301", Alternative_Phone = "+1-809-555-0302", Address = "Zona Franca, La Romana", Alternative_Address = "Bulevar Principal 200, La Romana" },
            new Customer { customerId = 4, Name = "Distribuciones Caribe", Razon_Social = "Distribuciones Caribe S.A.", RFC = "DCA870404GHI", Email = "servicio@distribucionescaribe.com", Phone = "+1-809-555-0401", Alternative_Phone = "+1-809-555-0402", Address = "Calle Comercio 88, Puerto Plata", Alternative_Address = "Muelle 2, Puerto Plata" },
            new Customer { customerId = 5, Name = "TransMarítima del Sur", Razon_Social = "TransMarítima del Sur SRL", RFC = "TMS920505JKL", Email = "operations@transmaritimasur.com", Phone = "+1-809-555-0501", Alternative_Phone = "+1-809-555-0502", Address = "Terminal Marítima, Santo Domingo Este", Alternative_Address = "Edificio 5, Santo Domingo Este" },
            new Customer { customerId = 6, Name = "ServiCarga Internacional", Razon_Social = "ServiCarga Internacional S.A.", RFC = "SCI880606MNO", Email = "contact@servicarga.com", Phone = "+1-809-555-0601", Alternative_Phone = "+1-809-555-0602", Address = "Av. Duarte 500, San Francisco de Macorís", Alternative_Address = "Polígono Industrial, San Francisco" },
            new Customer { customerId = 7, Name = "EcoTrans Solutions", Razon_Social = "EcoTrans Solutions SRL", RFC = "ETS930707PQR", Email = "hello@ecotrans.com", Phone = "+1-809-555-0701", Alternative_Phone = "+1-809-555-0702", Address = "Carretera Central Km 45, Bonao", Alternative_Address = "Calle Verde 12, Bonao" },
            new Customer { customerId = 8, Name = "AgroLogística RD", Razon_Social = "AgroLogística RD S.A.", RFC = "ALR940808STU", Email = "agro@agrologistica.com", Phone = "+1-809-555-0801", Alternative_Phone = "+1-809-555-0802", Address = "Ruta 6, Hato Mayor", Alternative_Address = "Camino Rural 7, Hato Mayor" },
            new Customer { customerId = 9, Name = "Express Norte", Razon_Social = "Express Norte SRL", RFC = "EXN951212VWX", Email = "support@expressnorte.com", Phone = "+1-809-555-0901", Alternative_Phone = "+1-809-555-0902", Address = "Av. 27 de Febrero 222, Santiago", Alternative_Address = "Oficina 10, Santiago" },
            new Customer { customerId = 10, Name = "Carga y Mudanzas Global", Razon_Social = "Carga y Mudanzas Global S.A.", RFC = "CMG961216YZA", Email = "info@cargamudanzasglobal.com", Phone = "+1-809-555-1001", Alternative_Phone = "+1-809-555-1002", Address = "Parque Logístico 1, La Vega", Alternative_Address = "Centro Comercial 3, La Vega" }
        };


        public async Task AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Customer>>(_customers);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
