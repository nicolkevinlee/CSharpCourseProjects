using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class TableData : ITableData
{
    private readonly List<IRow> _rows;
    public int RowCount => _rows.Count;
    public IEnumerable<string> Columns { get; }

    public TableData(IEnumerable<string> columns, List<IRow> rows)
    {
        _rows = rows;
        Columns = columns;
    }

    public object GetValue(string columnName, int rowIndex)
    {
        return _rows[rowIndex].GetAtColumn(columnName);

    }
}
