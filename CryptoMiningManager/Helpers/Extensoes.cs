using System;
using System.ComponentModel;
using System.Reflection;

namespace CryptoMiningManager.Helpers
{
    internal static class Extensoes
    {
        internal static string GetDescricaoClasse(this Type tipo)
        {
            if (tipo.IsClass)
                return tipo.GetCustomAttribute<DescriptionAttribute>().Description;

            throw new ArgumentException($"Não é possível obter a descrição de {tipo.Name}.");
        }
    }
}
