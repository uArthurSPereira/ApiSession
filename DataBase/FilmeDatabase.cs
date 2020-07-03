using System;

namespace ApiSession.DataBase
{
    public class FilmeDatabase
    {
        Models.ApiSessionContext db = new Models.ApiSessionContext();

        public Models.TbFilme Inserir(Models.TbFilme filme)
        {
            db.TbFilme.Add(filme);
            db.SaveChanges();

            return filme;
        }
    }
}