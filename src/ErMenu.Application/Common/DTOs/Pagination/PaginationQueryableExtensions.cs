using Microsoft.EntityFrameworkCore;


namespace ErMenu.Application.Common.Models.Pagination;


public static class PaginationQueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int? pageNumber, int? pageSize, CancellationToken cancellationToken = default)
        where T : class
    {
        if (source == null)
        {
            throw new Exception("Empty");
        }
        int _pageNumber = pageNumber ?? 0;
        int _pageSize = pageSize ?? 0;

        _pageNumber = _pageNumber == 0 ? 1 : _pageNumber;
        _pageSize = _pageSize == 0 ? 10 : _pageSize;
        int count = await source.AsNoTracking().CountAsync();
        if (count == 0) return PaginatedResult<T>.Success([], count, _pageNumber, _pageSize);
        _pageNumber = _pageNumber <= 0 ? 1 : _pageNumber;
        var items = await source.Skip((_pageNumber! - 1) * _pageSize).Take(_pageSize).ToListAsync(cancellationToken);
        return PaginatedResult<T>.Success(items, count, _pageNumber, _pageSize);
    }
}