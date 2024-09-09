using Autofac;
using CriptoMiningManager.Constants;
using CriptoMiningManager.CustomControls;
using GestorDados.Helpers;
using Modelos.Enums;
using Modelos.EventArgs;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CriptoMiningManager.Helpers
{
	public class SemUIHelper : ApplicationContext
	{
		private readonly ILifetimeScope Scope;

		private CustomNotifyIcon TaskBarIcon { get; }
		private MineracaoHelper MineracaoHelper { get; }
		private SynchronizationContext SyncContext { get; }

		public SemUIHelper(CustomNotifyIcon notifyIcon, MineracaoHelper mineracaoHelper, ILifetimeScope scope)
		{
			MineracaoHelper = mineracaoHelper;
			Scope = scope;
			SyncContext = SynchronizationContext.Current;
			TaskBarIcon = notifyIcon;

			MineracaoHelper.AlteracaoEstadoMineracao += MineracaoHelper_AlteracaoEstadoMineracao;
			//MineracaoHelper.AlteracaoMinerador += MineracaoHelper_AlteracaoMinerador;
			//MineracaoHelper.AlteracaoMoedaMaisRentavel += MineracaoHelper_AlteracaoMoedaMaisRentavel;
			//MineracaoHelper.ErroMinerador += MineracaoHelper_ErroMinerador;
			//MineracaoHelper.OutputMinerador += MineracaoHelper_OutputMinerador;
			//MineracaoHelper.RegistarLogsMineracao += MineracaoHelper_RegistarLogsMineracao;
			//MineracaoHelper.VerificaoRentabilidade += MineracaoHelper_VerificaoRentabilidade;

			Global.AppVisivel = false;

			using (ILifetimeScope scopeAux = Scope.BeginLifetimeScope())
			{
				scopeAux.Resolve<Inicializador>().Inicializar((_, _) => FecharAplicacao());

				TaskBarIcon.NotifyIcon.Visible = true;
			}
		}

		#region Eventos MineracaoHelper
		private void MineracaoHelper_AlteracaoEstadoMineracao(object sender, AlteracaoEstadoMineracaoEventArgs e)
		{
			SyncContext.Post(_ => Inicializador.TratarAlteracaoEstadoMineracao(e, TaskBarIcon), null);
		}

		private void TratarAlteracaoEstadoMineracao(AlteracaoEstadoMineracaoEventArgs e)
		{
			if (CustomNotifyIcon.GetItem_Recursivo(TaskBarIcon.Items, Taskbar.Mineracao) is not ToolStripMenuItem mineracaoItem)
				return;

			bool notAtiva = !e.Ativa;
			mineracaoItem.DropDownItems[Taskbar_Mineracao.Iniciar].Visible = notAtiva;
			mineracaoItem.DropDownItems[Taskbar_Mineracao.Parar].Visible = e.Ativa;
			Global.AlgoritmosTB.Enabled = notAtiva;
			Global.MineradoresRB.Enabled = notAtiva;
			TaskBarIcon.NotifyIcon.Text = e.Ativa ? "Ativo" : "Inativo";
		}

		private void MineracaoHelper_AlteracaoMinerador(object sender, AlteracaoMineradorEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_AlteracaoMoedaMaisRentavel(object sender, AlteracaoMoedaMaisRentavelEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_ErroMinerador(object sender, DataReceivedEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_OutputMinerador(object sender, DataReceivedEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_RegistarLogsMineracao(object sender, EventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_VerificaoRentabilidade(object sender, EventArgs e)
		{
			//TODO: Por implementar
		}
		#endregion

		//MÉTODOS AUXILIARES
		private void FecharAplicacao()
		{
			try
			{
				if (MineracaoHelper.ProcessoAtivo != null)
					MineracaoHelper.Parar();

				Application.Exit();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro("Erro ao fechar aplicação!", ex: ex);
			}
		}
	}
}
