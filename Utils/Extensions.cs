using System;
using System.ComponentModel;
using System.Reflection;

namespace Utils;

public static class Extensions
{
	public static string GetClassDescription(this Type type)
	{
		if (type.IsClass)
			return type.GetCustomAttribute<DescriptionAttribute>().Description;

		throw new ArgumentException($"Não é possível obter a descrição de {type.Name}.");
	}

	public static string GetDescricaoEnum(this Enum value)
	{
		FieldInfo field = value.GetType().GetField(value.ToString());
		return field.GetCustomAttribute<DescriptionAttribute>().Description;
	}

	public static string[] GetDescricoesEnum(this Type type)
	{
		if (!type.IsEnum)
			throw new ArgumentException($"Não é possível obter as descrições de {type.Name}.");

		FieldInfo[] fields = type.GetFields();
		string[] values = new string[fields.Length];

		for (int i = 0; i < fields.Length; i++)
		{
			values[i] = type.GetCustomAttribute<DescriptionAttribute>().Description;
		}

		return values;
	}
}
