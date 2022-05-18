using System.Globalization;

namespace BulkInsertOracle;
public static class DataMapper
{
    public static void MapToModel(RdcModel model, string field, string headerName)
    {
        switch (headerName)
        {
            case "INICIO_APURACAO":
                model.INICIO_APURACAO = ParseDate(field);
                break;
            case "FIM_APURACAO":
                model.FIM_APURACAO = ParseDate(field);
                break;
            case "CODIGO_BENEFICIARIO":
                model.CODIGO_BENEFICIARIO = field;
                break;
            case "DATA_NASCIMENTO":
                model.DATA_NASCIMENTO = ParseDate(field);
                break;
            case "DATA_INCLUSAO":
                model.DATA_INCLUSAO = ParseDate(field);
                break;
            case "DATA_EXCLUSAO":
                model.DATA_EXCLUSAO = ParseDate(field);
                break;
            case "CONTRATACAO":
                model.CONTRATACAO = ParseInt(field);
                break;
            case "SEGMENTACAO":
                model.SEGMENTACAO = ParseInt(field);
                break;
            case "ABRANGENCIA":
                model.ABRANGENCIA = ParseInt(field);
                break;
            case "ACOMODACAO":
                model.ACOMODACAO = ParseInt(field);
                break;
            case "NOME_PLANO":
                model.NOME_PLANO = field;
                break;
            case "REGISTRO_ANS":
                model.REGISTRO_ANS = field;
                break;
            case "CO_PARTICIPACAO_AMB":
                model.CO_PARTICIPACAO_AMB = ParseInt(field);
                break;
            case "CO_PARTICIPACAO_INTER":
                model.CO_PARTICIPACAO_INTER = ParseInt(field);
                break;
            case "COD_PROCEDIMENTO":
                model.COD_PROCEDIMENTO = ParseLong(field);
                break;
            case "GUIA":
                model.GUIA = field;
                break;
            case "DESC_PROCEDIMENTO":
                model.DESC_PROCEDIMENTO = field;
                break;
            case "QTD_PROCED":
                model.QTD_PROCED = ParseLong(field);
                break;
            case "CUSTO":
                model.CUSTO = ParseDecimal(field);
                break;
            case "RECUP_CUSTO_(VF+TXADM)":
                model.RECUP_CUSTO = ParseDecimal(field);
                break;
            case "DATA_OCORRENCIA":
                model.DATA_OCORRENCIA = ParseDate(field);
                break;
            case "DATA_INTERNACAO":
                model.DATA_INTERNACAO = ParseDate(field);
                break;
            case "DATA_ALTA":
                model.DATA_ALTA = ParseDate(field);
                break;
            case "CODIGO_CID":
                model.CODIGO_CID = field;
                break;
            case "DESC_CID":
                model.DESC_CID = field;
                break;
            case "TIPO_INTERNACAO":
                model.TIPO_INTERNACAO = ParseInt(field);
                break;
            case "PRESTADOR":
                model.PRESTADOR = field;
                break;
            case "NOME_BENEFICIARIO":
                model.NOME_BENEFICIARIO = field;
                break;
            case "SEXO":
                model.SEXO = field;
                break;
            case "MUNICIPIO_RESIDENCIA":
                model.MUNICIPIO_RESIDENCIA = field;
                break;
            case "UF_RESIDENCIA":
                model.UF_RESIDENCIA = field;
                break;
            case "UD_EXECUTORA":
                model.UD_EXECUTORA = ParseInt(field);
                break;
            case "ADMINISTRADORA_BENEF":
                model.ADMINISTRADORA_BENEF = field;
                break;
            case "CONTR_COMERCIALIZACAO":
                model.CONTR_COMERCIALIZACAO = field;
                break;
            case "CODIGO_CONTRATO":
                model.CODIGO_CONTRATO = field;
                break;
            case "DATA_INCLUSAO_CONTRATO":
                model.DATA_INCLUSAO_CONTRATO = ParseDate(field);
                break;
            case "DATA_EXCLUSAO_CONTRATO":
                model.DATA_EXCLUSAO_CONTRATO = ParseDate(field);
                break;
            case "CNPJ":
                model.CNPJ = field;
                break;
            case "NOME_EMPRESA":
                model.NOME_EMPRESA = field;
                break;
            case "MES_REAJUSTE":
                model.MES_REAJUSTE = ParseInt(field);
                break;
            case "EXCLUSIVO_EX_EMPREG":
                model.EXCLUSIVO_EX_EMPREG = field;
                break;
            case "TIPO_REAJUSTE":
                model.TIPO_REAJUSTE = ParseInt(field);
                break;
            case "REGULAMENTADO":
                model.REGULAMENTADO = field;
                break;
            case "MODALIDADE":
                model.MODALIDADE = field;
                break;
            case "RECEITA":
                model.RECEITA = ParseDecimal(field);
                break;
            case "TAXA_ADM_SERV":
                model.TAXA_ADM_SERV = field;
                break;
            case "CPF":
                model.CPF = field;
                break;
            case "VINCULO":
                model.VINCULO = ParseInt(field);
                break;
            case "PRESTADOR_SOLICITANTE":
                model.PRESTADOR_SOLICITANTE = field;
                break;
            case "ESPECIALIDADE_SOLICITANTE":
                model.ESPECIALIDADE_SOLICITANTE = field;
                break;
            case "PRESTADOR_EXECUTANTE_NOME":
                model.PRESTADOR_EXECUTANTE_NOME = field;
                break;
            case "ESPECIALIDADE_EXECUTANTE":
                model.ESPECIALIDADE_EXECUTANTE = field;
                break;
            case "VALOR_PAGAMENTO_PRESTADOR":
                model.VALOR_PAGAMENTO_PRESTADOR = field;
                break;
            case "GUIA_PRINCIPAL":
                model.GUIA_PRINCIPAL = field;
                break;
            case "VERSAO_TABELA":
                model.VERSAO_TABELA = ParseInt(field);
                break;
            case "PARTICIPAÇÃO_EXECUTANTE":
                model.PARTICIPAÇÃO_EXECUTANTE = ParseInt(field);
                break;
            case "INDICE_APLICADO":
                model.INDICE_APLICADO = field;
                break;
            case "ULTIMA_MENSALIDADE":
                model.ULTIMA_MENSALIDADE = ParseDecimal(field);
                break;
            case "GLOSA":
                model.GLOSA = ParseDecimal(field);
                break;
            case "PAGAMENTO_COMPLEMENTAR":
                model.PAGAMENTO_COMPLEMENTAR = ParseDecimal(field);
                break;
            case "UD_BASE":
                model.UD_BASE = ParseInt(field);
                break;
            case "REDE":
                model.REDE = field;
                break;
            case "FATURA":
                model.FATURA = field;
                break;
            case "VALOR_FAT_PTU_A500":
                model.VALOR_FAT_PTU_A500 = ParseDecimal(field);
                break;
            case "TIPO_ITEM":
                model.TIPO_ITEM = ParseInt(field);
                break;
            case "DATA_EXECUCAO":
                model.DATA_EXECUCAO = ParseDate(field);
                break;
            case "TIPO_PRESTADOR":
                model.TIPO_PRESTADOR = ParseInt(field);
                break;
            case "DEMOSTRATIVO_PAGTO":
                model.DEMOSTRATIVO_PAGTO = field;
                break;
            case "LOCAL_ATENDIMENTO":
                model.LOCAL_ATENDIMENTO = field;
                break;
            case "COMPARTILHAMENTO":
                model.COMPARTILHAMENTO = field;
                break;
            case "TIPO_COMPARTILHAMENTO":
                model.TIPO_COMPARTILHAMENTO = field;
                break;
            case "REMIDO":
                model.REMIDO = field;
                break;
            case "SEQUENCIA_ITEM":
                model.SEQUENCIA_ITEM = field;
                break;
            case "CARATER_ATEND":
                model.CARATER_ATEND = field;
                break;
            case "TIPO_DIRECIONAMENTO":
                model.TIPO_DIRECIONAMENTO = ParseInt(field);
                break;
            case "FATOR_INTERNACAO_APTO_PAGAMENTO":
                model.FATOR_INTERNACAO_APTO_PAGAMENTO = ParseInt(field);
                break;
            case "FATOR_VIA_DE_ACESSO_PAGAMENTO":
                model.FATOR_VIA_DE_ACESSO_PAGAMENTO = ParseInt(field);
                break;
            case "FATOR_EMERGENCIA_PAGAMENTO":
                model.FATOR_EMERGENCIA_PAGAMENTO = ParseInt(field);
                break;
            case "TAXA_DE_INTERCAMBIO_CUSTO":
                model.TAXA_DE_INTERCAMBIO_CUSTO = ParseDecimal(field);
                break;
            case "MOTIVO_DA_ALTA":
                model.MOTIVO_DA_ALTA = ParseInt(field);
                break;
            case "FLG_AJIUS":
                model.FLG_AJIUS = field;
                break;
            case "LOCAL_ATENDIMENTO_NOME":
                model.LOCAL_ATENDIMENTO_NOME = field;
                break;
            case "LOCAL_ATENDIMENTO_CIDADE":
                model.LOCAL_ATENDIMENTO_CIDADE = field;
                break;
            case "PRESTADOR_SOLICITANTE_NOME":
                model.PRESTADOR_SOLICITANTE_NOME = field;
                break;
            case "PRESTADOR_EXECUTANTE_CIDADE":
                model.PRESTADOR_EXECUTANTE_CIDADE = field;
                break;
            case "COBERTURA_ADICIONAL":
                model.COBERTURA_ADICIONAL = field;
                break;
            case "GRUPO_ECONOMICO":
                model.GRUPO_ECONOMICO = field;
                break;
            case "TIPO_COPARTICIPACAO":
                model.TIPO_COPARTICIPACAO = field;
                break;
            case "COD_PLANTA":
                model.COD_PLANTA = field;
                break;
            case "EXPOSTO":
                model.EXPOSTO = field;
                break;
            default:
                break;
        }
    }

    static DateTime ParseDate(string field)
    {
        return DateTime.TryParseExact(field, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
            ? result :
            default;
    }

    static int ParseInt(string field)
    {
        return int.TryParse(field, out var result)
            ? result :
            default;
    }

    static long ParseLong(string field)
    {
        return long.TryParse(field, out var result)
            ? result :
            default;
    }

    static decimal ParseDecimal(string field)
    {
        return decimal.TryParse(field, out var result)
            ? result :
            default;
    }

}
