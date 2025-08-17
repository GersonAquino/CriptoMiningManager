using Autofac;
using CryptoMiningManager.Views;
using DataManager.Helpers;
using DeepCopy;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using Models.Classes;
using Models.Enums;
using Models.Exceptions;
using System;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace CryptoMiningManager.Helpers;

public class EntityConfigurationHelper
{
	private ILifetimeScope Scope { get; }

	public EntityConfigurationHelper(ILifetimeScope scope)
	{
		Scope = scope;
	}

	/// <summary>
	/// Abre um separador com o editor adequado no modo de criação (nova entidade)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="caption"></param>
	/// <param name="entityToEdit"></param>
	/// <param name="activeControl">Control para apresentar a animação de loading</param>
	public void OpenEditorTab<T>(string caption, Control activeControl = null, T entityToEdit = null) where T : class
	{
		IOverlaySplashScreenHandle splashScreenHandler = activeControl == null ? null : SplashScreenManager.ShowOverlayForm(activeControl);
		try
		{
			MainForm mainForm = Scope.Resolve<MainForm>();
			BaseDocument doc = mainForm.TabbedView.Documents.FirstOrDefault(d => d.Caption == caption);
			if (doc != null)
				mainForm.TabbedView.ActivateDocument(doc.Control);
			else
			{
				Type entityType = typeof(T);
				XtraUserControl editor = Scope.ResolveKeyed<XtraUserControl>(entityType.Name, new TypedParameter(entityType, entityToEdit ?? Scope.Resolve<T>()));
				doc = mainForm.TabbedView.AddDocument(editor, caption);
			}

			splashScreenHandler.QueueFocus(doc.Control); //Previne que o foco volte instantâneamente para o UC "pai"
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao abrir menu {menuCaption}", caption);
			XtraMessageBox.Show(ex.GetBaseException().Message, $"Não foi possível abrir o menu {caption}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
	public void EntityDoubleClick<T>(EventArgs e, GridView gridView, Control activeControl = null) where T : Configuration
	{
		try
		{
			if (e is DXMouseEventArgs ea)
			{
				GridHitInfo info = gridView.CalcHitInfo(ea.Location);
				if ((info.InRow || info.InRowCell) && gridView.FocusedRowObject is T entidade)
					EditEntity(entidade, activeControl);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao tratar duplo clique.");
			XtraMessageBox.Show($"Erro ao tratar duplo clique!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	/// <summary>
	/// Edita as entidades selecionadas ou, caso não haja nenhuma, edita a entidade focada na grelha
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="gridView"></param>
	/// <param name="activeControl"></param>
	public void EditEntity<T>(GridView gridView, Control activeControl = null) where T : Configuration
	{
		try
		{
			if (gridView.SelectedRowsCount == 0)
			{
				if (gridView.FocusedRowObject is T entity)
					EditEntity(entity, activeControl);
				else
					throw new CustomException($"Por favor selecione um(a) {typeof(T).GetClassDescription()} para editar.");
			}
			else
			{
				for (int i = 0; i < gridView.SelectedRowsCount; i++)
				{
					if (gridView.IsDataRow(i) && gridView.GetRow(i) is T entity)
						EditEntity(entity, activeControl);
				}
			}
		}
		catch (CustomException ce)
		{
			XtraMessageBox.Show(ce.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao abrir editor da(s) linha(s) selecionada(s).");
			XtraMessageBox.Show($"Erro ao abrir editor da(s) linha(s) selecionada(s).{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	/// <summary>
	/// Abre um separador com o editor adequado no modo edição com uma cópia da entidade recebida
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entityToEdit"></param>
	/// <param name="activeControl">Control para apresentar a animação de loading</param>
	private void EditEntity<T>(T entityToEdit, Control activeControl = null) where T : Configuration
	{
		OpenEditorTab($"Editar {typeof(T).GetClassDescription()} {entityToEdit?.Id}", activeControl, DeepCopier.Copy(entityToEdit));
	}
}
