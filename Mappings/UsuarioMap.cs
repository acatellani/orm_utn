using EFCoreUTN.Entities;
using FluentNHibernate.Mapping;

namespace EFCoreUTN.Mappings
{

    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap() {
            Table("Usuarios");
            Id(r=> r.Id);
            Map(r=> r.Nombre);
            References(r=> r.Rol).Column("RolId");
            HasMany(r=> r.Domicilios).Cascade.All().KeyColumn("UsuarioId");
        }
    }

}