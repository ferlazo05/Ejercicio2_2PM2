using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ejercicio2_2.Models;
using SQLite;
using System.Threading.Tasks;

namespace Ejercicio2_2.Controllers
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection db;

        public DataBase(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<FirmaModel>().Wait();
        }

        public Task<List<FirmaModel>> GetFirmasList()
        {
            return db.Table<FirmaModel>().ToListAsync();
        }

        public Task<FirmaModel> GetFirmaID(int pcodigo)
        {
            return db.Table<FirmaModel>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GuadarFirma(FirmaModel firma)
        {
            if (firma.Id != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }

        public Task<int> EliminarFirma(FirmaModel firma)
        {
            return db.DeleteAsync(firma);
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
