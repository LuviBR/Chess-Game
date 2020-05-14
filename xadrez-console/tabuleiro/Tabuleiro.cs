﻿using System;
using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console.tabuleiro
{
	class Tabuleiro
	{
		public int linhas { get; set; }
		public int colunas { get; set; }
		private Peca[,] pecas; //Matriz de Peças!

		public Tabuleiro (int linhas, int colunas)
		{
			this.linhas = linhas;
			this.colunas = colunas;
			pecas = new Peca[linhas, colunas];
		}

		public Peca peca(int linha, int coluna)
		{
			return pecas[linha, coluna];
		}

		public Peca peca (Posicao pos)
		{
			return pecas[pos.linha, pos.coluna];
		}

		internal void colocarPeca(Torre torre)
		{
			throw new NotImplementedException();
		}

		public bool existePeca(Posicao pos)
		{
			validarPosicao(pos);
			return peca(pos) != null;
		}

		public void colocarPeca(Peca p, Posicao pos)
		{
			if (existePeca(pos)) {
				throw new TabuleiroException("Já existe uma peça nessa posição!");
			}
			pecas[pos.linha, pos.coluna] = p;
			p.posicao = pos;

		}

		public bool posicaoValida(Posicao pos)
		{
			if(pos.linha<0 || pos.linha<=linhas || pos.coluna<0 || pos.coluna >= colunas){
				return false;
			}
			return true;
		}

		public void validarPosicao(Posicao pos)
		{
			if (!posicaoValida(pos)){
				throw new TabuleiroException("Posicao inválida!");
			}
		}
	}
}
