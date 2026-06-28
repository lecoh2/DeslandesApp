using DeslandesApp.Domain.Commons;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
public class Processo : BaseEntity
{
    #region Dados Básicos

    public string? Pasta { get; set; }

    public string? Titulo { get; set; }

    public string? NumeroProcesso { get; set; }

    public string? Objeto { get; set; }

    public string? Observacao { get; set; }

    public string? LinkTribunal { get; set; }

    public decimal? ValorCausa { get; set; }

    public decimal? ValorCondenacao { get; set; }

    public DateOnly? Distribuido { get; set; }

    public SituacaoProcesso Situacao { get; set; }
        = SituacaoProcesso.Ativo;

    #endregion

    #region Relacionamentos Jurídicos

    public Guid VaraId { get; set; }
    public Vara Vara { get; set; } = null!;

    public Guid? ClasseProcessualId { get; set; }
    public ClasseProcessual? ClasseProcessual { get; set; }

    public Guid? AcaoId { get; set; }
    public Acao? Acao { get; set; }

    public Guid? TribunalId { get; set; }
    public Tribunal? Tribunal { get; set; }

    public Guid? InstanciaId { get; set; }
    public Instancia? Instancia { get; set; }

    public Guid? AcessoId { get; set; }
    public Acesso? Acesso { get; set; }

    #endregion

    #region Usuários

    public Guid? UsuarioResponsavelId { get; set; }
    public Usuario? UsuarioResponsavel { get; set; }

    public Guid? UsuarioCadastroId { get; set; }
    public Usuario? UsuarioCadastro { get; set; }

    public Guid? UsuarioAtualizacaoId { get; set; }
    public Usuario? UsuarioAtualizacao { get; set; }

    #endregion



    #region Soft Delete

    public bool Excluido { get; set; }

    public DateTime? DataExclusao { get; set; }

    public Guid? UsuarioExclusaoId { get; set; }

    public Usuario? UsuarioExclusao { get; set; }

    #endregion

    #region Monitoramento Processual

    public bool MonitorarAndamentos { get; set; }

    public DateTime? UltimaConsultaTribunal { get; set; }

    public DateTime? UltimoAndamentoCapturado { get; set; }

    public string? ErroUltimaConsulta { get; set; }

    #endregion

    #region Relacionamentos N:N

    public ICollection<GrupoClienteProcesso> GrupoClienteProcesso { get; set; }
        = new List<GrupoClienteProcesso>();

    public ICollection<GrupoEnvolvidos> GrupoEnvolvidos { get; set; }
        = new List<GrupoEnvolvidos>();

    public ICollection<GrupoEnvolvidosProcesso> GrupoEnvolvidosProcesso { get; set; }
        = new List<GrupoEnvolvidosProcesso>();

    public ICollection<GrupoEtiquetasProcessos> GrupoEtiquetasProcessos { get; set; }
        = new List<GrupoEtiquetasProcessos>();

    public ICollection<ContratoProcesso> ContratoProcessos { get; set; }
        = new List<ContratoProcesso>();

    #endregion

    #region Módulo Jurídico

    public ICollection<AndamentoProcesso> Andamentos { get; set; }
        = new List<AndamentoProcesso>();

    public ICollection<PrazoProcessual> Prazos { get; set; }
        = new List<PrazoProcessual>();

    public ICollection<Audiencia> Audiencias { get; set; }
        = new List<Audiencia>();


    public ICollection<WebJurPublicacao> PublicacoesWebJur { get; set; }
    = new List<WebJurPublicacao>();


    #endregion

}    // public List<ProcessoEtiqueta> ProcessoEtiquetas { get; set; } = new();
     //public ICollection<GrupoEnvolvidos> GrupoEnvolvidos { get; set; }
     //public ICollection<GrupoClienteProcesso> GrupoClienteProcesso { get; set; }
     //public ICollection<GrupoEtiquetasProcessos> GrupoEtiquetasProcessos { get; set; }
     //public ICollection<GrupoEnvolvidosProcesso> GrupoEnvolvidosProcesso { get; set; }
