namespace ExamenKokonut.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Interface;
    using SQLite;
    using Xamarin.Forms;

    public class DataService
    {

        private SQLiteAsyncConnection connection;

        public DataService()
        {
            this.OpenOrCreateDB();
        }

        private async Task OpenOrCreateDB()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            this.connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<ProductLocal>().ConfigureAwait(false);
        }

        public async Task Add<T>(T model)
        {
            await this.connection.InsertAsync(model);
        }
 
        public async Task Insert<T>(T model)
        {
            await this.connection.InsertAsync(model);
        }

        public async Task Insert<T>(List<T> models)
        {
            await this.connection.InsertAllAsync(models);
        }

        public async Task Update<T>(T model)
        {
            await this.connection.UpdateAsync(model);
        }

        public async Task Update<T>(List<T> models)
        {
            await this.connection.UpdateAsync(models);
        }

        public async Task Delete<T>(T model)
        {
            await this.connection.DeleteAsync(model);
        }

        public async Task<List<ProductLocal>> GetAllProducts()
        {
            var querry = await this.connection.QueryAsync<ProductLocal>("select * from [ProductLocal]");
            var array = querry.ToArray();
            var list = array.Select(p => new ProductLocal
            {
                Title = p.Title,
                Body = p.Body,
                ProductID = p.ProductID
            }).ToList();

            return list;
        }

        public async Task DeleteAllProducts()
        {
            var query = await this.connection.QueryAsync<ProductLocal>("delete from [ProductLocal]");
        }
    }
}
