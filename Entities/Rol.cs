namespace EFCoreUTN.Entities {

    public class Rol {

        public virtual int Id {get; set; }

        public virtual string Nombre {get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Id})";
        }

    }

}