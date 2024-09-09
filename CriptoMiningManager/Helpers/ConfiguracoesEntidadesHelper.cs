using Autofac;
using CriptoMiningManager.Views;
using DeepCopy;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
using System;
using System.Windows.Forms;
using Utils;

namespace CriptoMiningManager.Helpers
{
	public class ConfiguracoesEntidadesHelper
	{
		private ILifetimeScope Scope { get; }

		public ConfiguracoesEntidadesHelper(ILifetimeScope scope)
		{
			Scope = scope;
		}

		/// <summary>
		/// Abre um separador com o editor adequado
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="caption"></param>
		/// <param name="entidadeAEditar"></param>
		/// <param name="activeControl">Control para apresentar a animação de loading</param>
		internal void AbrirEditorUC<T>(string caption, Control activeControl = null, T entidadeAEditar = null) where T : class
		{
			IOverlaySplashScreenHandle splashScreenHandler = activeControl == null ? null : SplashScreenManager.ShowOverlayForm(activeControl);
			try
			{
				MainForm mainForm = Scope.Resolve<MainForm>();
				BaseDocument doc = mainForm.TabbedView.Documents.FindFirst(d => d.Caption == caption);
				if (doc != null)
					mainForm.TabbedView.ActivateDocument(doc.Control);
				else
				{
					Type tipoEntidade = typeof(T);
					XtraUserControl editor = Scope.ResolveKeyed<XtraUserControl>(tipoEntidade.Name, new TypedParameter(tipoEntidade, entidadeAEditar ?? Scope.Resolve<T>()));
					doc = mainForm.TabbedView.AddDocument(editor, caption);
					mainForm.TabbedView.Controller.Activate(doc);
				}

				splashScreenHandler.QueueFocus(doc.Control); //Previne que o foco volte instantâneamente para o UC "pai"
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao abrir menu {menuCaption}", caption);
				MessageBoxesHelper.MostraErro("Erro ao abrir editor!", $"Não foi possível abrir o menu {caption}", ex);
			}
			finally
			{
				splashScreenHandler?.Dispose();
			}
		}

		/// <summary>
		/// Edita a entidade focada na grelha
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		/// <param name="gridView"></param>
		/// <param name="activeControl"></param>
		internal void DuploCliqueEntidade<T>(EventArgs e, GridView gridView, Control activeControl = null) where T : Configuracao
		{
			try
			{
				if (e is DXMouseEventArgs ea)
				{
					GridHitInfo info = gridView.CalcHitInfo(ea.Location);
					if ((info.InRow || info.InRowCell) && gridView.FocusedRowObject is T entidade)
						EditarEntidade(entidade, activeControl);
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao tratar duplo clique.");
				MessageBoxesHelper.MostraErro("Erro ao tratar duplo clique!", ex: ex);
			}
		}

		/// <summary>
		/// Edita as entidades selecionadas ou, caso não haja nenhuma, edita a entidade focada na grelha
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="gridView"></param>
		/// <param name="activeControl"></param>
		internal void EditarEntidade<T>(GridView gridView, Control activeControl = null) where T : Configuracao
		{
			try
			{
				if (gridView.SelectedRowsCount == 0)
				{
					if (gridView.FocusedRowObject is T entidade)
						EditarEntidade(entidade, activeControl);
					else
						throw new CustomException($"Por favor selecione um(a) {typeof(T).GetDescricaoClasse()} para editar.");
				}
				else
				{
					for (int i = 0; i < gridView.SelectedRowsCount; i++)
					{
						if (gridView.IsDataRow(i) && gridView.GetRow(i) is T entidade)
							EditarEntidade(entidade, activeControl);
					}
				}
			}
			catch (CustomException ce)
			{
				MessageBoxesHelper.MostraAviso(ce.Message);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao abrir editor da(s) linha(s) selecionada(s).");
				MessageBoxesHelper.MostraErro("Erro ao abrir editor da(s) linha(s) selecionada(s).", ex: ex);
			}
		}

		/// <summary>
		/// Abre um separador com o editor adequado no modo edição com uma cópia da entidade recebida
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entidadeAEditar"></param>
		/// <param name="activeControl">Control para apresentar a animação de loading</param>
		private void EditarEntidade<T>(T entidadeAEditar, Control activeControl = null) where T : Configuracao
		{
			AbrirEditorUC($"Editar {typeof(T).GetDescricaoClasse()} {entidadeAEditar?.Id}", activeControl, DeepCopier.Copy(entidadeAEditar));
		}
	}
}
