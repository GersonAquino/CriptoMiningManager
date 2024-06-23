using System;

namespace GestorDados.Helpers
{
	internal static class Extensoes
	{
		/// <summary>
		/// Permite executar uma operação simples em todos os elementos dum vetor AKA ForEach otimizado (usa um ciclo for).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="acao">Ação a executar em cada elemento. Dá acesso ao índice atual através do segundo parâmetro</param>
		internal static void ForEach<T>(this T[] array, Action<T, int> acao)
		{
			for (int i = 0; i < array.Length; i++)
			{
				acao(array[i], i);
			}
		}
	}
}
