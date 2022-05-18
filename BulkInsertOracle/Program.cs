using BulkInsertOracle;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;
using System.Text;

const string cnnStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=TESTE;Password=senhaS3creta;";

var basePath = @"C:\src\BulkInsertOracle\BulkInsertOracle\Inputs";
var arqBaseFileName = "ARQ_BASE_RDC28_025_202112.txt";
var arqBaseFilePath = Path.Combine(basePath!, arqBaseFileName);
var batchSize = 1000;

try
{
    Console.WriteLine($"Starting... batchSize: {batchSize}");
    var stopWatch = new Stopwatch();
    
    var models = ReadLines();

    Console.WriteLine($"{models.Count} linhas, inserindo... {ObterTempo(stopWatch)}");

    stopWatch.Start();
    //await InsertLines(models, stopWatch);

    InserirBulkCopy(models);

    Console.WriteLine(ObterTempo(stopWatch));
    Console.ReadLine();
}
catch (Exception ex)
{

}

void InserirBulkCopy(List<RdcModel> models)
{
    using var copy = new OracleBulkCopy(cnnStr);
    copy.BulkCopyTimeout = 0;
    using var table = ToDataTable(models);

    copy.DestinationTableName = "\"RDC\"";
    copy.BatchSize = table.Rows.Count;

    copy.ColumnMappings.Add(ColumnName.SEQ_LINHA_ARQUIVO, ColumnName.SEQ_LINHA_ARQUIVO);
    copy.ColumnMappings.Add(ColumnName.COMPETENCIA, ColumnName.COMPETENCIA);
    copy.ColumnMappings.Add(ColumnName.UD_ORIGEM, ColumnName.UD_ORIGEM);
    copy.ColumnMappings.Add(ColumnName.INICIO_APURACAO, ColumnName.INICIO_APURACAO);
    copy.ColumnMappings.Add(ColumnName.FIM_APURACAO, ColumnName.FIM_APURACAO);
    copy.ColumnMappings.Add(ColumnName.COD_BENEFICIARIO, ColumnName.COD_BENEFICIARIO);
    copy.ColumnMappings.Add(ColumnName.DT_NASCIMENTO, ColumnName.DT_NASCIMENTO);
    copy.ColumnMappings.Add(ColumnName.DT_INCLUSAO, ColumnName.DT_INCLUSAO);
    copy.ColumnMappings.Add(ColumnName.DT_EXCLUSAO, ColumnName.DT_EXCLUSAO);
    copy.ColumnMappings.Add(ColumnName.CONTRATACAO, ColumnName.CONTRATACAO);
    copy.ColumnMappings.Add(ColumnName.SEGMENTACAO, ColumnName.SEGMENTACAO);
    copy.ColumnMappings.Add(ColumnName.ABRANGENCIA, ColumnName.ABRANGENCIA);
    copy.ColumnMappings.Add(ColumnName.ACOMODACAO, ColumnName.ACOMODACAO);
    copy.ColumnMappings.Add(ColumnName.NOME_PLANO, ColumnName.NOME_PLANO);
    copy.ColumnMappings.Add(ColumnName.REGISTRO_ANS, ColumnName.REGISTRO_ANS);
    copy.ColumnMappings.Add(ColumnName.COPART_AMB, ColumnName.COPART_AMB);
    copy.ColumnMappings.Add(ColumnName.COPART_INTER, ColumnName.COPART_INTER);
    copy.ColumnMappings.Add(ColumnName.COD_PROCED, ColumnName.COD_PROCED);
    copy.ColumnMappings.Add(ColumnName.GUIA, ColumnName.GUIA);
    copy.ColumnMappings.Add(ColumnName.DESC_PROCED, ColumnName.DESC_PROCED);
    copy.ColumnMappings.Add(ColumnName.QTD_PROCED, ColumnName.QTD_PROCED);
    copy.ColumnMappings.Add(ColumnName.CUSTO, ColumnName.CUSTO);
    copy.ColumnMappings.Add(ColumnName.RECUP_CUSTO, ColumnName.RECUP_CUSTO);
    copy.ColumnMappings.Add(ColumnName.DT_OCORRENCIA, ColumnName.DT_OCORRENCIA);
    copy.ColumnMappings.Add(ColumnName.DT_INTERNACAO, ColumnName.DT_INTERNACAO);
    copy.ColumnMappings.Add(ColumnName.DT_ALTA, ColumnName.DT_ALTA);
    copy.ColumnMappings.Add(ColumnName.COD_CID, ColumnName.COD_CID);
    copy.ColumnMappings.Add(ColumnName.DESC_CID, ColumnName.DESC_CID);
    copy.ColumnMappings.Add(ColumnName.TIPO_INTERNACAO, ColumnName.TIPO_INTERNACAO);
    copy.ColumnMappings.Add(ColumnName.PRESTADOR, ColumnName.PRESTADOR);
    copy.ColumnMappings.Add(ColumnName.NOME_BENEFICIARIO, ColumnName.NOME_BENEFICIARIO);
    copy.ColumnMappings.Add(ColumnName.SEXO, ColumnName.SEXO);
    copy.ColumnMappings.Add(ColumnName.MUNICIPIO_RESIDENCIA, ColumnName.MUNICIPIO_RESIDENCIA);
    copy.ColumnMappings.Add(ColumnName.UF_RESIDENCIA, ColumnName.UF_RESIDENCIA);
    copy.ColumnMappings.Add(ColumnName.UD_EXECUTORA, ColumnName.UD_EXECUTORA);
    copy.ColumnMappings.Add(ColumnName.ADMINISTRADORA_BENEF, ColumnName.ADMINISTRADORA_BENEF);
    copy.ColumnMappings.Add(ColumnName.CONTR_COMERCIALIZACAO, ColumnName.CONTR_COMERCIALIZACAO);
    copy.ColumnMappings.Add(ColumnName.COD_CONTRATO, ColumnName.COD_CONTRATO);
    copy.ColumnMappings.Add(ColumnName.DT_INCLUSAO_CONTRATO, ColumnName.DT_INCLUSAO_CONTRATO);
    copy.ColumnMappings.Add(ColumnName.DT_EXCLUSAO_CONTRATO, ColumnName.DT_EXCLUSAO_CONTRATO);
    copy.ColumnMappings.Add(ColumnName.CNPJ, ColumnName.CNPJ);
    copy.ColumnMappings.Add(ColumnName.NOME_EMPRESA, ColumnName.NOME_EMPRESA);
    copy.ColumnMappings.Add(ColumnName.MES_REAJUSTE, ColumnName.MES_REAJUSTE);
    copy.ColumnMappings.Add(ColumnName.EXCLUSIVO_EX_EMPREG, ColumnName.EXCLUSIVO_EX_EMPREG);
    copy.ColumnMappings.Add(ColumnName.TIPO_REAJUSTE, ColumnName.TIPO_REAJUSTE);
    copy.ColumnMappings.Add(ColumnName.REGULAMENTADO, ColumnName.REGULAMENTADO);
    copy.ColumnMappings.Add(ColumnName.MODALIDADE, ColumnName.MODALIDADE);
    copy.ColumnMappings.Add(ColumnName.RECEITA, ColumnName.RECEITA);
    copy.ColumnMappings.Add(ColumnName.TAXA_ADM_SERV, ColumnName.TAXA_ADM_SERV);
    copy.ColumnMappings.Add(ColumnName.CPF, ColumnName.CPF);
    copy.ColumnMappings.Add(ColumnName.VINCULO, ColumnName.VINCULO);
    copy.ColumnMappings.Add(ColumnName.PRESTADOR_SOLIC, ColumnName.PRESTADOR_SOLIC);
    copy.ColumnMappings.Add(ColumnName.ESPECIALIDADE_SOLIC, ColumnName.ESPECIALIDADE_SOLIC);
    copy.ColumnMappings.Add(ColumnName.PRESTADOR_EXEC_NOME, ColumnName.PRESTADOR_EXEC_NOME);
    copy.ColumnMappings.Add(ColumnName.ESPECIALIDADE_EXEC, ColumnName.ESPECIALIDADE_EXEC);
    copy.ColumnMappings.Add(ColumnName.VL_PAGTO_PRESTADOR, ColumnName.VL_PAGTO_PRESTADOR);
    copy.ColumnMappings.Add(ColumnName.GUIA_PRINCIPAL, ColumnName.GUIA_PRINCIPAL);
    copy.ColumnMappings.Add(ColumnName.VERSAO_TABELA, ColumnName.VERSAO_TABELA);
    copy.ColumnMappings.Add(ColumnName.PARTICIPACAO_EXEC, ColumnName.PARTICIPACAO_EXEC);
    copy.ColumnMappings.Add(ColumnName.INDICE_APLICADO, ColumnName.INDICE_APLICADO);
    copy.ColumnMappings.Add(ColumnName.ULTIMA_MENSALIDADE, ColumnName.ULTIMA_MENSALIDADE);
    copy.ColumnMappings.Add(ColumnName.GLOSA, ColumnName.GLOSA);
    copy.ColumnMappings.Add(ColumnName.PAGTO_COMPLEMENTAR, ColumnName.PAGTO_COMPLEMENTAR);
    copy.ColumnMappings.Add(ColumnName.UD_BASE, ColumnName.UD_BASE);
    copy.ColumnMappings.Add(ColumnName.REDE, ColumnName.REDE);
    copy.ColumnMappings.Add(ColumnName.FATURA, ColumnName.FATURA);
    copy.ColumnMappings.Add(ColumnName.VL_FAT_PTU_A500, ColumnName.VL_FAT_PTU_A500);
    copy.ColumnMappings.Add(ColumnName.TIPO_ITEM, ColumnName.TIPO_ITEM);
    copy.ColumnMappings.Add(ColumnName.DT_EXECUCAO, ColumnName.DT_EXECUCAO);
    copy.ColumnMappings.Add(ColumnName.TIPO_PRESTADOR, ColumnName.TIPO_PRESTADOR);
    copy.ColumnMappings.Add(ColumnName.DEMOSTRATIVO_PAGTO, ColumnName.DEMOSTRATIVO_PAGTO);
    copy.ColumnMappings.Add(ColumnName.LOCAL_ATEND, ColumnName.LOCAL_ATEND);
    copy.ColumnMappings.Add(ColumnName.COMPARTILHAMENTO, ColumnName.COMPARTILHAMENTO);
    copy.ColumnMappings.Add(ColumnName.TIPO_COMPARTILHAMENTO, ColumnName.TIPO_COMPARTILHAMENTO);
    copy.ColumnMappings.Add(ColumnName.REMIDO, ColumnName.REMIDO);
    copy.ColumnMappings.Add(ColumnName.SEQUENCIA_ITEM, ColumnName.SEQUENCIA_ITEM);
    copy.ColumnMappings.Add(ColumnName.CARATER_ATEND, ColumnName.CARATER_ATEND);
    copy.ColumnMappings.Add(ColumnName.TIPO_DIRECIONAMENTO, ColumnName.TIPO_DIRECIONAMENTO);
    copy.ColumnMappings.Add(ColumnName.FATOR_INTERNACAO_APTO_PAGTO, ColumnName.FATOR_INTERNACAO_APTO_PAGTO);
    copy.ColumnMappings.Add(ColumnName.FATOR_VIA_DE_ACESSO_PAGTO, ColumnName.FATOR_VIA_DE_ACESSO_PAGTO);
    copy.ColumnMappings.Add(ColumnName.FATOR_EMERGENCIA_PAGTO, ColumnName.FATOR_EMERGENCIA_PAGTO);
    copy.ColumnMappings.Add(ColumnName.TX_INTERCAMBIO_CUSTO, ColumnName.TX_INTERCAMBIO_CUSTO);
    copy.ColumnMappings.Add(ColumnName.MOTIVO_DA_ALTA, ColumnName.MOTIVO_DA_ALTA);
    copy.ColumnMappings.Add(ColumnName.FLG_AJIUS, ColumnName.FLG_AJIUS);
    copy.ColumnMappings.Add(ColumnName.LOCAL_ATEND_NOME, ColumnName.LOCAL_ATEND_NOME);
    copy.ColumnMappings.Add(ColumnName.LOCAL_ATEND_CIDADE, ColumnName.LOCAL_ATEND_CIDADE);
    copy.ColumnMappings.Add(ColumnName.PRESTADOR_SOLIC_NOME, ColumnName.PRESTADOR_SOLIC_NOME);
    copy.ColumnMappings.Add(ColumnName.PRESTADOR_EXEC_CIDADE, ColumnName.PRESTADOR_EXEC_CIDADE);
    copy.ColumnMappings.Add(ColumnName.COBERTURA_ADICIONAL, ColumnName.COBERTURA_ADICIONAL);
    copy.ColumnMappings.Add(ColumnName.GRUPO_ECONOMICO, ColumnName.GRUPO_ECONOMICO);
    copy.ColumnMappings.Add(ColumnName.TIPO_COPARTICIPACAO, ColumnName.TIPO_COPARTICIPACAO);
    copy.ColumnMappings.Add(ColumnName.COD_PLANTA, ColumnName.COD_PLANTA);
    copy.ColumnMappings.Add(ColumnName.EXPOSTO, ColumnName.EXPOSTO);

    try
    {
        copy.WriteToServer(table);
    }
    catch (Exception ex)
    {
        
    }
}

