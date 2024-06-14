using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Domain.Entities;

namespace Ordering.Application.Services;
public interface IProductService
{
    public Task<Product?> GetProductByIdAsync(string productId);
}
