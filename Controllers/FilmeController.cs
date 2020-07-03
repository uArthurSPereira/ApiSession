using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace ApiSession.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        Utils.FilmeConversor conversor = new Utils.FilmeConversor();
        Busniess.FilmeBusiness filmeBusiness = new Busniess.FilmeBusiness();

        [HttpPost]
        public ActionResult<Models.Response.FilmeResponce> Inserir(Models.Request.FilmeRequest req)
        {
               try
               {
                    Models.TbFilme filme = conversor.ParaFilme(req);   
                    filme = filmeBusiness.Inserir(filme);       
                    Models.Response.FilmeResponce resp = conversor.ParaResponse(filme);        
                    return resp;        
               }
               catch (System.Exception ex)
               {
                       return BadRequest(
                               new Models.Response.ErroResponse(404, ex.Message)
                       );
               }   
        }

        [HttpPut("{id}")]
        public Models.TbFilme Alterar(int id, Models.TbFilme filme)
        {
                Models.ApiSessionContext ctx = new Models.ApiSessionContext();
                Models.TbFilme atual = ctx.TbFilme.FirstOrDefault(x => x.IdFilme == id);
                atual.NmFilme = filme.NmFilme;
                atual.DsGenero = filme.DsGenero;
                atual.VlAvaliacao = filme.VlAvaliacao;
                atual.BtDisponivel = filme.BtDisponivel;
                atual.NrDuracao = filme.NrDuracao;
                atual.DtLancamento = filme.DtLancamento;                
                
                ctx.SaveChanges();
                return filme;
        }

        [HttpDelete("{id}")]
        public Models.TbFilme Deletar(int id)
        {
                Models.ApiSessionContext ctx = new Models.ApiSessionContext();
                Models.TbFilme atual = ctx.TbFilme.FirstOrDefault(x => x.IdFilme == id);
                ctx.TbFilme.Remove(atual);
                ctx.SaveChanges();

                return atual;
        }

        [HttpGet]
        public List<Models.TbFilme> Listar()
        {
                Models.ApiSessionContext ctx = new Models.ApiSessionContext();
                List<Models.TbFilme> filmes = ctx.TbFilme.ToList();
                return filmes;
        }

        [HttpGet("filtrar")]
        public List<Models.TbFilme> Filtrar(string nome, string genero)
        {
                Models.ApiSessionContext ctx = new Models.ApiSessionContext();

                List<Models.TbFilme> filmes =
                    ctx.TbFilme.Where(x => x.NmFilme.Contains(nome)
                                            && x.DsGenero.Contains(genero)).ToList();

                return filmes;
        }


        [HttpGet("{id}")]
        public Models.TbFilme FiltrarPorId(int id)
        {
                Models.ApiSessionContext ctx = new Models.ApiSessionContext();

                Models.TbFilme filme = ctx.TbFilme.FirstOrDefault(x => x.IdFilme == id);
                return filme;
        }

    }
}