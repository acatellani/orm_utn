namespace EFCoreUTN.Entities {

    public class Domicilio {

        public virtual int Id { get; set; }

        public virtual string Calle { get; set; }

        public virtual int Numero { get; set; }

        public override string ToString()
        {
            return $"{Calle} Nº{Numero} ({Id})";
        }

    }

}