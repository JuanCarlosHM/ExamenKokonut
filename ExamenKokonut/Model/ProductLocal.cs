namespace ExamenKokonut.Model
{

    using System.ComponentModel;
    using SQLite;

    public class ProductLocal
    {
        [PrimaryKey, AutoIncrement]
        public int ProductID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public override int GetHashCode()
        {
            return ProductID;

        }
    }
}

 