DataTable ToDataTable(List<RdcModel> models)
{
    var table = CreateTable<RdcModel>();

    foreach (var model in models)
    {
        var row = table.NewRow();

        row[ColumnName.SEQ_LINHA_ARQUIVO] = model.SEQ_LINHA_ARQUIVO;
        row[ColumnName.COMPETENCIA] = model.COMPETENCIA;
        row[ColumnName.UD_ORIGEM] = model.UNIMED_ORIGEM;
        row[ColumnName.INICIO_APURACAO] = model.INICIO_APURACAO;
        row[ColumnName.FIM_APURACAO] = model.FIM_APURACAO;
        row[ColumnName.COD_BENEFICIARIO] = model.CODIGO_BENEFICIARIO;
        row[ColumnName.DT_NASCIMENTO] = model.DATA_NASCIMENTO;
        row[ColumnName.DT_INCLUSAO] = model.DATA_INCLUSAO;
        row[ColumnName.DT_EXCLUSAO] = model.DATA_EXCLUSAO;
        row[ColumnName.CONTRATACAO] = model.CONTRATACAO;
        row[ColumnName.SEGMENTACAO] = model.SEGMENTACAO;
        row[ColumnName.ABRANGENCIA] = model.ABRANGENCIA;
        row[ColumnName.ACOMODACAO] = model.ACOMODACAO;
        row[ColumnName.NOME_PLANO] = model.NOME_PLANO;
        row[ColumnName.REGISTRO_ANS] = model.REGISTRO_ANS;
        row[ColumnName.COPART_AMB] = model.CO_PARTICIPACAO_AMB;
        row[ColumnName.COPART_INTER] = model.CO_PARTICIPACAO_INTER;
        row[ColumnName.COD_PROCED] = model.COD_PROCEDIMENTO;
        row[ColumnName.GUIA] = model.GUIA;
        row[ColumnName.DESC_PROCED] = model.DESC_PROCEDIMENTO;
        row[ColumnName.QTD_PROCED] = model.QTD_PROCED;
        row[ColumnName.CUSTO] = model.CUSTO;
        row[ColumnName.RECUP_CUSTO] = model.RECUP_CUSTO;
        row[ColumnName.DT_OCORRENCIA] = model.DATA_OCORRENCIA;
        row[ColumnName.DT_INTERNACAO] = model.DATA_INTERNACAO;
        row[ColumnName.DT_ALTA] = model.DATA_ALTA;
        row[ColumnName.COD_CID] = model.CODIGO_CID;
        row[ColumnName.DESC_CID] = model.DESC_CID;
        row[ColumnName.TIPO_INTERNACAO] = model.TIPO_INTERNACAO;
        row[ColumnName.PRESTADOR] = model.PRESTADOR;
        row[ColumnName.NOME_BENEFICIARIO] = model.NOME_BENEFICIARIO;
        row[ColumnName.SEXO] = model.SEXO;
        row[ColumnName.MUNICIPIO_RESIDENCIA] = model.MUNICIPIO_RESIDENCIA;
        row[ColumnName.UF_RESIDENCIA] = model.UF_RESIDENCIA;
        row[ColumnName.UD_EXECUTORA] = model.UD_EXECUTORA;
        row[ColumnName.ADMINISTRADORA_BENEF] = model.ADMINISTRADORA_BENEF;
        row[ColumnName.CONTR_COMERCIALIZACAO] = model.CONTR_COMERCIALIZACAO;
        row[ColumnName.COD_CONTRATO] = model.CODIGO_CONTRATO;
        row[ColumnName.DT_INCLUSAO_CONTRATO] = model.DATA_INCLUSAO_CONTRATO;
        row[ColumnName.DT_EXCLUSAO_CONTRATO] = model.DATA_EXCLUSAO_CONTRATO;
        row[ColumnName.CNPJ] = model.CNPJ;
        row[ColumnName.NOME_EMPRESA] = model.NOME_EMPRESA;
        row[ColumnName.MES_REAJUSTE] = model.MES_REAJUSTE;
        row[ColumnName.EXCLUSIVO_EX_EMPREG] = model.EXCLUSIVO_EX_EMPREG;
        row[ColumnName.TIPO_REAJUSTE] = model.TIPO_REAJUSTE;
        row[ColumnName.REGULAMENTADO] = model.REGULAMENTADO;
        row[ColumnName.MODALIDADE] = model.MODALIDADE;
        row[ColumnName.RECEITA] = model.RECEITA;
        row[ColumnName.TAXA_ADM_SERV] = model.TAXA_ADM_SERV;
        row[ColumnName.CPF] = model.CPF;
        row[ColumnName.VINCULO] = model.VINCULO;
        row[ColumnName.PRESTADOR_SOLIC] = model.PRESTADOR_SOLICITANTE;
        row[ColumnName.ESPECIALIDADE_SOLIC] = model.ESPECIALIDADE_SOLICITANTE;
        row[ColumnName.PRESTADOR_EXEC_NOME] = model.PRESTADOR_EXECUTANTE_NOME;
        row[ColumnName.ESPECIALIDADE_EXEC] = model.ESPECIALIDADE_EXECUTANTE;
        row[ColumnName.VL_PAGTO_PRESTADOR] = model.VALOR_PAGAMENTO_PRESTADOR;
        row[ColumnName.GUIA_PRINCIPAL] = model.GUIA_PRINCIPAL;
        row[ColumnName.VERSAO_TABELA] = model.VERSAO_TABELA;
        row[ColumnName.PARTICIPACAO_EXEC] = model.PARTICIPAÇÃO_EXECUTANTE;
        row[ColumnName.INDICE_APLICADO] = model.INDICE_APLICADO;
        row[ColumnName.ULTIMA_MENSALIDADE] = model.ULTIMA_MENSALIDADE;
        row[ColumnName.GLOSA] = model.GLOSA;
        row[ColumnName.PAGTO_COMPLEMENTAR] = model.PAGAMENTO_COMPLEMENTAR;
        row[ColumnName.UD_BASE] = model.UD_BASE;
        row[ColumnName.REDE] = model.REDE;
        row[ColumnName.FATURA] = model.FATURA;
        row[ColumnName.VL_FAT_PTU_A500] = model.VALOR_FAT_PTU_A500;
        row[ColumnName.TIPO_ITEM] = model.TIPO_ITEM;
        row[ColumnName.DT_EXECUCAO] = model.DATA_EXECUCAO;
        row[ColumnName.TIPO_PRESTADOR] = model.TIPO_PRESTADOR;
        row[ColumnName.DEMOSTRATIVO_PAGTO] = model.DEMOSTRATIVO_PAGTO;
        row[ColumnName.LOCAL_ATEND] = model.LOCAL_ATENDIMENTO;
        row[ColumnName.COMPARTILHAMENTO] = model.COMPARTILHAMENTO;
        row[ColumnName.TIPO_COMPARTILHAMENTO] = model.TIPO_COMPARTILHAMENTO;
        row[ColumnName.REMIDO] = model.REMIDO;
        row[ColumnName.SEQUENCIA_ITEM] = model.SEQUENCIA_ITEM;
        row[ColumnName.CARATER_ATEND] = model.CARATER_ATEND;
        row[ColumnName.TIPO_DIRECIONAMENTO] = model.TIPO_DIRECIONAMENTO;
        row[ColumnName.FATOR_INTERNACAO_APTO_PAGTO] = model.FATOR_INTERNACAO_APTO_PAGAMENTO;
        row[ColumnName.FATOR_VIA_DE_ACESSO_PAGTO] = model.FATOR_VIA_DE_ACESSO_PAGAMENTO;
        row[ColumnName.FATOR_EMERGENCIA_PAGTO] = model.FATOR_EMERGENCIA_PAGAMENTO;
        row[ColumnName.TX_INTERCAMBIO_CUSTO] = model.TAXA_DE_INTERCAMBIO_CUSTO;
        row[ColumnName.MOTIVO_DA_ALTA] = model.MOTIVO_DA_ALTA;
        row[ColumnName.FLG_AJIUS] = model.FLG_AJIUS;
        row[ColumnName.LOCAL_ATEND_NOME] = model.LOCAL_ATENDIMENTO_NOME;
        row[ColumnName.LOCAL_ATEND_CIDADE] = model.LOCAL_ATENDIMENTO_CIDADE;
        row[ColumnName.PRESTADOR_SOLIC_NOME] = model.PRESTADOR_SOLICITANTE_NOME;
        row[ColumnName.PRESTADOR_EXEC_CIDADE] = model.PRESTADOR_EXECUTANTE_CIDADE;
        row[ColumnName.COBERTURA_ADICIONAL] = model.COBERTURA_ADICIONAL;
        row[ColumnName.GRUPO_ECONOMICO] = model.GRUPO_ECONOMICO;
        row[ColumnName.TIPO_COPARTICIPACAO] = model.TIPO_COPARTICIPACAO;
        row[ColumnName.COD_PLANTA] = model.COD_PLANTA;
        row[ColumnName.EXPOSTO] = model.EXPOSTO;

        table.Rows.Add(row);
    }

    return table;
}

