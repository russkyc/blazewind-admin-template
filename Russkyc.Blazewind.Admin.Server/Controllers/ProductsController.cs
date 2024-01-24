// MIT License
// 
// Copyright (c) 2024 Russell Camo (Russkyc)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Microsoft.AspNetCore.Mvc;
using Russkyc.Blazewind.Admin.Server.Data.Repos;
using Russkyc.Blazewind.Admin.Shared.Models;

namespace Russkyc.Blazewind.Admin.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly ProductRepo _productRepo;

    public ProductsController(ProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    [HttpGet("all")]
    public IEnumerable<Product> GetProducts()
    {
        return _productRepo.GetAll();
    }
    
    [HttpGet("count-all")]
    public int GetProductsCount()
    {
        return _productRepo.CountAll();
    }

    [HttpDelete("delete-product/{id:int}")]
    public bool Delete([FromRoute] int id)
    {
        return _productRepo.Delete(id);
    }

    [HttpPut("create")]
    public void Create([FromBody] Product product)
    {
        _productRepo.Create(product);
    }

    [HttpGet("categories")]
    public IEnumerable<string> GetProductCategories()
    {
        return _productRepo.GetAll().Select(product => product.Category).Distinct(StringComparer.InvariantCultureIgnoreCase);
    }
}