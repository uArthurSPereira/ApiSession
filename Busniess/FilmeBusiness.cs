using System;

namespace ApiSession.Busniess
{
    public class FilmeBusiness
    {
       DataBase.FilmeDatabase db = new DataBase.FilmeDatabase();

       
       public Models.TbFilme Inserir(Models.TbFilme filme)
       {
            if (filme.NmFilme == string.Empty)
                    throw new ArgumentException("Filme Obrigatório");
            if (filme.DsGenero == string.Empty)
                    throw new ArgumentException("Gênero obrigatório");
            if (filme.NrDuracao <= 0)
                    throw new ArgumentException("Duração obrigatória");

            return db.Inserir(filme);
       }
    }
}