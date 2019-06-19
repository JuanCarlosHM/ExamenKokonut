[assembly: Xamarin.Forms.Dependency(typeof(ExamenKokonut.Droid.Implementations.PathService))]

namespace ExamenKokonut.Droid.Implementations
{
    using Interface;
    using System;
    using System.IO;

    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "Examen.db3");
        }
    }

}
 