﻿namespace CrudProject.Dto.Requests;

public class ProductUpdateRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}