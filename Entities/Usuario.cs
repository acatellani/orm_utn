namespace EFCoreUTN.Entities
{

    public class Usuario
    {

        public virtual int Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual IList<Domicilio> Domicilios { get; set; }

        public override string ToString()
        {
            var output = $"{Nombre} ({Id})";
            if (Rol != null)
                output += $"\nRol: {Rol.ToString()}";
            if (Domicilios != null && Domicilios.Count > 0)
                output += $"\nDomicilios:\n{string.Join("\n", Domicilios.Select(c => c.ToString()))}";

            return output;
        }

    }

}