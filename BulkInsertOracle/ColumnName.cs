﻿namespace BulkInsertOracle;

public class ColumnName
{
    public static string ABRANGENCIA => "ABRANGENCIA";
    public static string ACOMODACAO => "ACOMODACAO";
    public static string ADMINISTRADORA_BENEF => "ADMINISTRADORA_BENEF";
    public static string CARATER_ATEND => "CARATER_ATEND";
    public static string CNPJ => "CNPJ";
    public static string COBERTURA_ADICIONAL => "COBERTURA_ADICIONAL";
    public static string COD_BENEFICIARIO => "COD_BENEFICIARIO";
    public static string COD_CID => "COD_CID";
    public static string COD_CONTRATO => "COD_CONTRATO";
    public static string COD_PLANTA => "COD_PLANTA";
    public static string COD_PROCED => "COD_PROCED";
    public static string COMPARTILHAMENTO => "COMPARTILHAMENTO";
    public static string COMPETENCIA => "COMPETENCIA";
    public static string CONTRATACAO => "CONTRATACAO";
    public static string CONTR_COMERCIALIZACAO => "CONTR_COMERCIALIZACAO";
    public static string COPART_AMB => "COPART_AMB";
    public static string COPART_INTER => "COPART_INTER";
    public static string CPF => "CPF";
    public static string CUSTO => "CUSTO";
    public static string DEMOSTRATIVO_PAGTO => "DEMOSTRATIVO_PAGTO";
    public static string DESC_CID => "DESC_CID";
    public static string DESC_PROCED => "DESC_PROCED";
    public static string DT_ALTA => "DT_ALTA";
    public static string DT_EXCLUSAO => "DT_EXCLUSAO";
    public static string DT_EXCLUSAO_CONTRATO => "DT_EXCLUSAO_CONTRATO";
    public static string DT_EXECUCAO => "DT_EXECUCAO";
    public static string DT_INCLUSAO => "DT_INCLUSAO";
    public static string DT_INCLUSAO_CONTRATO => "DT_INCLUSAO_CONTRATO";
    public static string DT_INTERNACAO => "DT_INTERNACAO";
    public static string DT_NASCIMENTO => "DT_NASCIMENTO";
    public static string DT_OCORRENCIA => "DT_OCORRENCIA";
    public static string ESPECIALIDADE_EXEC => "ESPECIALIDADE_EXEC";
    public static string ESPECIALIDADE_SOLIC => "ESPECIALIDADE_SOLIC";
    public static string EXCLUSIVO_EX_EMPREG => "EXCLUSIVO_EX_EMPREG";
    public static string EXPOSTO => "EXPOSTO";
    public static string FATOR_EMERGENCIA_PAGTO => "FATOR_EMERGENCIA_PAGTO";
    public static string FATOR_INTERNACAO_APTO_PAGTO => "FATOR_INTERNACAO_APTO_PAGTO";
    public static string FATOR_VIA_DE_ACESSO_PAGTO => "FATOR_VIA_DE_ACESSO_PAGTO";
    public static string FATURA => "FATURA";
    public static string FIM_APURACAO => "FIM_APURACAO";
    public static string FLG_AJIUS => "FLG_AJIUS";
    public static string GLOSA => "GLOSA";
    public static string GRUPO_ECONOMICO => "GRUPO_ECONOMICO";
    public static string GUIA => "GUIA";
    public static string GUIA_PRINCIPAL => "GUIA_PRINCIPAL";
    public static string INDICE_APLICADO => "INDICE_APLICADO";
    public static string INICIO_APURACAO => "INICIO_APURACAO";
    public static string LOCAL_ATEND => "LOCAL_ATEND";
    public static string LOCAL_ATEND_CIDADE => "LOCAL_ATEND_CIDADE";
    public static string LOCAL_ATEND_NOME => "LOCAL_ATEND_NOME";
    public static string MES_REAJUSTE => "MES_REAJUSTE";
    public static string MODALIDADE => "MODALIDADE";
    public static string MOTIVO_DA_ALTA => "MOTIVO_DA_ALTA";
    public static string MUNICIPIO_RESIDENCIA => "MUNICIPIO_RESIDENCIA";
    public static string NOME_BENEFICIARIO => "NOME_BENEFICIARIO";
    public static string NOME_EMPRESA => "NOME_EMPRESA";
    public static string NOME_PLANO => "NOME_PLANO";
    public static string PAGTO_COMPLEMENTAR => "PAGTO_COMPLEMENTAR";
    public static string PARTICIPACAO_EXEC => "PARTICIPACAO_EXEC";
    public static string PRESTADOR => "PRESTADOR";
    public static string PRESTADOR_EXEC_CIDADE => "PRESTADOR_EXEC_CIDADE";
    public static string PRESTADOR_EXEC_NOME => "PRESTADOR_EXEC_NOME";
    public static string PRESTADOR_SOLIC => "PRESTADOR_SOLIC";
    public static string PRESTADOR_SOLIC_NOME => "PRESTADOR_SOLIC_NOME";
    public static string QTD_PROCED => "QTD_PROCED";
    public static string RECEITA => "RECEITA";
    public static string RECUP_CUSTO => "RECUP_CUSTO";
    public static string REDE => "REDE";
    public static string REGISTRO_ANS => "REGISTRO_ANS";
    public static string REGULAMENTADO => "REGULAMENTADO";
    public static string REMIDO => "REMIDO";
    public static string SEGMENTACAO => "SEGMENTACAO";
    public static string SEQUENCIA_ITEM => "SEQUENCIA_ITEM";
    public static string SEQ_LINHA_ARQUIVO => "SEQ_LINHA_ARQUIVO";
    public static string SEXO => "SEXO";
    public static string TAXA_ADM_SERV => "TAXA_ADM_SERV";
    public static string TIPO_COMPARTILHAMENTO => "TIPO_COMPARTILHAMENTO";
    public static string TIPO_COPARTICIPACAO => "TIPO_COPARTICIPACAO";
    public static string TIPO_DIRECIONAMENTO => "TIPO_DIRECIONAMENTO";
    public static string TIPO_INTERNACAO => "TIPO_INTERNACAO";
    public static string TIPO_ITEM => "TIPO_ITEM";
    public static string TIPO_PRESTADOR => "TIPO_PRESTADOR";
    public static string TIPO_REAJUSTE => "TIPO_REAJUSTE";
    public static string TX_INTERCAMBIO_CUSTO => "TX_INTERCAMBIO_CUSTO";
    public static string UD_BASE => "UD_BASE";
    public static string UD_EXECUTORA => "UD_EXECUTORA";
    public static string UD_ORIGEM => "UD_ORIGEM";
    public static string UF_RESIDENCIA => "UF_RESIDENCIA";
    public static string ULTIMA_MENSALIDADE => "ULTIMA_MENSALIDADE";
    public static string VERSAO_TABELA => "VERSAO_TABELA";
    public static string VINCULO => "VINCULO";
    public static string VL_FAT_PTU_A500 => "VL_FAT_PTU_A500";
    public static string VL_PAGTO_PRESTADOR => "VL_PAGTO_PRESTADOR";

