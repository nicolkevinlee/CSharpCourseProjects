namespace QuoteFinder.Model;

public record Pagination(
    int currentPage,
    int nextPage,
    int totalPages
);