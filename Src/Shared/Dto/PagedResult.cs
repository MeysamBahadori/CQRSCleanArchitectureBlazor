namespace Mc2.CrudTest.Shared.Dto;

public class PagedResult<T>
{
    public IList<T> Items { get; set; }

    public int TotalCount { get; set; }

    public PagedResult(IList<T> items, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }

}