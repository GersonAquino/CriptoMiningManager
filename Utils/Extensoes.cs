using System;
using System.ComponentModel;
using System.Reflection;

namespace Utils
{
    public static class Extensoes
    {
        public static string GetDescricaoClasse(this Type tipo)
        {
            if (tipo.IsClass)
                return tipo.GetCustomAttribute<DescriptionAttribute>().Description;

            throw new ArgumentException($"Não é possível obter a descrição de {tipo.Name}.");
        }
        public static string GetDescricaoEnum(this Enum value)
        {
            Type tipo = value.GetType();
            //if (!tipo.IsEnum)
            //    throw new ArgumentException($"Não é possível obter a descrição de {tipo.Name}.");

            FieldInfo campo = tipo.GetField(value.ToString());
            return campo.GetCustomAttribute<DescriptionAttribute>().Description;
        }

        public static string[] GetDescricoesEnum(this Type tipo)
        {
            if (!tipo.IsEnum)
                throw new ArgumentException($"Não é possível obter as descrições de {tipo.Name}.");

            FieldInfo[] campos = tipo.GetFields();
            string[] valores = new string[campos.Length];

            for (int i = 0; i < campos.Length; i++)
            {
                valores[i] = tipo.GetCustomAttribute<DescriptionAttribute>().Description;
            }

            return valores;
        }
    }
}
