﻿using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Services;

public interface IImageService
{
    void DeleteImage(Product product);

    Task<Product> SaveImageAsync(IFormFile image, Product product, CancellationToken cancellationToken);
}