using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2T2.Models;
using SQLite;
namespace PM2T2.Controles
{
    public class DataBase
    {


        readonly SQLiteAsyncConnection db;

        public DataBase(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Firmas>().Wait();
        }

        public Task<List<Firmas>> GetListSignatures()
        {
            return db.Table<Firmas>().ToListAsync();
        }

        public Task<Firmas> GetSignatureByCode(int signatureCode)
        {
            return db.Table<Firmas>()
                .Where(i => i.codigo == signatureCode)
                .FirstOrDefaultAsync();
        }

        public Task<int> saveSignature(Firmas signatures)
        {
            return signatures.codigo != 0 ? db.UpdateAsync(signatures) : db.InsertAsync(signatures);
        }

        public Task<int> deleteSignature(Firmas firmas)
        {
            return db.DeleteAsync(firmas);
        }
    }
}