static DataTable CreateTable<T>()
{
    var table = new DataTable(typeof(RdcModel).Name);

    table.Columns.Add(ColumnName.SEQ_LINHA_ARQUIVO, typeof(int));
    table.Columns.Add(ColumnName.COMPETENCIA, typeof(string));
    table.Columns.Add(ColumnName.UD_ORIGEM, typeof(int));
    table.Columns.Add(ColumnName.INICIO_APURACAO, typeof(DateTime));
    table.Columns.Add(ColumnName.FIM_APURACAO, typeof(DateTime));
    table.Columns.Add(ColumnName.COD_BENEFICIARIO, typeof(string));
    table.Columns.Add(ColumnName.DT_NASCIMENTO, typeof(DateTime));
    table.Columns.Add(ColumnName.DT_INCLUSAO, typeof(DateTime));
    table.Columns.Add(ColumnName.DT_EXCLUSAO, typeof(DateTime));
    table.Columns.Add(ColumnName.CONTRATACAO, typeof(int));
    table.Columns.Add(ColumnName.SEGMENTACAO, typeof(int));
    table.Columns.Add(ColumnName.ABRANGENCIA, typeof(int));
    table.Columns.Add(ColumnName.ACOMODACAO, typeof(int));
    table.Columns.Add(ColumnName.NOME_PLANO, typeof(string));
    table.Columns.Add(ColumnName.REGISTRO_ANS, typeof(string));
    table.Columns.Add(ColumnName.COPART_AMB, typeof(int));
    table.Columns.Add(ColumnName.COPART_INTER, typeof(int));
    table.Columns.Add(ColumnName.COD_PROCED, typeof(long));
    table.Columns.Add(ColumnName.GUIA, typeof(string));
    table.Columns.Add(ColumnName.DESC_PROCED, typeof(string));
    table.Columns.Add(ColumnName.QTD_PROCED, typeof(long));
    table.Columns.Add(ColumnName.CUSTO, typeof(decimal));
    table.Columns.Add(ColumnName.RECUP_CUSTO, typeof(decimal));
    table.Columns.Add(ColumnName.DT_OCORRENCIA, typeof(DateTime));
    table.Columns.Add(ColumnName.DT_INTERNACAO, typeof(DateTime));
    table.Columns.Add(ColumnName.DT_ALTA, typeof(DateTime));
    table.Columns.Add(ColumnName.COD_CID, typeof(string));
    table.Columns.Add(ColumnName.DESC_CID, typeof(string));
    table.Columns.Add(ColumnName.TIPO_INTERNACAO, typeof(int));
    table.Columns.Add(ColumnName.PRESTADOR, typeof(string));
    table.Columns.Add(ColumnName.NOME_BENEFICIARIO, typeof(string));
    table.Columns.Add(ColumnName.SEXO, typeof(string));
    table.Columns.Add(ColumnName.MUNICIPIO_RESIDENCIA, typeof(string));
    table.Columns.Add(ColumnName.UF_RESIDENCIA, typeof(string));
    table.Columns.Add(ColumnName.UD_EXECUTORA, typeof(int));
    table.Columns.Add(ColumnName.ADMINISTRADORA_BENEF, typeof(string));
    table.Columns.Add(ColumnName.CONTR_COMERCIALIZACAO, typeof(string));
    table.Columns.Add(ColumnName.COD_CONTRATO, typeof(string));
    table.Columns.Add(ColumnName.DT_INCLUSAO_CONTRATO, typeof(DateTime));
    table.Columns.Add(ColumnName.DT_EXCLUSAO_CONTRATO, typeof(DateTime));
    table.Columns.Add(ColumnName.CNPJ, typeof(string));
    table.Columns.Add(ColumnName.NOME_EMPRESA, typeof(string));
    table.Columns.Add(ColumnName.MES_REAJUSTE, typeof(int));
    table.Columns.Add(ColumnName.EXCLUSIVO_EX_EMPREG, typeof(string));
    table.Columns.Add(ColumnName.TIPO_REAJUSTE, typeof(int));
    table.Columns.Add(ColumnName.REGULAMENTADO, typeof(string));
    table.Columns.Add(ColumnName.MODALIDADE, typeof(string));
    table.Columns.Add(ColumnName.RECEITA, typeof(decimal));
    table.Columns.Add(ColumnName.TAXA_ADM_SERV, typeof(string));
    table.Columns.Add(ColumnName.CPF, typeof(string));
    table.Columns.Add(ColumnName.VINCULO, typeof(int));
    table.Columns.Add(ColumnName.PRESTADOR_SOLIC, typeof(string));
    table.Columns.Add(ColumnName.ESPECIALIDADE_SOLIC, typeof(string));
    table.Columns.Add(ColumnName.PRESTADOR_EXEC_NOME, typeof(string));
    table.Columns.Add(ColumnName.ESPECIALIDADE_EXEC, typeof(string));
    table.Columns.Add(ColumnName.VL_PAGTO_PRESTADOR, typeof(string));
    table.Columns.Add(ColumnName.GUIA_PRINCIPAL, typeof(string));
    table.Columns.Add(ColumnName.VERSAO_TABELA, typeof(int));
    table.Columns.Add(ColumnName.PARTICIPACAO_EXEC, typeof(int));
    table.Columns.Add(ColumnName.INDICE_APLICADO, typeof(string));
    table.Columns.Add(ColumnName.ULTIMA_MENSALIDADE, typeof(decimal));
    table.Columns.Add(ColumnName.GLOSA, typeof(decimal));
    table.Columns.Add(ColumnName.PAGTO_COMPLEMENTAR, typeof(decimal));
    table.Columns.Add(ColumnName.UD_BASE, typeof(int));
    table.Columns.Add(ColumnName.REDE, typeof(string));
    table.Columns.Add(ColumnName.FATURA, typeof(string));
    table.Columns.Add(ColumnName.VL_FAT_PTU_A500, typeof(decimal));
    table.Columns.Add(ColumnName.TIPO_ITEM, typeof(int));
    table.Columns.Add(ColumnName.DT_EXECUCAO, typeof(DateTime));
    table.Columns.Add(ColumnName.TIPO_PRESTADOR, typeof(int));
    table.Columns.Add(ColumnName.DEMOSTRATIVO_PAGTO, typeof(string));
    table.Columns.Add(ColumnName.LOCAL_ATEND, typeof(string));
    table.Columns.Add(ColumnName.COMPARTILHAMENTO, typeof(string));
    table.Columns.Add(ColumnName.TIPO_COMPARTILHAMENTO, typeof(string));
    table.Columns.Add(ColumnName.REMIDO, typeof(string));
    table.Columns.Add(ColumnName.SEQUENCIA_ITEM, typeof(string));
    table.Columns.Add(ColumnName.CARATER_ATEND, typeof(string));
    table.Columns.Add(ColumnName.TIPO_DIRECIONAMENTO, typeof(int));
    table.Columns.Add(ColumnName.FATOR_INTERNACAO_APTO_PAGTO, typeof(int));
    table.Columns.Add(ColumnName.FATOR_VIA_DE_ACESSO_PAGTO, typeof(int));
    table.Columns.Add(ColumnName.FATOR_EMERGENCIA_PAGTO, typeof(int));
    table.Columns.Add(ColumnName.TX_INTERCAMBIO_CUSTO, typeof(decimal));
    table.Columns.Add(ColumnName.MOTIVO_DA_ALTA, typeof(int));
    table.Columns.Add(ColumnName.FLG_AJIUS, typeof(string));
    table.Columns.Add(ColumnName.LOCAL_ATEND_NOME, typeof(string));
    table.Columns.Add(ColumnName.LOCAL_ATEND_CIDADE, typeof(string));
    table.Columns.Add(ColumnName.PRESTADOR_SOLIC_NOME, typeof(string));
    table.Columns.Add(ColumnName.PRESTADOR_EXEC_CIDADE, typeof(string));
    table.Columns.Add(ColumnName.COBERTURA_ADICIONAL, typeof(string));
    table.Columns.Add(ColumnName.GRUPO_ECONOMICO, typeof(string));
    table.Columns.Add(ColumnName.TIPO_COPARTICIPACAO, typeof(string));
    table.Columns.Add(ColumnName.COD_PLANTA, typeof(string));
    table.Columns.Add(ColumnName.EXPOSTO, typeof(string));

    return table;
}

