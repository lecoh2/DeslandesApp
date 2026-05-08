using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Tarefa : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;

        public DateTime? DataTarefa { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime? DataAtualizacao { get; set; }

        // =========================
        // 🔗 VÍNCULOS
        // =========================

        public TipoVinculo? TipoVinculoId { get; set; }

        public Guid? ProcessoId { get; set; }
        public Processo? Processo { get; set; }

        public Guid? CasoId { get; set; }
        public Caso? Caso { get; set; }

        public Guid? AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }

        // =========================
        // 👤 RESPONSÁVEL
        // =========================

        public Guid? UsuarioCriacaoId { get; set; }

        public Usuario? UsuarioCriacao { get; set; }

        public Usuario? Responsavel { get; set; }

        // =========================
        // 📌 STATUS
        // =========================

        public PrioridadeTarefa Prioridade { get; set; }

        public StatusGeralKanban StatusGeralKanban { get; set; }

        // =========================
        // 🏷️ RELACIONAMENTOS
        // =========================

        public List<GrupoTarefasEtiquetas> GrupoTarefasEtiquetas { get; set; } = new();

        public List<ListaTarefa> ListasTarefa { get; set; } = new();

        public List<GrupoTarefaResponsaveis> GrupoTarefaResponsaveis { get; set; } = new();

        // =========================
        // 🔗 DEFINIR VÍNCULO
        // =========================

        public void DefinirVinculo(
            Guid? processoId,
            Guid? casoId,
            Guid? atendimentoId)
        {
            // 🔥 limpa tudo antes

            ProcessoId = null;
            Processo = null;

            CasoId = null;
            Caso = null;

            AtendimentoId = null;
            Atendimento = null;

            // 🔗 PROCESSO

            if (processoId.HasValue)
            {
                ProcessoId = processoId;

                TipoVinculoId = TipoVinculo.Processo;

                return;
            }

            // 🔗 CASO

            if (casoId.HasValue)
            {
                CasoId = casoId;

                TipoVinculoId = TipoVinculo.Caso;

                return;
            }

            // 🔗 ATENDIMENTO

            if (atendimentoId.HasValue)
            {
                AtendimentoId = atendimentoId;

                TipoVinculoId = TipoVinculo.Atendimento;

                return;
            }

            // 🔥 sem vínculo

            TipoVinculoId = null;
        }

        // =========================
        // ✅ VALIDAR VÍNCULO
        // =========================

        public void ValidarVinculo()
        {
            int count = 0;

            if (ProcessoId.HasValue) count++;

            if (CasoId.HasValue) count++;

            if (AtendimentoId.HasValue) count++;

            // 🔥 impede múltiplos vínculos

            if (count > 1)
            {
                throw new Exception(
                    "A tarefa não pode ter mais de um vínculo."
                );
            }

            // 🔥 consistência Processo

            if (
                TipoVinculoId == TipoVinculo.Processo &&
                !ProcessoId.HasValue
            )
            {
                throw new Exception(
                    "TipoVinculo Processo inválido."
                );
            }

            // 🔥 consistência Caso

            if (
                TipoVinculoId == TipoVinculo.Caso &&
                !CasoId.HasValue
            )
            {
                throw new Exception(
                    "TipoVinculo Caso inválido."
                );
            }

            // 🔥 consistência Atendimento

            if (
                TipoVinculoId == TipoVinculo.Atendimento &&
                !AtendimentoId.HasValue
            )
            {
                throw new Exception(
                    "TipoVinculo Atendimento inválido."
                );
            }
        }
    }
}