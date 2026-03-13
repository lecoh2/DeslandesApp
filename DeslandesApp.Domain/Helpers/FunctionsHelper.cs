using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Helpers
{
    public class FunctionsHelper
    {
        public static string LimparHtmlQuill(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return string.Empty;

            // Corrige fechamento errado </0l> para </ol>
            html = html.Replace("</0l>", "</ol>");

            // Remove spans vazios com contenteditable=false que o Quill insere
            html = Regex.Replace(html, @"<span[^>]*contenteditable=[""']false[""'][^>]*></span>", "");

            // Remove atributos como data-list das li
            html = Regex.Replace(html, @"(<li)[^>]*(>)", "$1$2");

            // Remove quebras e espaços extras entre tags
            html = Regex.Replace(html, @">\s+<", "><");

            // Opcional: remova outras tags ou atributos indesejados se precisar

            return html;
        }
        public string SubstituirBarraPorPipe(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            return texto.Replace("/", "|");
        }
        public static string ConverterHtmlParaFastReport(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return string.Empty;

            html = html
                .Replace("<strong>", "<b>").Replace("</strong>", "</b>")
                .Replace("<em>", "<i>").Replace("</em>", "</i>")
                .Replace("<u>", "<u>").Replace("</u>", "</u>")
                .Replace("<br/>", "<br>").Replace("<br />", "<br>")
                .Replace("&nbsp;", " ")
                .Replace("\n", "").Replace("\r", "");

            // Remove <div> e <span> mantendo conteúdo
            html = Regex.Replace(html, @"<(div|span)[^>]*>", "");
            html = Regex.Replace(html, @"</(div|span)>", "");

            // Tratar listas ordenadas e não ordenadas
            html = Regex.Replace(html, @"<ul[^>]*>", "");
            html = html.Replace("</ul>", "");
            html = Regex.Replace(html, @"<ol[^>]*>", "");
            html = html.Replace("</ol>", "");

            html = Regex.Replace(html, @"<li>(.*?)</li>", match => $"• {match.Groups[1].Value}<br>");

            // Substitui parágrafos por quebra dupla
            html = html.Replace("<p>", "").Replace("</p>", "<br><br>");

            return html;
        }
        public static string AjustarTagsParaFastReport(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return string.Empty;

            // Converte <strong> → <b>, <em> → <i>
            html = html
                .Replace("<strong>", "<b>").Replace("</strong>", "</b>")
                .Replace("<em>", "<i>").Replace("</em>", "</i>");

            // Remove todos os <span> mantendo o conteúdo
            html = Regex.Replace(html, @"<span[^>]*>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</span>", "", RegexOptions.IgnoreCase);

            // Converte <h1>, <h2>, ..., <h6> para <b> e adiciona <br><br>
            html = Regex.Replace(html, @"<h[1-6][^>]*>", "<b>", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</h[1-6]>", "</b><br><br>", RegexOptions.IgnoreCase);

            // Remove qualquer tag <div> mantendo conteúdo interno
            html = Regex.Replace(html, @"<div[^>]*>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</div>", "<br>", RegexOptions.IgnoreCase);

            // Converte parágrafos em <br><br>
            html = html.Replace("<p>", "").Replace("</p>", "<br><br>");

            // Normaliza quebras de linha do Quill
            html = html
                .Replace("<br/>", "<br>")
                .Replace("<br />", "<br>");

            // Remove espaços não quebráveis
            html = html.Replace("&nbsp;", " ");

            // Remove linhas em branco extras
            html = html.Replace("\n", "").Replace("\r", "");

            // Opcional: remove múltiplos <br> consecutivos
            html = Regex.Replace(html, @"(<br>\s*){3,}", "<br><br>");

            return html.Trim();
        }
        public static string RemovePontosTracos(string value)
        {
            //string textoLimpo = Regex.Replace(value, @"[.\-]", "");
            string textoLimpo = Regex.Replace(value ?? string.Empty, @"[^\d]", "");
            return textoLimpo;
        }
        public static string RemovePontosTracosTelefone(string value)
        {
            // Remove tudo que não for número ou ponto e vírgula
            string textoLimpo = Regex.Replace(value ?? string.Empty, @"[^\d\;]", "");
            return textoLimpo;
        }
        public static string FormatarCPF(string cpf)
        {
            // Utilizando uma expressão regular para formatar o CPF
            string cpfFormatado = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            return cpfFormatado;
        }
        public static string FormatarCEP(string cep)
        {
            if (cep.Length != 8)
            {
                // Retorna o CEP original se não tiver 8 dígitos
                return cep;
            }
            // Insere pontos e traço no CEP
            return $"{cep.Substring(0, 5)}-{cep.Substring(5)}";
        }
        public static string FormatarRG(string rg)
        {
            // Verifica se o RG tem pelo menos 9 dígitos
            if (rg.Length < 9)
            {
                return rg; // Retorna o RG original se não tiver pelo menos 9 dígitos
            }

            // Formata o RG com pontos e traço
            return $"{rg.Substring(0, 2)}.{rg.Substring(2, 3)}.{rg.Substring(5, 3)}-{rg.Substring(8)}";
        }
        public static bool ValidadorCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (CPF inválido)
            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            // Calcula os dígitos verificadores
            int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        public static bool ValidadorCNPJ(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = Regex.Replace(cnpj, "[^0-9]", "");

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais (CNPJ inválido)
            if (new string(cnpj[0], cnpj.Length) == cnpj)
                return false;

            int[] multiplicadores1 = new int[12]
                { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicadores2 = new int[13]
                { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
        public bool TemAlgumValor(InformacoesComplementaresRequest info)
        {
            if (info == null) return false;

            return !string.IsNullOrWhiteSpace(info.DataNascimento)
                || !string.IsNullOrWhiteSpace(info.NomeEmpresa)
                || !string.IsNullOrWhiteSpace(info.Profissao)
                || !string.IsNullOrWhiteSpace(info.AtividadeEconomica)
                || !string.IsNullOrWhiteSpace(info.EstadoCivil)
                || !string.IsNullOrWhiteSpace(info.Codigo)
                || !string.IsNullOrWhiteSpace(info.NomePai)
                || !string.IsNullOrWhiteSpace(info.NomeMae)
                || !string.IsNullOrWhiteSpace(info.Naturalidade)
                || !string.IsNullOrWhiteSpace(info.Nacionalidade)
                || !string.IsNullOrWhiteSpace(info.Comentario);
        }
    }
}