string ObterTempo(Stopwatch stopWatch)
{
    return TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds).ToString();
}

List<RdcModel> ReadLines()
{
    var models = new List<RdcModel>();

    using var reader = new StreamReader(arqBaseFilePath);

    var headers = reader.ReadLine()!.Split(";", StringSplitOptions.RemoveEmptyEntries);

    var lineNumber = 0;
    while (!reader.EndOfStream)
    {
        var fields = reader.ReadLine()!.Split(';');

        var model = new RdcModel();

        for (int i = 0; i < headers.Length; i++)
        {
            DataMapper.MapToModel(model, fields[i], headers[i]);
        }

        model.SEQ_LINHA_ARQUIVO = lineNumber;
        model.COMPETENCIA = model.INICIO_APURACAO.ToString("yyyyMM");
        model.UNIMED_ORIGEM = int.Parse(model.CODIGO_BENEFICIARIO[1..4]);

        models.Add(model);

        lineNumber++;

        if (lineNumber == 10000) break;
    }

    return models;
}

async Task InsertLines(List<RdcModel> models, Stopwatch stopWatch)
{
    await using var connection = new OracleConnection(cnnStr);
    connection.Open();

    var contador = 0;

    foreach (var chunk in models.Chunk(batchSize))
    {
        var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        foreach(var model in chunk)
        {
            var queryInsertInto = GenerateQuerynInsertInto();
            await BulkInsert(connection, transaction, model, queryInsertInto);

            if (++contador % 10000 == 0) 
                Console.WriteLine(contador + " inseridos! " + ObterTempo(stopWatch));
        }
            
        transaction.Commit();
    }
}

