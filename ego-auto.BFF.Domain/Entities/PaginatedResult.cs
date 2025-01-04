﻿namespace ego_auto.BFF.Domain.Entities;

public class PaginatedResult<T>
{
    public int TotalCount { get; set; }
    public List<T> Items { get; set; }
}
