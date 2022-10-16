using EFCoreUTN.Entities;
using FluentNHibernate.Mapping;

namespace EFCoreUTN.Mappings
{

    public class RolMap : ClassMap<Rol>
    {
        public RolMap() {
            Table("Roles");
            Id(r=> r.Id);
            Map(r=> r.Nombre);
        }
    }

}