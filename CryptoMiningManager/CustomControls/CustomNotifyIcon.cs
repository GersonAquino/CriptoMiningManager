using CryptoMiningManager.Helpers;
using GestorDados.Helpers;
using Modelos.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Utils;

namespace CryptoMiningManager.CustomControls
{
	public class CustomNotifyIcon
	{
		public NotifyIcon NotifyIcon { get; }

		/// <summary>
		/// <see cref="ToolStripMenuItem"/> que fica sempre no fim da lista, mesmo ao adicionar novos itens
		/// </summary>
		private ToolStripMenuItem UltimoItem { get; set; } = null;

		public ToolStripItemCollection Items { get => NotifyIcon.ContextMenuStrip.Items; }

		public CustomNotifyIcon()
		{
			NotifyIcon = new();
			NotifyIcon.ContextMenuStrip = new();
		}

		public CustomNotifyIcon(IContainer container)
		{
			NotifyIcon = new(container);
			NotifyIcon.ContextMenuStrip = new();
		}

		public ToolStripMenuItem AdicionarItem(string texto, EventHandler eventHandler = null, bool forcarUltimo = false, bool checkbox = false) //, string nome = null, Image imagem = null
		{
			if (Items.ContainsKey(texto))
				throw new ArgumentException($"Item com a chave {texto} já existente.");

			ToolStripMenuItem item = eventHandler == null ? new ToolStripMenuItem(texto) : new(texto, null, eventHandler);
			item.Name = texto;
			item.CheckOnClick = checkbox;

			if (forcarUltimo)
			{
				Items.Add(item);
				UltimoItem = item;
			}
			else if (UltimoItem != null)
				Items.Insert(Items.Count - 2, item);
			else
				Items.Add(item);

			return item;
		}

		public void AdicionarSubItem(string nomePai, string texto, EventHandler eventHandler)
		{
			AdicionarSubItem(Items[nomePai] as ToolStripMenuItem, texto, eventHandler, true);
		}

		public static ToolStripMenuItem AdicionarSubItem(ToolStripMenuItem itemPai, string texto, EventHandler eventHandler, bool visible, bool checkbox = false, object tag = null)
		{
			ToolStripMenuItem item = new(texto, null, eventHandler);
			item.CheckOnClick = checkbox;
			item.Name = texto;
			item.Tag = tag;
			item.Visible = visible;
			itemPai.DropDownItems.Add(item);
			return item;
		}

		public static void AdicionarSubItems_FromEnum<T>(ToolStripMenuItem itemPai) where T : struct, Enum
		{
			T[] valoresBase = Enum.GetValues<T>();
			(T Valor, string Descricao)[] valores = new (T Valor, string Descricao)[valoresBase.Length];
			for (int i = 0; i < valoresBase.Length; i++)
			{
				T valor = valoresBase[i];
				valores[i] = (valor, valor.GetDescricaoEnum());
			}
			Array.Sort(valores, new Comparison<(T Valor, string Descricao)>(
				(valor1, valor2) => valor1.Descricao.CompareTo(valor2.Descricao)));

			valores.ForEach((d, _) =>
				itemPai.DropDownItems.Add(new ToolStripMenuItem(d.Descricao, null) { CheckOnClick = true, Name = d.Descricao, Tag = d.Valor }));
		}

		public static ToolStripItem GetItem_Recursivo(ToolStripItemCollection items, string nome)
		{
			if (items.ContainsKey(nome))
				return items[nome];

			for (int i = 0; i < items.Count; i++)
			{
				if (items[i] is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count != 0)
				{
					ToolStripItem itemEncontrado = GetItem_Recursivo(menuItem.DropDownItems, nome);
					if (itemEncontrado != null)
						return itemEncontrado;
				}
			}

			return null;
		}

		public static ToolStripItem GetItem_Recursivo(ToolStripItemCollection items, Func<ToolStripItem, bool> condicao)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ToolStripItem item = items[i];
				if (condicao(item))
					return item;

				if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count != 0)
				{
					ToolStripItem itemEncontrado = GetItem_Recursivo(menuItem.DropDownItems, condicao);
					if (itemEncontrado != null)
						return itemEncontrado;
				}
			}

			return null;
		}

		public static void ToggleEventosItems(ToolStripItemCollection items, EventHandler eventHandler, bool atribuir, Action<ToolStripMenuItem> acaoExtra = null)
		{
			Action<ToolStripMenuItem> acao;
			if (acaoExtra == null)
			{
				acao = atribuir ? item => item.CheckedChanged += eventHandler : item => item.CheckedChanged -= eventHandler;
			}
			else
			{
				acao = atribuir ? item => { item.CheckedChanged += eventHandler; acaoExtra(item); }
				: item => { item.CheckedChanged -= eventHandler; acaoExtra(item); };
			}

			foreach (ToolStripMenuItem algoritmoItem in items)
			{
				acao(algoritmoItem);
			}
		}

		public static void UniqueCheckedChanged(object sender, ToolStripItemCollection items, EventHandler eventHandler, string entidade, Action<ToolStripMenuItem> onChecked = null)
		{
			Action reativarEventos = null;
			try
			{
				if (sender is ToolStripMenuItem itemAlterado)
				{
					//Ao ativar um item irá desativar todos os outros
					if (itemAlterado.Checked)
					{
						reativarEventos = () => CustomNotifyIcon.ToggleEventosItems(items, eventHandler, true);
						CustomNotifyIcon.ToggleEventosItems(items, eventHandler, false, item => item.Checked = item.Name == itemAlterado.Name);

						onChecked?.Invoke(itemAlterado);
					}
					else //Impede-se de desativar o único item ativo
					{
						itemAlterado.CheckedChanged -= eventHandler;
						reativarEventos = () => itemAlterado.CheckedChanged += eventHandler;

						itemAlterado.Checked = true;
					}
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro($"Erro ao tratar alteração de {entidade}", ex: ex);
			}
			finally
			{
				reativarEventos?.Invoke();
			}
		}
	}
}