    public static IEnumerable<string> Todos()
    {
        yield return ABRANGENCIA;
        yield return ACOMODACAO;
        yield return ADMINISTRADORA_BENEF;
        yield return CARATER_ATEND;
        yield return CNPJ;
        yield return COBERTURA_ADICIONAL;
        yield return COD_BENEFICIARIO;
        yield return COD_CID;
        yield return COD_CONTRATO;
        yield return COD_PLANTA;
        yield return COD_PROCED;
        yield return COMPARTILHAMENTO;
        yield return COMPETENCIA;
        yield return CONTRATACAO;
        yield return CONTR_COMERCIALIZACAO;
        yield return COPART_AMB;
        yield return COPART_INTER;
        yield return CPF;
        yield return CUSTO;
        yield return DEMOSTRATIVO_PAGTO;
        yield return DESC_CID;
        yield return DESC_PROCED;
        yield return DT_ALTA;
        yield return DT_EXCLUSAO;
        yield return DT_EXCLUSAO_CONTRATO;
        yield return DT_EXECUCAO;
        yield return DT_INCLUSAO;
        yield return DT_INCLUSAO_CONTRATO;
        yield return DT_INTERNACAO;
        yield return DT_NASCIMENTO;
        yield return DT_OCORRENCIA;
        yield return ESPECIALIDADE_EXEC;
        yield return ESPECIALIDADE_SOLIC;
        yield return EXCLUSIVO_EX_EMPREG;
        yield return EXPOSTO;
        yield return FATOR_EMERGENCIA_PAGTO;
        yield return FATOR_INTERNACAO_APTO_PAGTO;
        yield return FATOR_VIA_DE_ACESSO_PAGTO;
        yield return FATURA;
        yield return FIM_APURACAO;
        yield return FLG_AJIUS;
        yield return GLOSA;
        yield return GRUPO_ECONOMICO;
        yield return GUIA;
        yield return GUIA_PRINCIPAL;
        yield return INDICE_APLICADO;
        yield return INICIO_APURACAO;
        yield return LOCAL_ATEND;
        yield return LOCAL_ATEND_CIDADE;
        yield return LOCAL_ATEND_NOME;
        yield return MES_REAJUSTE;
        yield return MODALIDADE;
        yield return MOTIVO_DA_ALTA;
        yield return MUNICIPIO_RESIDENCIA;
        yield return NOME_BENEFICIARIO;
        yield return NOME_EMPRESA;
        yield return NOME_PLANO;
        yield return PAGTO_COMPLEMENTAR;
        yield return PARTICIPACAO_EXEC;
        yield return PRESTADOR;
        yield return PRESTADOR_EXEC_CIDADE;
        yield return PRESTADOR_EXEC_NOME;
        yield return PRESTADOR_SOLIC;
        yield return PRESTADOR_SOLIC_NOME;
        yield return QTD_PROCED;
        yield return RECEITA;
        yield return RECUP_CUSTO;
        yield return REDE;
        yield return REGISTRO_ANS;
        yield return REGULAMENTADO;
        yield return REMIDO;
        yield return SEGMENTACAO;
        yield return SEQUENCIA_ITEM;
        yield return SEQ_LINHA_ARQUIVO;
        yield return SEXO;
        yield return TAXA_ADM_SERV;
        yield return TIPO_COMPARTILHAMENTO;
        yield return TIPO_COPARTICIPACAO;
        yield return TIPO_DIRECIONAMENTO;
        yield return TIPO_INTERNACAO;
        yield return TIPO_ITEM;
        yield return TIPO_PRESTADOR;
        yield return TIPO_REAJUSTE;
        yield return TX_INTERCAMBIO_CUSTO;
        yield return UD_BASE;
        yield return UD_EXECUTORA;
        yield return UD_ORIGEM;
        yield return UF_RESIDENCIA;
        yield return ULTIMA_MENSALIDADE;
        yield return VERSAO_TABELA;
        yield return VINCULO;
        yield return VL_FAT_PTU_A500;
        yield return VL_PAGTO_PRESTADOR;
    }
}