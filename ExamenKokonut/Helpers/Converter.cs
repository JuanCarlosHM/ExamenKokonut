namespace ExamenKokonut.Helpers
{
    using ExamenKokonut.Model;
    using ExamenKokonut.ViewModel;

    public static class Converter
    {


        // VIOLACIÓN DEL PATRON DE ARQUITECTURA 
        // EL API NO DEVUELVE UNA RESPUESTA ADECUADA
        // LA COMUNICACIÓN DEBE SER UNICAMENTE ENTRE EL MODELO Y EL HELPER
        // CORREGIR 
        // PRIORIDAD: **
        //---------------

        public static ProductLocal ToProductLocal(ProductItemViewModel product)
        {
            return new ProductLocal
            {
                Title = product.Title,
                Body = product.Body

            };

        }

    }
}