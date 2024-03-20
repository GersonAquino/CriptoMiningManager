using Autofac;
using CryptoMiningManager.Views;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using GestorDados.Enums;
using GestorDados.Helpers;
using Modelos.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CryptoMiningManager.Helpers
{
    internal class EntidadesHelper
    {
        private ILifetimeScope Scope { get; }

        internal EntidadesHelper(ILifetimeScope scope)
        {
            Scope = scope;
        }

        /// <summary>
        /// Abre um novo tab com o <typeparamref name="EditorMapeamento"/> adequado no modo de criação (nova entidade)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="EditorMapeamento"></typeparam>
        /// <param name="caption"></param>
        /// <param name="entidadeAEditar"></param>
        /// <param name="activeControl"></param>
        internal void CallEditorMapeamentoUC<T, EditorMapeamento>(string caption, T entidadeAEditar, Control activeControl) where EditorMapeamento : UserControl
        {
            if (activeControl == null)
                return;

            using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(activeControl))
            {
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
                        Control control = Scope.Resolve<EditorMapeamento>(new TypedParameter(typeof(T), entidadeAEditar));
                        splashScreenHandler.QueueFocus(control); //Previne que o foco volte instantâneamente para o UC "pai"
                        mainForm.TabbedView.AddDocument(control, caption);
                    }
                }
                catch (Exception ex)
                {
                    SerilogHelper.EscreveLogException(SerilogLevel.Error, ex, "Erro ao abrir menu {menuCaption}", caption);
                    XtraMessageBox.Show(ex.GetBaseException().Message, $"Não foi possível abrir o menu {caption}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Abre um novo tab com o <typeparamref name="EditorMapeamento"/> adequado no modo edição com os detalhes da entidade recebida
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="EditorMapeamento"></typeparam>
        /// <param name="entidadeAEditar"></param>
        /// <param name="editorCaption"></param>
        /// <param name="activeControl"></param>
        internal void EditarMapeamento<T, EditorMapeamento>(T entidadeAEditar, string editorCaption, Control activeControl)
            where T : Configuracao
            where EditorMapeamento : UserControl
        {
            CallEditorMapeamentoUC<T, EditorMapeamento>($"Editar mapeamento {editorCaption} {entidadeAEditar?.Id}", entidadeAEditar, activeControl);
        }
    }
}
