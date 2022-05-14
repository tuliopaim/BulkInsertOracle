using BulkInsertOracle;
using Oracle.ManagedDataAccess.Client;
using System.Text;

const string cnnStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=TESTE;Password=senhaS3creta;";

var basePath = @"C:\dev\BulkInsertOracle\BulkInsertOracle\Inputs";
var arqBaseFileName = "ARQ_BASE_RDC28_025_202112.txt";
var arqBaseFilePath = Path.Combine(basePath!, arqBaseFileName);
var batchSize = 100;

var modelsBuffer = new List<RdcModel>(batchSize);

await using var connection = new OracleConnection(cnnStr);
connection.Open();

using var reader = new StreamReader(arqBaseFilePath);

var headers = reader.ReadLine()!.Split(";", StringSplitOptions.RemoveEmptyEntries);

var lineNumber = 0;
var bufferIndex = 0;
while (!reader.EndOfStream)
{
    var fields = reader.ReadLine()!.Split(';');
    var model = new RdcModel();

    for (int i = 0; i < headers.Length; i++)
    {
        DataMapper.MapToModel(model, fields[i], headers[i]);
    }
    
    model.SEQ_LINHA_ARQUIVO = lineNumber;
    model.COMPETENCIA = model.INICIO_APURACAO?.ToString("yyyyMM");
    model.UNIMED_ORIGEM = int.Parse(model.CODIGO_BENEFICIARIO[..3]);

    modelsBuffer[bufferIndex] = model;
    
    bufferIndex++;
    lineNumber++;

    if(bufferIndex == batchSize)
    {
        await BulkInsert(connection, modelsBuffer, batchSize);
    }
}


Console.ReadLine();


async Task BulkInsert(OracleConnection connection, List<RdcModel> modelsBuffer, List<string> headers, int batchSize)
{
    try
    {
        var query = GenerateQuery(batchSize, headers);

        foreach (var chunk in modelsBuffer.Chunk(batchSize))
        {
            await using var command = connection.CreateCommand();

            if (chunk.Length < batchSize) query = GenerateQuery(chunk.Length, headers);

            command.CommandText = query;

            FillParameters(command, chunk);

            await command.ExecuteNonQueryAsync();

            command.Parameters.Clear();
        }
    }
    catch (Exception ex)
    {
    }
    finally
    {
        connection.Dispose();
    }
}

static string GenerateQuery(int batchSize, List<string> headers)
{
    var builder = new StringBuilder();

    builder.AppendLine("INSERT ALL");

    for (var i = 0; i < batchSize; i++)
    {
        builder.Append("INTO \"RDC\" (\"" + headers[0] + "\"");
        for (int h = 1; h < headers.Count; h++)
        {
            var columnName = DataMapper.MapToTable(headers[0]);

            builder.Append(", \"" + columnName + "\"");
        }
        builder.Append(")");

        builder.Append("VALUES (:" + headers[0]);

        for (int h = 0; h < headers.Count; h++)
        {
            var columnName = DataMapper.MapToTable(headers[0]);

            builder.Append(", \"" + columnName + "\"");
        }

        builder.Append(i);
        builder.Append(", :companyId");
        builder.Append(i);
        builder.Append(", :sku");
        builder.Append(i);
        builder.Append(", :projection");
        builder.Append(i);
        builder.Append(", :suggestion");
        builder.Append(i);
        builder.Append(", :day");
        builder.Append(i);
        builder.Append(", :analysis_day");
        builder.Append(i);
        builder.Append(", :created_at");
        builder.Append(i);
        builder.Append(")\n");
    }

    builder.AppendLine("SELECT 1 FROM DUAL");

    return builder.ToString();
}