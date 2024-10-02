using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class NewRow : IRow
{
    private Dictionary<string, bool> _boolsData;
    private Dictionary<string, int> _intsData;
    private Dictionary<string, decimal> _decimalsData;
    private Dictionary<string, string> _stringsData;

    public void AssignCell(string columnName, bool value)
    {
        if (_boolsData is null) _boolsData = new();
        _boolsData[columnName] = value;
    }

    public void AssignCell(string columnName, int value)
    {
        if (_intsData is null) _intsData = new();
        _intsData[columnName] = value;
    }

    public void AssignCell(string columnName, decimal value)
    {
        if (_decimalsData is null) _decimalsData = new();
        _decimalsData[columnName] = value;
    }

    public void AssignCell(string columnName, string value)
    {
        if (_stringsData is null) _stringsData = new();
        _stringsData[columnName] = value;
    }

    public object GetAtColumn(string columnIndex)
    {
        if (_boolsData is not null && _boolsData.ContainsKey(columnIndex)) return _boolsData[columnIndex];
        if (_intsData is not null && _intsData.ContainsKey(columnIndex)) return _intsData[columnIndex];
        if (_decimalsData is not null && _decimalsData.ContainsKey(columnIndex)) return _decimalsData[columnIndex];
        if (_stringsData is not null && _stringsData.ContainsKey(columnIndex)) return _stringsData[columnIndex];
        return null;
    }

}
