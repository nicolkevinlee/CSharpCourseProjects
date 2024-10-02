

using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;
public class Row : IRow
{
    private Dictionary<string, object> _data;

    public Row(Dictionary<string, object> data)
    {
        _data = data;
    }

    public object GetAtColumn(string columnIndex)
    {
        return (_data.ContainsKey(columnIndex)) ? _data[columnIndex] : null;
    }

}
