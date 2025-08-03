using System;

namespace GestorDados.Helpers;

internal static class Extensoes
{
	internal static void ForEach<T>(this T[] array, Action<T> acao)
	{
		for (int i = 0; i < array.Length; i++)
		{
			acao(array[i]);
		}
	}
}
