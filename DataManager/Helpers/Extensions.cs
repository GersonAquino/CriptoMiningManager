using System;

namespace DataManager.Helpers;

internal static class Extensions
{
	internal static void ForEach<T>(this T[] array, Action<T> action)
	{
		for (int i = 0; i < array.Length; i++)
		{
			action(array[i]);
		}
	}
}
