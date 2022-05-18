namespace BulkInsertOracle;

#nullable disable

public class RdcModel
{
    public int SEQ_LINHA_ARQUIVO { get; set; }
    public string COMPETENCIA { get; set; }
    public int UNIMED_ORIGEM { get; set; }
    public DateTime INICIO_APURACAO { get; set; }
    public DateTime FIM_APURACAO { get; set; }
    public string CODIGO_BENEFICIARIO { get; set; } //COD_BENEFICIARIO
    public DateTime DATA_NASCIMENTO { get; set; } //DT_NASCIMENTO
    public DateTime DATA_INCLUSAO { get; set; } //DT_INCLUSAO
    public DateTime DATA_EXCLUSAO { get; set; } //DT_EXCLUSAO
    public int CONTRATACAO { get; set; }
    public int SEGMENTACAO { get; set; }
    public int ABRANGENCIA { get; set; }
    public int ACOMODACAO { get; set; }
    public string NOME_PLANO { get; set; }
    public string REGISTRO_ANS { get; set; }
    public int CO_PARTICIPACAO_AMB { get; set; } // COPART_AMB
    public int CO_PARTICIPACAO_INTER { get; set; } //COPART_INTER
    public long COD_PROCEDIMENTO { get; set; } //COD_PROCED
    public string GUIA { get; set; }
    public string DESC_PROCEDIMENTO { get; set; } //DESC_PROCED
    public long QTD_PROCED { get; set; }
    public decimal CUSTO { get; set; }
    public decimal RECUP_CUSTO { get; set; }
    public DateTime DATA_OCORRENCIA { get; set; }
    public DateTime DATA_INTERNACAO { get; set; }
    public DateTime DATA_ALTA { get; set; }
    public string CODIGO_CID { get; set; }
    public string DESC_CID { get; set; }
    public int TIPO_INTERNACAO { get; set; }
    public string PRESTADOR { get; set; }
    public string NOME_BENEFICIARIO { get; set; }
    public string SEXO { get; set; }
    public string MUNICIPIO_RESIDENCIA { get; set; }
    public string UF_RESIDENCIA { get; set; }
    public int UD_EXECUTORA { get; set; }
    public string ADMINISTRADORA_BENEF { get; set; }
    public string CONTR_COMERCIALIZACAO { get; set; }
    public string CODIGO_CONTRATO { get; set; } //COD_CONTRATO
    public DateTime DATA_INCLUSAO_CONTRATO { get; set; } //DT_INCLUSAO_CONTRATO
    public DateTime DATA_EXCLUSAO_CONTRATO { get; set; } //DT_EXCLUSAO_CONTRATO
    public string CNPJ { get; set; }
    public string NOME_EMPRESA { get; set; }
    public int MES_REAJUSTE { get; set; }
    public string EXCLUSIVO_EX_EMPREG { get; set; }
    public int TIPO_REAJUSTE { get; set; }
    public string REGULAMENTADO { get; set; }
    public string MODALIDADE { get; set; }
    public decimal RECEITA { get; set; }
    public string TAXA_ADM_SERV { get; set; }
    public string CPF { get; set; }
    public int VINCULO { get; set; }
    public string PRESTADOR_SOLICITANTE { get; set; }
    public string ESPECIALIDADE_SOLICITANTE { get; set; }
    public string PRESTADOR_EXECUTANTE_NOME { get; set; }
    public string ESPECIALIDADE_EXECUTANTE { get; set; }
    public string VALOR_PAGAMENTO_PRESTADOR { get; set; }
    public string GUIA_PRINCIPAL { get; set; }
    public int VERSAO_TABELA { get; set; }
    public int PARTICIPAÇÃO_EXECUTANTE { get; set; }
    public string INDICE_APLICADO { get; set; }
    public decimal ULTIMA_MENSALIDADE { get; set; }
    public decimal GLOSA { get; set; }
    public decimal PAGAMENTO_COMPLEMENTAR { get; set; }
    public int UD_BASE { get; set; }
    public string REDE { get; set; }
    public string FATURA { get; set; }
    public decimal VALOR_FAT_PTU_A500 { get; set; }
    public int TIPO_ITEM { get; set; }
    public DateTime DATA_EXECUCAO { get; set; }
    public int TIPO_PRESTADOR { get; set; }
    public string DEMOSTRATIVO_PAGTO { get; set; }
    public string LOCAL_ATENDIMENTO { get; set; }
    public string COMPARTILHAMENTO { get; set; }
    public string TIPO_COMPARTILHAMENTO { get; set; }
    public string REMIDO { get; set; }
    public string SEQUENCIA_ITEM { get; set; }
    public string CARATER_ATEND { get; set; }
    public int TIPO_DIRECIONAMENTO { get; set; }
    public int FATOR_INTERNACAO_APTO_PAGAMENTO { get; set; }
    public int FATOR_VIA_DE_ACESSO_PAGAMENTO { get; set; }
    public int FATOR_EMERGENCIA_PAGAMENTO { get; set; }
    public decimal TAXA_DE_INTERCAMBIO_CUSTO { get; set; }
    public int MOTIVO_DA_ALTA { get; set; }
    public string FLG_AJIUS { get; set; }
    public string LOCAL_ATENDIMENTO_NOME { get; set; }
    public string LOCAL_ATENDIMENTO_CIDADE { get; set; }
    public string PRESTADOR_SOLICITANTE_NOME { get; set; }
    public string PRESTADOR_EXECUTANTE_CIDADE { get; set; }
    public string COBERTURA_ADICIONAL { get; set; }
    public string GRUPO_ECONOMICO { get; set; }
    public string TIPO_COPARTICIPACAO { get; set; }
    public string COD_PLANTA { get; set; }
    public string EXPOSTO { get; set; }
}
