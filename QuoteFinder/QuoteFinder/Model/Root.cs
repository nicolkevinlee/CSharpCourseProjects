

namespace QuoteFinder.Model;

public record Root(
    List<Datum> data
);

/*
public record Root(
    int statusCode,
    string message,
    Pagination pagination,
    int totalQuotes,
    IReadOnlyList<Datum> data
);
*/