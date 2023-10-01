using OnlineShop.Models.Enums;

namespace OnlineShop.Models;

public class SortViewModel
{
    public SortState NameSort { get; }
    public SortState AgeSort { get; }
    public SortState ProductSort { get; }
    public SortState Current { get; }

    public SortViewModel(SortState sortOrder)
    {
        NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
        AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
        ProductSort = sortOrder == SortState.ProductAsc ? SortState.ProductDesc : SortState.ProductAsc;
        Current = sortOrder;
    }
}