using BulkInsertOracle;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;
using System.Text;

Console.WriteLine("Starting...");

const string cnnStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=SYSTEM;Password=senhaS3creta;";

var basePath = @"C:\src\BulkInsertOracle\BulkInsertOracle\Inputs";
var arqBaseFileName = "ARQ_BASE_RDC28_025_202112.txt";
var arqBaseFilePath = Path.Combine(basePath!, arqBaseFileName);
var batchSize = 10;

try
{
    await ReadAndInsert();
}
catch (Exception ex)
{

}

async Task ReadAndInsert()
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    var modelsBuffer = new List<RdcModel>(batchSize);
    for (int i = 0; i < batchSize; i++) modelsBuffer.Add(new());

    var queryInsertInto = GenerateQuerynInsertInto(batchSize);

    await using var connection = new OracleConnection(cnnStr);
    connection.Open();

    using var reader = new StreamReader(arqBaseFilePath);

    var headers = reader.ReadLine()!.Split(";", StringSplitOptions.RemoveEmptyEntries);

    var lineNumber = 0;
    var bufferIndex = 0;
    while (!reader.EndOfStream)
    {
        var fields = reader.ReadLine()!.Split(';');

        var model = modelsBuffer[bufferIndex];

        for (int i = 0; i < headers.Length; i++)
        {
            DataMapper.MapToModel(model, fields[i], headers[i]);
        }

        model.SEQ_LINHA_ARQUIVO = lineNumber;
        model.COMPETENCIA = model.INICIO_APURACAO?.ToString("yyyyMM");
        model.UNIMED_ORIGEM = int.Parse(model.CODIGO_BENEFICIARIO[1..4]);

        bufferIndex++;
        lineNumber++;

        if (bufferIndex == batchSize)
        {
            await BulkInsert(connection, modelsBuffer, queryInsertInto, batchSize);

            bufferIndex = 0;
        }
        if (lineNumber % 1000 == 0) Console.WriteLine(lineNumber + " inseridos!" + TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds).ToString());
    }

    stopWatch.Stop();

    Console.WriteLine(TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds).ToString());
}

Console.ReadLine();

static string GenerateQuerynInsertInto(int batchSize)
{
    var builder = new StringBuilder();

    builder.Append("INTO \"C##teste\".RDC (");
    var totalColunas = ColumnName.Todos().Count();
    var columnCount = 0;
    foreach (var columnName in ColumnName.Todos())
    {
        builder.Append(columnName);
        if(++columnCount != totalColunas) builder.Append(',');
    }
    builder.Append(")");

    return builder.ToString();
}

static async Task BulkInsert(OracleConnection connection, List<RdcModel> modelsBuffer, string queryInsertInto, int batchSize)
{
    await using var command = connection.CreateCommand();

    var query = GenerateQuery(modelsBuffer.Count, modelsBuffer, queryInsertInto);

    command.CommandText = query;

    FillParameters(command, modelsBuffer);

    await command.ExecuteNonQueryAsync();

    command.Parameters.Clear();
}

static string GenerateQuery(int batchSize, List<RdcModel> modelsBuffer, string queryInsertInto)
{
    var builder = new StringBuilder();

    builder.AppendLine("INSERT ALL");

    var modelIndex = 0;
    foreach(var model in modelsBuffer)
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
        modelIndex++;
    }

    builder.AppendLine("SELECT 1 FROM DUAL");

    return builder.ToString();
}


static void FillParameters(OracleCommand command, List<RdcModel> models)
{
    command.Parameters.Clear();

    for (var i = 0; i < models.Count; i++)
    {
        var model = models[i];
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