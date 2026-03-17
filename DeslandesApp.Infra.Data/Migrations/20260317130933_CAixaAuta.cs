using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CAixaAuta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPONIVEL_NIVEL_IdNivel",
                table: "GRUPONIVEL");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPONIVEL_USUARIOS_IdUsuario",
                table: "GRUPONIVEL");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PESSOA_IdPessoa",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PROCESSO_IdProcesso",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOSETORES_SETORES_IdSetor",
                table: "GRUPOSETORES");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOSETORES_USUARIOS_IdUsuario",
                table: "GRUPOSETORES");

            migrationBuilder.DropForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_IdUsuario",
                table: "LOGINHISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaHistorico_Pessoa",
                table: "PESSOAHISTORICO");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaHistorico_Usuario",
                table: "PESSOAHISTORICO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAPROCESSO_PESSOA_OutrosEnvolvidosId",
                table: "PESSOAPROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAPROCESSO_PROCESSO_ProcessoId",
                table: "PESSOAPROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSO_ACAO_IdAcao",
                table: "PROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSO_FORO_IdForo",
                table: "PROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_QUALIFICACAO_PROCESSO_Id",
                table: "QUALIFICACAO");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "USUARIOS",
                newName: "NOMEUSUARIO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USUARIOS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SEXO",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SETORES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "QUALIFICACAO",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Vara",
                table: "PROCESSO",
                newName: "VARA");

            migrationBuilder.RenameColumn(
                name: "ValorCondenacao",
                table: "PROCESSO",
                newName: "VALORCONDENACAO");

            migrationBuilder.RenameColumn(
                name: "ValorCausa",
                table: "PROCESSO",
                newName: "VALORCAUSA");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "PROCESSO",
                newName: "TITULO");

            migrationBuilder.RenameColumn(
                name: "Responsavael",
                table: "PROCESSO",
                newName: "RESPONSAVAEL");

            migrationBuilder.RenameColumn(
                name: "Pasta",
                table: "PROCESSO",
                newName: "PASTA");

            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "PROCESSO",
                newName: "OBSERVACAO");

            migrationBuilder.RenameColumn(
                name: "Objeto",
                table: "PROCESSO",
                newName: "OBJETO");

            migrationBuilder.RenameColumn(
                name: "NumeroProcesso",
                table: "PROCESSO",
                newName: "NUMEROPROCESSO");

            migrationBuilder.RenameColumn(
                name: "LinkTribunal",
                table: "PROCESSO",
                newName: "LINKTRIBUNAL");

            migrationBuilder.RenameColumn(
                name: "Juizo",
                table: "PROCESSO",
                newName: "JUIZO");

            migrationBuilder.RenameColumn(
                name: "Instancia",
                table: "PROCESSO",
                newName: "INSTANCIA");

            migrationBuilder.RenameColumn(
                name: "IdForo",
                table: "PROCESSO",
                newName: "IDFORO");

            migrationBuilder.RenameColumn(
                name: "IdAcao",
                table: "PROCESSO",
                newName: "IDACAO");

            migrationBuilder.RenameColumn(
                name: "Etiqueta",
                table: "PROCESSO",
                newName: "ETIQUETA");

            migrationBuilder.RenameColumn(
                name: "Distribuido",
                table: "PROCESSO",
                newName: "DISTRIBUIDO");

            migrationBuilder.RenameColumn(
                name: "Acesso",
                table: "PROCESSO",
                newName: "ACESSO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PROCESSO",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_PROCESSO_IdForo",
                table: "PROCESSO",
                newName: "IX_PROCESSO_IDFORO");

            migrationBuilder.RenameIndex(
                name: "IX_PROCESSO_IdAcao",
                table: "PROCESSO",
                newName: "IX_PROCESSO_IDACAO");

            migrationBuilder.RenameColumn(
                name: "ProcessoId",
                table: "PESSOAPROCESSO",
                newName: "PROCESSOID");

            migrationBuilder.RenameColumn(
                name: "OutrosEnvolvidosId",
                table: "PESSOAPROCESSO",
                newName: "OUTROSENVOLVIDOSID");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAPROCESSO_ProcessoId",
                table: "PESSOAPROCESSO",
                newName: "IX_PESSOAPROCESSO_PROCESSOID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PESSOAHISTORICO",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TituloEleitor",
                table: "PESSOA",
                newName: "TITULOELEITOR");

            migrationBuilder.RenameColumn(
                name: "TipoEmail",
                table: "PESSOA",
                newName: "TIPOEMAIL");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "PESSOA",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "Site",
                table: "PESSOA",
                newName: "SITE");

            migrationBuilder.RenameColumn(
                name: "SimplesNacional",
                table: "PESSOA",
                newName: "SIMPLESNACIONAL");

            migrationBuilder.RenameColumn(
                name: "PisPasep",
                table: "PESSOA",
                newName: "PISPASEP");

            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "PESSOA",
                newName: "PERFIL");

            migrationBuilder.RenameColumn(
                name: "Passaporte",
                table: "PESSOA",
                newName: "PASSAPORTE");

            migrationBuilder.RenameColumn(
                name: "InscricaoMunicipal",
                table: "PESSOA",
                newName: "INSCRICAOMUNICIPAL");

            migrationBuilder.RenameColumn(
                name: "InscricaoEstadual",
                table: "PESSOA",
                newName: "INSCRICAOESTADUAL");

            migrationBuilder.RenameColumn(
                name: "Etiqueta",
                table: "PESSOA",
                newName: "ETIQUETA");

            migrationBuilder.RenameColumn(
                name: "CertidaoReservista",
                table: "PESSOA",
                newName: "CERTIDAORESERVISTA");

            migrationBuilder.RenameColumn(
                name: "CarteiraTrabalho",
                table: "PESSOA",
                newName: "CARTEIRATRABALHO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PESSOA",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NIVEL",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Sucesso",
                table: "LOGINHISTORY",
                newName: "SUCESSO");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "LOGINHISTORY",
                newName: "IDUSUARIO");

            migrationBuilder.RenameColumn(
                name: "DataHoraAcesso",
                table: "LOGINHISTORY",
                newName: "DATAHORAACESSO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LOGINHISTORY",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_LOGINHISTORY_IdUsuario",
                table: "LOGINHISTORY",
                newName: "IX_LOGINHISTORY_IDUSUARIO");

            migrationBuilder.RenameColumn(
                name: "NomeEmpresa",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "NOMEEMPRESA");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IdSetor",
                table: "GRUPOSETORES",
                newName: "IDSETOR");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "GRUPOSETORES",
                newName: "IDUSUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOSETORES_IdSetor",
                table: "GRUPOSETORES",
                newName: "IX_GRUPOSETORES_IDSETOR");

            migrationBuilder.RenameColumn(
                name: "IdProcesso",
                table: "GRUPOPESSOACLIENTES",
                newName: "IDPROCESSO");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "GRUPOPESSOACLIENTES",
                newName: "IDPESSOA");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOPESSOACLIENTES_IdProcesso",
                table: "GRUPOPESSOACLIENTES",
                newName: "IX_GRUPOPESSOACLIENTES_IDPROCESSO");

            migrationBuilder.RenameColumn(
                name: "IdNivel",
                table: "GRUPONIVEL",
                newName: "IDNIVEL");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "GRUPONIVEL",
                newName: "IDUSUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPONIVEL_IdNivel",
                table: "GRUPONIVEL",
                newName: "IX_GRUPONIVEL_IDNIVEL");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "FOTOS",
                newName: "FILEURL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FOTOS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FORO",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ENDERECO",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ACAO",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPONIVEL_NIVEL_IDNIVEL",
                table: "GRUPONIVEL",
                column: "IDNIVEL",
                principalTable: "NIVEL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPONIVEL_USUARIOS_IDUSUARIO",
                table: "GRUPONIVEL",
                column: "IDUSUARIO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PESSOA_IDPESSOA",
                table: "GRUPOPESSOACLIENTES",
                column: "IDPESSOA",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PROCESSO_IDPROCESSO",
                table: "GRUPOPESSOACLIENTES",
                column: "IDPROCESSO",
                principalTable: "PROCESSO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOSETORES_SETORES_IDSETOR",
                table: "GRUPOSETORES",
                column: "IDSETOR",
                principalTable: "SETORES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOSETORES_USUARIOS_IDUSUARIO",
                table: "GRUPOSETORES",
                column: "IDUSUARIO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_IDUSUARIO",
                table: "LOGINHISTORY",
                column: "IDUSUARIO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAHISTORICO_PESSOA",
                table: "PESSOAHISTORICO",
                column: "PESSOA_ID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAHISTORICO_USUARIO",
                table: "PESSOAHISTORICO",
                column: "USUARIO_ID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAPROCESSO_PESSOA_OUTROSENVOLVIDOSID",
                table: "PESSOAPROCESSO",
                column: "OUTROSENVOLVIDOSID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAPROCESSO_PROCESSO_PROCESSOID",
                table: "PESSOAPROCESSO",
                column: "PROCESSOID",
                principalTable: "PROCESSO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSO_ACAO_IDACAO",
                table: "PROCESSO",
                column: "IDACAO",
                principalTable: "ACAO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSO_FORO_IDFORO",
                table: "PROCESSO",
                column: "IDFORO",
                principalTable: "FORO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QUALIFICACAO_PROCESSO_ID",
                table: "QUALIFICACAO",
                column: "ID",
                principalTable: "PROCESSO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPONIVEL_NIVEL_IDNIVEL",
                table: "GRUPONIVEL");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPONIVEL_USUARIOS_IDUSUARIO",
                table: "GRUPONIVEL");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PESSOA_IDPESSOA",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PROCESSO_IDPROCESSO",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOSETORES_SETORES_IDSETOR",
                table: "GRUPOSETORES");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOSETORES_USUARIOS_IDUSUARIO",
                table: "GRUPOSETORES");

            migrationBuilder.DropForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_IDUSUARIO",
                table: "LOGINHISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAHISTORICO_PESSOA",
                table: "PESSOAHISTORICO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAHISTORICO_USUARIO",
                table: "PESSOAHISTORICO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAPROCESSO_PESSOA_OUTROSENVOLVIDOSID",
                table: "PESSOAPROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAPROCESSO_PROCESSO_PROCESSOID",
                table: "PESSOAPROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSO_ACAO_IDACAO",
                table: "PROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSO_FORO_IDFORO",
                table: "PROCESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_QUALIFICACAO_PROCESSO_ID",
                table: "QUALIFICACAO");

            migrationBuilder.RenameColumn(
                name: "NOMEUSUARIO",
                table: "USUARIOS",
                newName: "NomeUsuario");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "USUARIOS",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SEXO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SETORES",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "QUALIFICACAO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VARA",
                table: "PROCESSO",
                newName: "Vara");

            migrationBuilder.RenameColumn(
                name: "VALORCONDENACAO",
                table: "PROCESSO",
                newName: "ValorCondenacao");

            migrationBuilder.RenameColumn(
                name: "VALORCAUSA",
                table: "PROCESSO",
                newName: "ValorCausa");

            migrationBuilder.RenameColumn(
                name: "TITULO",
                table: "PROCESSO",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "RESPONSAVAEL",
                table: "PROCESSO",
                newName: "Responsavael");

            migrationBuilder.RenameColumn(
                name: "PASTA",
                table: "PROCESSO",
                newName: "Pasta");

            migrationBuilder.RenameColumn(
                name: "OBSERVACAO",
                table: "PROCESSO",
                newName: "Observacao");

            migrationBuilder.RenameColumn(
                name: "OBJETO",
                table: "PROCESSO",
                newName: "Objeto");

            migrationBuilder.RenameColumn(
                name: "NUMEROPROCESSO",
                table: "PROCESSO",
                newName: "NumeroProcesso");

            migrationBuilder.RenameColumn(
                name: "LINKTRIBUNAL",
                table: "PROCESSO",
                newName: "LinkTribunal");

            migrationBuilder.RenameColumn(
                name: "JUIZO",
                table: "PROCESSO",
                newName: "Juizo");

            migrationBuilder.RenameColumn(
                name: "INSTANCIA",
                table: "PROCESSO",
                newName: "Instancia");

            migrationBuilder.RenameColumn(
                name: "IDFORO",
                table: "PROCESSO",
                newName: "IdForo");

            migrationBuilder.RenameColumn(
                name: "IDACAO",
                table: "PROCESSO",
                newName: "IdAcao");

            migrationBuilder.RenameColumn(
                name: "ETIQUETA",
                table: "PROCESSO",
                newName: "Etiqueta");

            migrationBuilder.RenameColumn(
                name: "DISTRIBUIDO",
                table: "PROCESSO",
                newName: "Distribuido");

            migrationBuilder.RenameColumn(
                name: "ACESSO",
                table: "PROCESSO",
                newName: "Acesso");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PROCESSO",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PROCESSO_IDFORO",
                table: "PROCESSO",
                newName: "IX_PROCESSO_IdForo");

            migrationBuilder.RenameIndex(
                name: "IX_PROCESSO_IDACAO",
                table: "PROCESSO",
                newName: "IX_PROCESSO_IdAcao");

            migrationBuilder.RenameColumn(
                name: "PROCESSOID",
                table: "PESSOAPROCESSO",
                newName: "ProcessoId");

            migrationBuilder.RenameColumn(
                name: "OUTROSENVOLVIDOSID",
                table: "PESSOAPROCESSO",
                newName: "OutrosEnvolvidosId");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAPROCESSO_PROCESSOID",
                table: "PESSOAPROCESSO",
                newName: "IX_PESSOAPROCESSO_ProcessoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PESSOAHISTORICO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TITULOELEITOR",
                table: "PESSOA",
                newName: "TituloEleitor");

            migrationBuilder.RenameColumn(
                name: "TIPOEMAIL",
                table: "PESSOA",
                newName: "TipoEmail");

            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "PESSOA",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "SITE",
                table: "PESSOA",
                newName: "Site");

            migrationBuilder.RenameColumn(
                name: "SIMPLESNACIONAL",
                table: "PESSOA",
                newName: "SimplesNacional");

            migrationBuilder.RenameColumn(
                name: "PISPASEP",
                table: "PESSOA",
                newName: "PisPasep");

            migrationBuilder.RenameColumn(
                name: "PERFIL",
                table: "PESSOA",
                newName: "Perfil");

            migrationBuilder.RenameColumn(
                name: "PASSAPORTE",
                table: "PESSOA",
                newName: "Passaporte");

            migrationBuilder.RenameColumn(
                name: "INSCRICAOMUNICIPAL",
                table: "PESSOA",
                newName: "InscricaoMunicipal");

            migrationBuilder.RenameColumn(
                name: "INSCRICAOESTADUAL",
                table: "PESSOA",
                newName: "InscricaoEstadual");

            migrationBuilder.RenameColumn(
                name: "ETIQUETA",
                table: "PESSOA",
                newName: "Etiqueta");

            migrationBuilder.RenameColumn(
                name: "CERTIDAORESERVISTA",
                table: "PESSOA",
                newName: "CertidaoReservista");

            migrationBuilder.RenameColumn(
                name: "CARTEIRATRABALHO",
                table: "PESSOA",
                newName: "CarteiraTrabalho");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PESSOA",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "NIVEL",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SUCESSO",
                table: "LOGINHISTORY",
                newName: "Sucesso");

            migrationBuilder.RenameColumn(
                name: "IDUSUARIO",
                table: "LOGINHISTORY",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "DATAHORAACESSO",
                table: "LOGINHISTORY",
                newName: "DataHoraAcesso");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LOGINHISTORY",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LOGINHISTORY_IDUSUARIO",
                table: "LOGINHISTORY",
                newName: "IX_LOGINHISTORY_IdUsuario");

            migrationBuilder.RenameColumn(
                name: "NOMEEMPRESA",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "NomeEmpresa");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IDSETOR",
                table: "GRUPOSETORES",
                newName: "IdSetor");

            migrationBuilder.RenameColumn(
                name: "IDUSUARIO",
                table: "GRUPOSETORES",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOSETORES_IDSETOR",
                table: "GRUPOSETORES",
                newName: "IX_GRUPOSETORES_IdSetor");

            migrationBuilder.RenameColumn(
                name: "IDPROCESSO",
                table: "GRUPOPESSOACLIENTES",
                newName: "IdProcesso");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "GRUPOPESSOACLIENTES",
                newName: "IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOPESSOACLIENTES_IDPROCESSO",
                table: "GRUPOPESSOACLIENTES",
                newName: "IX_GRUPOPESSOACLIENTES_IdProcesso");

            migrationBuilder.RenameColumn(
                name: "IDNIVEL",
                table: "GRUPONIVEL",
                newName: "IdNivel");

            migrationBuilder.RenameColumn(
                name: "IDUSUARIO",
                table: "GRUPONIVEL",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPONIVEL_IDNIVEL",
                table: "GRUPONIVEL",
                newName: "IX_GRUPONIVEL_IdNivel");

            migrationBuilder.RenameColumn(
                name: "FILEURL",
                table: "FOTOS",
                newName: "FileUrl");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "FOTOS",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "FORO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ENDERECO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ACAO",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPONIVEL_NIVEL_IdNivel",
                table: "GRUPONIVEL",
                column: "IdNivel",
                principalTable: "NIVEL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPONIVEL_USUARIOS_IdUsuario",
                table: "GRUPONIVEL",
                column: "IdUsuario",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PESSOA_IdPessoa",
                table: "GRUPOPESSOACLIENTES",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_PROCESSO_IdProcesso",
                table: "GRUPOPESSOACLIENTES",
                column: "IdProcesso",
                principalTable: "PROCESSO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOSETORES_SETORES_IdSetor",
                table: "GRUPOSETORES",
                column: "IdSetor",
                principalTable: "SETORES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOSETORES_USUARIOS_IdUsuario",
                table: "GRUPOSETORES",
                column: "IdUsuario",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_IdUsuario",
                table: "LOGINHISTORY",
                column: "IdUsuario",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaHistorico_Pessoa",
                table: "PESSOAHISTORICO",
                column: "PESSOA_ID",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaHistorico_Usuario",
                table: "PESSOAHISTORICO",
                column: "USUARIO_ID",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAPROCESSO_PESSOA_OutrosEnvolvidosId",
                table: "PESSOAPROCESSO",
                column: "OutrosEnvolvidosId",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAPROCESSO_PROCESSO_ProcessoId",
                table: "PESSOAPROCESSO",
                column: "ProcessoId",
                principalTable: "PROCESSO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSO_ACAO_IdAcao",
                table: "PROCESSO",
                column: "IdAcao",
                principalTable: "ACAO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSO_FORO_IdForo",
                table: "PROCESSO",
                column: "IdForo",
                principalTable: "FORO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QUALIFICACAO_PROCESSO_Id",
                table: "QUALIFICACAO",
                column: "Id",
                principalTable: "PROCESSO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