static string GenerateQuerynInsertInto()
{
    var builder = new StringBuilder();

    builder.Append("INSERT INTO \"TESTE\".RDC (");
    var totalColunas = ColumnName.Todos().Count();
    var columnCount = 0;
    foreach (var columnName in ColumnName.Todos())
    {
        builder.Append(columnName);
        if (++columnCount != totalColunas) builder.Append(',');
    }
    builder.Append(")");

    return builder.ToString();
}

static async Task BulkInsert(OracleConnection connection, OracleTransaction transaction, RdcModel model, string queryInsertInto)
{
    await using var command = connection.CreateCommand();

    command.Transaction = transaction;

    var query = GenerateQuery(1, queryInsertInto);

    command.CommandText = query;

    FillParameters(command, model);

    await command.ExecuteNonQueryAsync();

    command.Parameters.Clear();
}

static string GenerateQuery(int modelCount, string queryInsertInto)
{
    var builder = new StringBuilder();

    for (int modelIndex = 0; modelIndex < modelCount; modelIndex++)
    {
        builder.Append(queryInsertInto);
        builder.Append(" VALUES (");

        var columnTotal = ColumnName.Todos().Count();
        var columnIndex = 0;
        foreach (var column in ColumnName.Todos())
        {
            builder.Append(':');
            builder.Append(column);
            builder.Append(modelIndex);
            if (++columnIndex != columnTotal) builder.Append(',');
        }
        builder.Append(')');
    }

    return builder.ToString();
}

