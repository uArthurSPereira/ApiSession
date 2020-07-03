using System;

namespace ApiSession.Utils
{
    public class FilmeConversor
    {
        
        public Models.TbFilme ParaFilme(Models.Request.FilmeRequest req)
        {
            Models.TbFilme filme = new Models.TbFilme();
            filme.NmFilme = req.Filme;
            filme.DsGenero = req.Genero;
            filme.NrDuracao = req.Duracao;
            filme.VlAvaliacao = req.Avaliacao;
            filme.DtLancamento = req.Lancamento;
            filme.BtDisponivel = req.Disponivel;

            return filme;
        }

        public Models.Response.FilmeResponce ParaResponse(Models.TbFilme filme)
        {
            Models.Response.FilmeResponce resp = new Models.Response.FilmeResponce();
            resp.Id = filme.IdFilme;
            resp.Filme = filme.NmFilme;
            resp.Genero = filme.DsGenero;
            resp.Duracao = filme.NrDuracao;
            resp.Avaliacao = filme.VlAvaliacao;
            resp.Lancamento = filme.DtLancamento;
            resp.Disponivel = filme.BtDisponivel;

            return resp;
        }

    }
}