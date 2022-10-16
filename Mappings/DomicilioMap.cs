using EFCoreUTN.Entities;
using FluentNHibernate.Mapping;

namespace EFCoreUTN.Mappings
{

    public class DomicilioMap : ClassMap<Domicilio>
    {
        public DomicilioMap() {
            Table("Domicilios");
            Id(r=> r.Id);
            Map(r=> r.Calle);
            Map(r=>r.Numero);
            
        }
    }

}