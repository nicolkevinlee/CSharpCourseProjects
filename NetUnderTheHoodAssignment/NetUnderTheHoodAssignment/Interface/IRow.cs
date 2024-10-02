

namespace CsvDataAccess.Interface;

public interface IRow
{
    object GetAtColumn(string columnIndex);
}
