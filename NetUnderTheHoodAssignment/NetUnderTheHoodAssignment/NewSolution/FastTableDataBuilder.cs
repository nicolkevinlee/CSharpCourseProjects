using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.NewSolution;
using System.Data.Common;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<IRow>();

        foreach (var row in csvData.Rows)
        {
            //var newRowData = new Dictionary<string, object>();
            //
            //for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            //{
            //    var column = csvData.Columns[columnIndex];
            //    string valueAsString = row[columnIndex];
            //    object value = ConvertValueToTargetType(valueAsString);
            //    if(value != null) newRowData[column] = value;
            //}
            //
            //resultRows.Add(new Row(newRowData));

            var newRowData = new NewRow();

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                if (valueAsString == "TRUE")
                {
                    newRowData.AssignCell(column, true);
                    continue;
                }
                if (valueAsString == "FALSE")
                {
                    newRowData.AssignCell(column, false);
                    continue;
                }
                if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    newRowData.AssignCell(column, valueAsDecimal);
                    continue;
                }
                if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    newRowData.AssignCell(column, valueAsInt);
                    continue;
                }
                newRowData.AssignCell(column, valueAsString);
            }

            resultRows.Add(newRowData);
        }

        return new TableData(csvData.Columns, resultRows);
    }

    private object ConvertValueToTargetType(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value == "TRUE")
        {
            return true;
        }
        if (value == "FALSE")
        {
            return false;
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            return valueAsDecimal;
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            return valueAsInt;
        }
        return value;
    }

    private void AssignValueToRowCell(string value, NewRow row, string columnName)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }
        if (value == "TRUE")
        {
            row.AssignCell(columnName, true);
        }
        if (value == "FALSE")
        {
            row.AssignCell(columnName, false);
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            row.AssignCell(columnName, valueAsDecimal);
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            row.AssignCell(columnName, valueAsInt);
        }
        else
        {
            row.AssignCell(columnName, value);
        }
    }
}
