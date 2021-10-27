using System;
using System.Collections.Generic;
using DIO.Cadastros;
namespace DIO.Cadastros
{
	public class SerieRepositorio : IRepositorio<Conteudo>
	{
        private List<Conteudo> listaSerie = new List<Conteudo>();
		public void Atualiza(int id, Conteudo objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Conteudo objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Conteudo> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Conteudo RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}