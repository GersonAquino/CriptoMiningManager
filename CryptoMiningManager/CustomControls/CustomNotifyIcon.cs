using DevExpress.XtraSpreadsheet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.CustomControls
{
	public class CustomNotifyIcon
	{
		public NotifyIcon NotifyIcon { get; }

		/// <summary>
		/// <see cref="ToolStripMenuItem"/> que fica sempre no fim da lista, mesmo ao adicionar novos itens
		/// </summary>
		private ToolStripMenuItem UltimoItem { get; set; } = null;

		private ToolStripItemCollection Items { get => NotifyIcon.ContextMenuStrip.Items; }

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

		public ToolStripMenuItem AdicionarItem(string texto, EventHandler eventHandler = null, bool forcarUltimo = false) //, string nome = null, Image imagem = null
		{
			if (Items.ContainsKey(texto))
				throw new ArgumentException($"Item com a chave {texto} já existente.");

			ToolStripMenuItem item = eventHandler == null ? new ToolStripMenuItem(texto) : new(texto, null, eventHandler);

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
			AdicionarSubItem(Items[nomePai] as ToolStripMenuItem, texto, eventHandler);
		}

		public static ToolStripMenuItem AdicionarSubItem(ToolStripMenuItem itemPai, string texto, EventHandler eventHandler, bool visible = true)
		{
			ToolStripMenuItem item = new(texto, null, eventHandler);
			item.Visible = visible;
			itemPai.DropDownItems.Add(item);
			return item;
		}
	}
}
