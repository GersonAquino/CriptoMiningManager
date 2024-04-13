using Autofac;
using CryptoMiningManager.Views;
using DeepCopy;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using Modelos.Classes;
using Modelos.Exceptions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CryptoMiningManager.Helpers
{
    public class ConfiguracoesEntidadesHelper
    {
        private ILifetimeScope Scope { get; }

        public ConfiguracoesEntidadesHelper(ILifetimeScope scope)
        {
            Scope = scope;
        }

        /// <summary>
        /// Abre um separador com o editor adequado no modo de criação (nova entidade)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="caption"></param>
        /// <param name="entidadeAEditar"></param>
        /// <param name="activeControl">Control para apresentar a animação de loading</param>
        public void AbrirEditorUC<T>(string caption, Control activeControl = null, T entidadeAEditar = null) where T : class
        {
            IOverlaySplashScreenHandle splashScreenHandler = activeControl == null ? null : SplashScreenManager.ShowOverlayForm(activeControl);
            try
            {
                MainForm mainForm = Scope.Resolve<MainForm>();
                BaseDocument doc = mainForm.TabbedView.Documents.FirstOrDefault(d => d.Caption == caption);
                if (doc != null)
                {
                    splashScreenHandler.QueueFocus(doc.Control); //Previne que o foco volte instantâneamente para o UC "pai"
                    mainForm.TabbedView.ActivateDocument(doc.Control);
                }
                else
                {
                    Type tipoEntidade = typeof(T);

                    if (entidadeAEditar == null)
                        entidadeAEditar = Scope.Resolve<T>();

                    XtraUserControl editor = Scope.ResolveKeyed<XtraUserControl>(tipoEntidade.Name, new TypedParameter(tipoEntidade, entidadeAEditar));
                    splashScreenHandler.QueueFocus(editor); //Previne que o foco volte instantâneamente para o UC "pai"
                    mainForm.TabbedView.AddDocument(editor, caption);
                }
            }
            catch (Exception ex)
            {
                //SerilogHelper.EscreveLogException(SerilogLevel.Error, ex, "Erro ao abrir menu {menuCaption}", caption);
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
        public void DuploCliqueEntidade<T>(EventArgs e, GridView gridView, Control activeControl = null) where T : Configuracao
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
                XtraMessageBox.Show($"Erro ao tratar duplo clique!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edita as entidades selecionadas ou, caso não haja nenhuma, edita a entidade focada na grelha
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridView"></param>
        /// <param name="activeControl"></param>
        public void EditarEntidade<T>(GridView gridView, Control activeControl = null) where T : Configuracao
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
                XtraMessageBox.Show(ce.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Erro ao abrir editor da(s) linha(s) selecionada(s).{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
