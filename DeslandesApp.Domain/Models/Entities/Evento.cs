using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Enum;

namespace DeslandesApp.Domain.Models.Entities
{
    public class Evento : BaseEntity
    {
        public string Titulo { get; set; } = string.Empty;

        public DateOnly DataInicial { get; set; }
        public TimeOnly HoraInicial { get; set; }

        public DateOnly? DataFinal { get; set; }
        public TimeOnly? HoraFinal { get; set; }

        public bool DiaInteiro { get; set; }

        public string? Endereco { get; set; }

        public ModalidadeEvento Modalidade { get; set; }

        public string? Observacao { get; set; }

        // 👥 RESPONSÁVEIS
        public List<GrupoEventoResponsavel> GrupoEventoResponsaveis { get; set; } = new();

        // 🏷️ ETIQUETAS
        public List<GrupoEventoEtiquetas> GrupoEventoEtiquetas { get; set; } = new();

        // 🔁 RECORRÊNCIA
        public TipoRecorrencia TipoRecorrencia { get; set; } = TipoRecorrencia.Nenhuma;

        public int IntervaloRecorrencia { get; set; } = 1;

        public List<DayOfWeek> DiasSemana { get; set; } = new();

        public DateOnly? DataFimRecorrencia { get; set; }

        public int? QuantidadeOcorrencias { get; set; }

        // 📌 STATUS
        public StatusGeralKanban StatusGeralKanban { get; set; }

        // 👤 USUÁRIO
        public Guid? UsuarioCriacaoId { get; set; }
        public Usuario? UsuarioCriacao { get; set; }

        // 📅 DATAS
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        // 🔗 VÍNCULOS
        public TipoVinculo? TipoVinculoId { get; set; }

        public Guid? ProcessoId { get; set; }
        public Processo? Processo { get; set; }

        public Guid? CasoId { get; set; }
        public Caso? Caso { get; set; }

        public Guid? AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }

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
                    "O evento não pode ter mais de um vínculo."
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