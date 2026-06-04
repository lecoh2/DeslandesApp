using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OBSERVACAO",
                table: "CONTRATO",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VARA_USUARIOCADASTROID",
                table: "VARA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_USUARIOCADASTROID",
                table: "USUARIOS",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_USUARIOCADASTROID",
                table: "TAREFA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_SETORES_USUARIOCADASTROID",
                table: "SETORES",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_QUALIFICACAO_USUARIOCADASTROID",
                table: "QUALIFICACAO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_USUARIOCADASTROID",
                table: "PESSOA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_NIVEL_USUARIOCADASTROID",
                table: "NIVEL",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_LOGINHISTORY_USUARIOCADASTROID",
                table: "LOGINHISTORY",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_LISTATAREFA_USUARIOCADASTROID",
                table: "LISTATAREFA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_USUARIOCADASTROID",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOGERAL_USUARIOCADASTROID",
                table: "HISTORICOGERAL",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOCASOENVOLVIDO_USUARIOCADASTROID",
                table: "GRUPOCASOENVOLVIDO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_FOTOS_USUARIOCADASTROID",
                table: "FOTOS",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_FORO_USUARIOCADASTROID",
                table: "FORO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_FORMA_PAGAMENTO_USUARIOCADASTROID",
                table: "FORMA_PAGAMENTO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_FAILEDLOGINATTEMPTS_USUARIOCADASTROID",
                table: "FAILEDLOGINATTEMPTS",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_USUARIOCADASTROID",
                table: "EVENTO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_ETIQUETA_USUARIOCADASTROID",
                table: "ETIQUETA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_USUARIOCADASTROID",
                table: "ENDERECO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRATO_USUARIOCADASTROID",
                table: "CONTRATO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTABANCARIAEMPRESA_USUARIOCADASTROID",
                table: "CONTABANCARIAEMPRESA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTABANCARIA_USUARIOCADASTROID",
                table: "CONTABANCARIA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_USUARIOCADASTROID",
                table: "CONTA_RECEBER",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_PAGAR_USUARIOCADASTROID",
                table: "CONTA_PAGAR",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_USUARIOCADASTROID",
                table: "COMENTARIOS",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CENTRO_CUSTO_USUARIOCADASTROID",
                table: "CENTRO_CUSTO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_FINANCEIRA_USUARIOCADASTROID",
                table: "CATEGORIA_FINANCEIRA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_USUARIOCADASTROID",
                table: "BAIXA_FINANCEIRA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTOHISTORICO_USUARIOCADASTROID",
                table: "ATENDIMENTOHISTORICO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_ACAO_USUARIOCADASTROID",
                table: "ACAO",
                column: "USUARIOCADASTROID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACAO_USUARIOS_USUARIOCADASTROID",
                table: "ACAO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTOHISTORICO_USUARIOS_USUARIOCADASTROID",
                table: "ATENDIMENTOHISTORICO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BAIXA_FINANCEIRA_USUARIOS_USUARIOCADASTROID",
                table: "BAIXA_FINANCEIRA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORIA_FINANCEIRA_USUARIOS_USUARIOCADASTROID",
                table: "CATEGORIA_FINANCEIRA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CENTRO_CUSTO_USUARIOS_USUARIOCADASTROID",
                table: "CENTRO_CUSTO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_COMENTARIOS_USUARIOS_USUARIOCADASTROID",
                table: "COMENTARIOS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_PAGAR_USUARIOS_USUARIOCADASTROID",
                table: "CONTA_PAGAR",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_RECEBER_USUARIOS_USUARIOCADASTROID",
                table: "CONTA_RECEBER",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTABANCARIA_USUARIOS_USUARIOCADASTROID",
                table: "CONTABANCARIA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTABANCARIAEMPRESA_USUARIOS_USUARIOCADASTROID",
                table: "CONTABANCARIAEMPRESA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTRATO_USUARIOS_USUARIOCADASTROID",
                table: "CONTRATO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECO_USUARIOS_USUARIOCADASTROID",
                table: "ENDERECO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ETIQUETA_USUARIOS_USUARIOCADASTROID",
                table: "ETIQUETA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTO_USUARIOS_USUARIOCADASTROID",
                table: "EVENTO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FAILEDLOGINATTEMPTS_USUARIOS_USUARIOCADASTROID",
                table: "FAILEDLOGINATTEMPTS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FORMA_PAGAMENTO_USUARIOS_USUARIOCADASTROID",
                table: "FORMA_PAGAMENTO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FORO_USUARIOS_USUARIOCADASTROID",
                table: "FORO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FOTOS_USUARIOS_USUARIOCADASTROID",
                table: "FOTOS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOCASOENVOLVIDO_USUARIOS_USUARIOCADASTROID",
                table: "GRUPOCASOENVOLVIDO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_HISTORICOGERAL_USUARIOS_USUARIOCADASTROID",
                table: "HISTORICOGERAL",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_USUARIOS_USUARIOCADASTROID",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_USUARIOS_USUARIOCADASTROID",
                table: "LISTATAREFA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_USUARIOCADASTROID",
                table: "LOGINHISTORY",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NIVEL_USUARIOS_USUARIOCADASTROID",
                table: "NIVEL",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_USUARIOS_USUARIOCADASTROID",
                table: "PESSOA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_QUALIFICACAO_USUARIOS_USUARIOCADASTROID",
                table: "QUALIFICACAO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SETORES_USUARIOS_USUARIOCADASTROID",
                table: "SETORES",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_USUARIOS_USUARIOCADASTROID",
                table: "TAREFA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOCADASTROID",
                table: "USUARIOS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VARA_USUARIOS_USUARIOCADASTROID",
                table: "VARA",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACAO_USUARIOS_USUARIOCADASTROID",
                table: "ACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTOHISTORICO_USUARIOS_USUARIOCADASTROID",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropForeignKey(
                name: "FK_BAIXA_FINANCEIRA_USUARIOS_USUARIOCADASTROID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORIA_FINANCEIRA_USUARIOS_USUARIOCADASTROID",
                table: "CATEGORIA_FINANCEIRA");

            migrationBuilder.DropForeignKey(
                name: "FK_CENTRO_CUSTO_USUARIOS_USUARIOCADASTROID",
                table: "CENTRO_CUSTO");

            migrationBuilder.DropForeignKey(
                name: "FK_COMENTARIOS_USUARIOS_USUARIOCADASTROID",
                table: "COMENTARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_PAGAR_USUARIOS_USUARIOCADASTROID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_RECEBER_USUARIOS_USUARIOCADASTROID",
                table: "CONTA_RECEBER");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTABANCARIA_USUARIOS_USUARIOCADASTROID",
                table: "CONTABANCARIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTABANCARIAEMPRESA_USUARIOS_USUARIOCADASTROID",
                table: "CONTABANCARIAEMPRESA");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTRATO_USUARIOS_USUARIOCADASTROID",
                table: "CONTRATO");

            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECO_USUARIOS_USUARIOCADASTROID",
                table: "ENDERECO");

            migrationBuilder.DropForeignKey(
                name: "FK_ETIQUETA_USUARIOS_USUARIOCADASTROID",
                table: "ETIQUETA");

            migrationBuilder.DropForeignKey(
                name: "FK_EVENTO_USUARIOS_USUARIOCADASTROID",
                table: "EVENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_FAILEDLOGINATTEMPTS_USUARIOS_USUARIOCADASTROID",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropForeignKey(
                name: "FK_FORMA_PAGAMENTO_USUARIOS_USUARIOCADASTROID",
                table: "FORMA_PAGAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_FORO_USUARIOS_USUARIOCADASTROID",
                table: "FORO");

            migrationBuilder.DropForeignKey(
                name: "FK_FOTOS_USUARIOS_USUARIOCADASTROID",
                table: "FOTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOCASOENVOLVIDO_USUARIOS_USUARIOCADASTROID",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_HISTORICOGERAL_USUARIOS_USUARIOCADASTROID",
                table: "HISTORICOGERAL");

            migrationBuilder.DropForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_USUARIOS_USUARIOCADASTROID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_USUARIOS_USUARIOCADASTROID",
                table: "LISTATAREFA");

            migrationBuilder.DropForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_USUARIOCADASTROID",
                table: "LOGINHISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_NIVEL_USUARIOS_USUARIOCADASTROID",
                table: "NIVEL");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_USUARIOS_USUARIOCADASTROID",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_QUALIFICACAO_USUARIOS_USUARIOCADASTROID",
                table: "QUALIFICACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_SETORES_USUARIOS_USUARIOCADASTROID",
                table: "SETORES");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_USUARIOS_USUARIOCADASTROID",
                table: "TAREFA");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOCADASTROID",
                table: "USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VARA_USUARIOS_USUARIOCADASTROID",
                table: "VARA");

            migrationBuilder.DropIndex(
                name: "IX_VARA_USUARIOCADASTROID",
                table: "VARA");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOCADASTROID",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TAREFA_USUARIOCADASTROID",
                table: "TAREFA");

            migrationBuilder.DropIndex(
                name: "IX_SETORES_USUARIOCADASTROID",
                table: "SETORES");

            migrationBuilder.DropIndex(
                name: "IX_QUALIFICACAO_USUARIOCADASTROID",
                table: "QUALIFICACAO");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_USUARIOCADASTROID",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_NIVEL_USUARIOCADASTROID",
                table: "NIVEL");

            migrationBuilder.DropIndex(
                name: "IX_LOGINHISTORY_USUARIOCADASTROID",
                table: "LOGINHISTORY");

            migrationBuilder.DropIndex(
                name: "IX_LISTATAREFA_USUARIOCADASTROID",
                table: "LISTATAREFA");

            migrationBuilder.DropIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_USUARIOCADASTROID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropIndex(
                name: "IX_HISTORICOGERAL_USUARIOCADASTROID",
                table: "HISTORICOGERAL");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOCASOENVOLVIDO_USUARIOCADASTROID",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropIndex(
                name: "IX_FOTOS_USUARIOCADASTROID",
                table: "FOTOS");

            migrationBuilder.DropIndex(
                name: "IX_FORO_USUARIOCADASTROID",
                table: "FORO");

            migrationBuilder.DropIndex(
                name: "IX_FORMA_PAGAMENTO_USUARIOCADASTROID",
                table: "FORMA_PAGAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_FAILEDLOGINATTEMPTS_USUARIOCADASTROID",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropIndex(
                name: "IX_EVENTO_USUARIOCADASTROID",
                table: "EVENTO");

            migrationBuilder.DropIndex(
                name: "IX_ETIQUETA_USUARIOCADASTROID",
                table: "ETIQUETA");

            migrationBuilder.DropIndex(
                name: "IX_ENDERECO_USUARIOCADASTROID",
                table: "ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_CONTRATO_USUARIOCADASTROID",
                table: "CONTRATO");

            migrationBuilder.DropIndex(
                name: "IX_CONTABANCARIAEMPRESA_USUARIOCADASTROID",
                table: "CONTABANCARIAEMPRESA");

            migrationBuilder.DropIndex(
                name: "IX_CONTABANCARIA_USUARIOCADASTROID",
                table: "CONTABANCARIA");

            migrationBuilder.DropIndex(
                name: "IX_CONTA_RECEBER_USUARIOCADASTROID",
                table: "CONTA_RECEBER");

            migrationBuilder.DropIndex(
                name: "IX_CONTA_PAGAR_USUARIOCADASTROID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropIndex(
                name: "IX_COMENTARIOS_USUARIOCADASTROID",
                table: "COMENTARIOS");

            migrationBuilder.DropIndex(
                name: "IX_CENTRO_CUSTO_USUARIOCADASTROID",
                table: "CENTRO_CUSTO");

            migrationBuilder.DropIndex(
                name: "IX_CATEGORIA_FINANCEIRA_USUARIOCADASTROID",
                table: "CATEGORIA_FINANCEIRA");

            migrationBuilder.DropIndex(
                name: "IX_BAIXA_FINANCEIRA_USUARIOCADASTROID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropIndex(
                name: "IX_ATENDIMENTOHISTORICO_USUARIOCADASTROID",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropIndex(
                name: "IX_ACAO_USUARIOCADASTROID",
                table: "ACAO");

            migrationBuilder.DropColumn(
                name: "OBSERVACAO",
                table: "CONTRATO");
        }
    }
}
