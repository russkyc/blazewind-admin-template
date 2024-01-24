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

using Bogus;
using Russkyc.Blazewind.Admin.Shared.Models;

namespace Russkyc.Blazewind.Admin.Server.Data.Repos;

public class ProductRepo
{
    private List<Product> _products = new();

    public ProductRepo()
    {
        _products = new Faker<Product>()
            .RuleFor(product => product.Id, faker => faker.IndexFaker)
            .RuleFor(product => product.Image, faker => faker.Image.LoremFlickrUrl(80,80))
            .RuleFor(product => product.Name, faker => faker.Commerce.ProductName())
            .RuleFor(product => product.Type, faker => faker.Commerce.ProductMaterial())
            .RuleFor(product => product.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(product => product.Category, faker => faker.Commerce.Categories(1).First())
            .RuleFor(product => product.Stock, faker => faker.Random.Int(1, 50))
            .RuleFor(product => product.Created, faker => faker.Date.Between(DateTime.Now.AddYears(-2),DateTime.Now))
            .RuleFor(product => product.Updated, faker => faker.Date.Between(DateTime.Now.AddYears(-2),DateTime.Now))
            .Generate(250);
    }

    public bool Delete(int id)
    {
        var product = _products.FirstOrDefault(product => product.Id == id);
        if (product is null) return false;
        return _products.Remove(product);
    }

    public int CountAll()
    {
        return _products.Count;
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
}