static void FillParameters(OracleCommand command, RdcModel model)
{
    command.Parameters.Clear();

    for (var i = 0; i < 1; i++)
    {
        command.Parameters.Add("ABRANGENCIA" + i, model.ABRANGENCIA);
        command.Parameters.Add("ACOMODACAO" + i, model.ACOMODACAO);
        command.Parameters.Add("ADMINISTRADORA_BENEF" + i, model.ADMINISTRADORA_BENEF);
        command.Parameters.Add("CARATER_ATEND" + i, model.CARATER_ATEND);
        command.Parameters.Add("CNPJ" + i, model.CNPJ);
        command.Parameters.Add("COBERTURA_ADICIONAL" + i, model.COBERTURA_ADICIONAL);
        command.Parameters.Add("COD_BENEFICIARIO" + i, model.CODIGO_BENEFICIARIO);
        command.Parameters.Add("COD_CID" + i, model.CODIGO_CID);
        command.Parameters.Add("COD_CONTRATO" + i, model.CODIGO_CONTRATO);
        command.Parameters.Add("COD_PLANTA" + i, model.COD_PLANTA);
        command.Parameters.Add("COD_PROCED" + i, model.COD_PROCEDIMENTO);
        command.Parameters.Add("COMPARTILHAMENTO" + i, model.COMPARTILHAMENTO);
        command.Parameters.Add("COMPETENCIA" + i, model.COMPETENCIA);
        command.Parameters.Add("CONTRATACAO" + i, model.CONTRATACAO);
        command.Parameters.Add("CONTR_COMERCIALIZACAO" + i, model.CONTR_COMERCIALIZACAO);
        command.Parameters.Add("COPART_AMB" + i, model.CO_PARTICIPACAO_AMB);
        command.Parameters.Add("COPART_INTER" + i, model.CO_PARTICIPACAO_INTER);
        command.Parameters.Add("CPF" + i, model.CPF);
        command.Parameters.Add("CUSTO" + i, model.CUSTO);
        command.Parameters.Add("DEMOSTRATIVO_PAGTO" + i, model.DEMOSTRATIVO_PAGTO);
        command.Parameters.Add("DESC_CID" + i, model.DESC_CID);
        command.Parameters.Add("DESC_PROCED" + i, model.DESC_PROCEDIMENTO);
        command.Parameters.Add("DT_ALTA" + i, model.DATA_ALTA);
        command.Parameters.Add("DT_EXCLUSAO" + i, model.DATA_EXCLUSAO);
        command.Parameters.Add("DT_EXCLUSAO_CONTRATO" + i, model.DATA_EXCLUSAO_CONTRATO);
        command.Parameters.Add("DT_EXECUCAO" + i, model.DATA_EXECUCAO);
        command.Parameters.Add("DT_INCLUSAO" + i, model.DATA_INCLUSAO);
        command.Parameters.Add("DT_INCLUSAO_CONTRATO" + i, model.DATA_INCLUSAO_CONTRATO);
        command.Parameters.Add("DT_INTERNACAO" + i, model.DATA_INTERNACAO);
        command.Parameters.Add("DT_NASCIMENTO" + i, model.DATA_NASCIMENTO);
        command.Parameters.Add("DT_OCORRENCIA" + i, model.DATA_OCORRENCIA);
        command.Parameters.Add("ESPECIALIDADE_EXEC" + i, model.ESPECIALIDADE_EXECUTANTE);
        command.Parameters.Add("ESPECIALIDADE_SOLIC" + i, model.ESPECIALIDADE_SOLICITANTE);
        command.Parameters.Add("EXCLUSIVO_EX_EMPREG" + i, model.EXCLUSIVO_EX_EMPREG);
        command.Parameters.Add("EXPOSTO" + i, model.EXPOSTO);
        command.Parameters.Add("FATOR_EMERGENCIA_PAGTO" + i, model.FATOR_EMERGENCIA_PAGAMENTO);
        command.Parameters.Add("FATOR_INTERNACAO_APTO_PAGTO" + i, model.FATOR_INTERNACAO_APTO_PAGAMENTO);
        command.Parameters.Add("FATOR_VIA_DE_ACESSO_PAGTO" + i, model.FATOR_VIA_DE_ACESSO_PAGAMENTO);
        command.Parameters.Add("FATURA" + i, model.FATURA);
        command.Parameters.Add("FIM_APURACAO" + i, model.FIM_APURACAO);
        command.Parameters.Add("FLG_AJIUS" + i, model.FLG_AJIUS);
        command.Parameters.Add("GLOSA" + i, model.GLOSA);
        command.Parameters.Add("GRUPO_ECONOMICO" + i, model.GRUPO_ECONOMICO);
        command.Parameters.Add("GUIA" + i, model.GUIA);
        command.Parameters.Add("GUIA_PRINCIPAL" + i, model.GUIA_PRINCIPAL);
        command.Parameters.Add("INDICE_APLICADO" + i, model.INDICE_APLICADO);
        command.Parameters.Add("INICIO_APURACAO" + i, model.INICIO_APURACAO);
        command.Parameters.Add("LOCAL_ATEND" + i, model.LOCAL_ATENDIMENTO);
        command.Parameters.Add("LOCAL_ATEND_CIDADE" + i, model.LOCAL_ATENDIMENTO_CIDADE);
        command.Parameters.Add("LOCAL_ATEND_NOME" + i, model.LOCAL_ATENDIMENTO_NOME);
        command.Parameters.Add("MES_REAJUSTE" + i, model.MES_REAJUSTE);
        command.Parameters.Add("MODALIDADE" + i, model.MODALIDADE);
        command.Parameters.Add("MOTIVO_DA_ALTA" + i, model.MOTIVO_DA_ALTA);
        command.Parameters.Add("MUNICIPIO_RESIDENCIA" + i, model.MUNICIPIO_RESIDENCIA);
        command.Parameters.Add("NOME_BENEFICIARIO" + i, model.NOME_BENEFICIARIO);
        command.Parameters.Add("NOME_EMPRESA" + i, model.NOME_EMPRESA);
        command.Parameters.Add("NOME_PLANO" + i, model.NOME_PLANO);
        command.Parameters.Add("PAGTO_COMPLEMENTAR" + i, model.PAGAMENTO_COMPLEMENTAR);
        command.Parameters.Add("PARTICIPACAO_EXEC" + i, model.PARTICIPAÇÃO_EXECUTANTE);
        command.Parameters.Add("PRESTADOR" + i, model.PRESTADOR);
        command.Parameters.Add("PRESTADOR_EXEC_CIDADE" + i, model.PRESTADOR_EXECUTANTE_CIDADE);
        command.Parameters.Add("PRESTADOR_EXEC_NOME" + i, model.PRESTADOR_EXECUTANTE_NOME);
        command.Parameters.Add("PRESTADOR_SOLIC" + i, model.PRESTADOR_SOLICITANTE);
        command.Parameters.Add("PRESTADOR_SOLIC_NOME" + i, model.PRESTADOR_SOLICITANTE_NOME);
        command.Parameters.Add("QTD_PROCED" + i, model.QTD_PROCED);
        command.Parameters.Add("RECEITA" + i, model.RECEITA);
        command.Parameters.Add("RECUP_CUSTO" + i, model.RECUP_CUSTO);
        command.Parameters.Add("REDE" + i, model.REDE);
        command.Parameters.Add("REGISTRO_ANS" + i, model.REGISTRO_ANS);
        command.Parameters.Add("REGULAMENTADO" + i, model.REGULAMENTADO);
        command.Parameters.Add("REMIDO" + i, model.REMIDO);
        command.Parameters.Add("SEGMENTACAO" + i, model.SEGMENTACAO);
        command.Parameters.Add("SEQUENCIA_ITEM" + i, model.SEQUENCIA_ITEM);
        command.Parameters.Add("SEQ_LINHA_ARQUIVO" + i, model.SEQ_LINHA_ARQUIVO);
        command.Parameters.Add("SEXO" + i, model.SEXO);
        command.Parameters.Add("TAXA_ADM_SERV" + i, model.TAXA_ADM_SERV);
        command.Parameters.Add("TIPO_COMPARTILHAMENTO" + i, model.TIPO_COMPARTILHAMENTO);
        command.Parameters.Add("TIPO_COPARTICIPACAO" + i, model.TIPO_COPARTICIPACAO);
        command.Parameters.Add("TIPO_DIRECIONAMENTO" + i, model.TIPO_DIRECIONAMENTO);
        command.Parameters.Add("TIPO_INTERNACAO" + i, model.TIPO_INTERNACAO);
        command.Parameters.Add("TIPO_ITEM" + i, model.TIPO_ITEM);
        command.Parameters.Add("TIPO_PRESTADOR" + i, model.TIPO_PRESTADOR);
        command.Parameters.Add("TIPO_REAJUSTE" + i, model.TIPO_REAJUSTE);
        command.Parameters.Add("TX_INTERCAMBIO_CUSTO" + i, model.TAXA_DE_INTERCAMBIO_CUSTO);
        command.Parameters.Add("UD_BASE" + i, model.UD_BASE);
        command.Parameters.Add("UD_EXECUTORA" + i, model.UD_EXECUTORA);
        command.Parameters.Add("UD_ORIGEM" + i, null);
        command.Parameters.Add("UF_RESIDENCIA" + i, model.UF_RESIDENCIA);
        command.Parameters.Add("ULTIMA_MENSALIDADE" + i, model.ULTIMA_MENSALIDADE);
        command.Parameters.Add("VERSAO_TABELA" + i, model.VERSAO_TABELA);
        command.Parameters.Add("VINCULO" + i, model.VINCULO);
        command.Parameters.Add("VL_FAT_PTU_A500" + i, model.VALOR_FAT_PTU_A500);
        command.Parameters.Add("VL_PAGTO_PRESTADOR" + i, model.VALOR_PAGAMENTO_PRESTADOR);
    }
}