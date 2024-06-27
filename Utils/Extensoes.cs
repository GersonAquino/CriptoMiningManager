using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Utils
{
	public static class Extensoes
	{
		public static string GetDescricaoClasse(this Type tipo)
		{
			if (tipo?.IsClass != true)
				throw new ArgumentException($"Não é possível obter a descrição de {tipo?.Name ?? "null"}.");

			return tipo.GetCustomAttribute<DescriptionAttribute>().Description;
		}

		public static string GetDescricaoEnum(this Enum value)
		{
			FieldInfo campo = value.GetType().GetField(value.ToString());
			return campo.GetCustomAttribute<DescriptionAttribute>().Description;
		}

		public static List<string> GetDescricoesEnum(this Type tipo)
		{
			if (tipo?.IsEnum != true)
				throw new ArgumentException($"Não é possível obter as descrições de {tipo?.Name ?? "null"}.");

			FieldInfo[] campos = tipo.GetFields();
			List<string> valores = new(campos.Length - 1);

			for (int i = 0; i < campos.Length; i++)
			{
				if (campos[i].FieldType == tipo)
					valores.Add(campos[i].GetCustomAttribute<DescriptionAttribute>().Description);
			}

			return valores;
		}

		/// <summary>
		/// Permite executar uma operação simples em todos os elementos dum vetor AKA ForEach otimizado (usa um ciclo for).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="acao">Ação a executar em cada elemento. Dá acesso ao índice atual através do segundo parâmetro</param>
		public static void ForEach<T>(this T[] array, Action<T, int> acao)
		{
			for (int i = 0; i < array.Length; i++)
			{
				acao(array[i], i);
			}
		}
	}
}
