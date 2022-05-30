using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.KR2_2sem_
{
    public class Linq1
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Price
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public decimal Sum { get; set; }
            public bool IsActual { get; set; }
        }
        public class ProductCount
        {
            public Product product { get; set; }
            public int count { get; set; }
        }
        public class ProductCountPrice
        {
            public ProductCount product { get; set; }
            public Price price { get; set; }
            public void Show()
            {
                Console.WriteLine(product.product.Name + "\t" + product.count + "\t" + price.Sum);
            }
        }
        public class Check
        {
            public List<ProductCountPrice> List_Product_Count_Price { get; set; }
            public void Show(List<Action> actions)
            {
                Console.WriteLine("Наименование\tКоличество\tЦена");
                foreach (var c in List_Product_Count_Price)
                {
                    c.Show();
                }
                Console.WriteLine("Итого: {0}", Total());
                Console.WriteLine("Итого со скидкой: {0}", TotalWithDiscount(actions));
            }
            public IEnumerable<decimal> PricesOfProduct(Product product)
            {
                return (from p in List_Product_Count_Price where p.product.product.Id == product.Id select p.price.Sum);
            }
            public decimal Total()
            {
                return (from p in List_Product_Count_Price select p.price.Sum * p.product.count).Sum();
            }
            public decimal TotalWithDiscount(List<Action> actions)
            {
                return Total() - (from p in actions where p.Consist(this) select p.sum_dicount(this)).Sum();
            }
        }

        public class Action
        {
            public List<ProductCount> product_count;
            public decimal discount;
            public bool Consist(Check check)
            {
                bool exist = false;
                foreach (var q in product_count)
                {
                    foreach (var p in check.List_Product_Count_Price)
                    {

                        if (q.product.Id == p.product.product.Id)
                        {
                            exist = true;
                            if (q.count > p.product.count)
                                return false;
                        }
                    }
                    if (!exist) return false;
                }
                return exist;
            }
            public decimal sum_dicount(Check check)
            {
                decimal sum = 0;
                foreach (var q in product_count)
                    foreach (var p in check.List_Product_Count_Price)
                    {
                        if (q.product.Id == p.product.product.Id)
                            sum += (p.price.Sum * p.product.count) * discount / 100;
                    }
                return sum;
            }
        }
        public void Run()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Аквариум 10 литров" },
                new Product { Id = 2, Name = "Аквариум 20 литров" },
                new Product { Id = 3, Name = "Аквариум 50 литров" },
                new Product { Id = 4, Name = "Аквариум 100 литров" },
                new Product { Id = 5, Name = "Аквариум 200 литров" },
                new Product { Id = 6, Name = "Фильтр" },
                new Product { Id = 7, Name = "Термометр" }
            };

            var prices = new List<Price>
            {
                new Price { Id = 1, ProductId = 1, Sum = 100, IsActual = false },
                new Price { Id = 2, ProductId = 1, Sum = 123, IsActual = true },
                new Price { Id = 3, ProductId = 2, Sum = 234, IsActual = true },
                new Price { Id = 4, ProductId = 3, Sum = 532, IsActual = true },
                new Price { Id = 5, ProductId = 4, Sum = 234, IsActual = true },
                new Price { Id = 6, ProductId = 5, Sum = 534, IsActual = true },
                new Price { Id = 7, ProductId = 5, Sum = 124, IsActual = false },
                new Price { Id = 8, ProductId = 6, Sum = 153, IsActual = true },
                new Price { Id = 9, ProductId = 7, Sum = 157, IsActual = true }
            };
            var checkes = new List<Check>
            {
                new Check{
                   List_Product_Count_Price=new List<ProductCountPrice>{new ProductCountPrice {product=new ProductCount{product=products[4], count=1},price=prices[5]},
                   new ProductCountPrice {product=new ProductCount{product=products[5], count=2},price=prices[6]},
                   new ProductCountPrice {product=new ProductCount{product=products[6], count=1},price=prices[7]}

                   }
                  },
                new Check{
                   List_Product_Count_Price=new List<ProductCountPrice>{new ProductCountPrice {product=new ProductCount{product=products[3], count=1},price=prices[4]},
                   new ProductCountPrice {product=new ProductCount{product=products[5], count=1},price=prices[6]}

                   }
                  }
            };


            var actions = new List<Action>
            {
                new Action{product_count=new List<ProductCount>{ new ProductCount {product=products[4],count=1 }, new ProductCount { product = products[5], count = 2 } },discount=15 },
                new Action{product_count=new List<ProductCount>{ new ProductCount {product=products[3],count=1 }, new ProductCount { product = products[5], count = 2 } },discount=10 },
                new Action{product_count=new List<ProductCount>{ new ProductCount {product=products[0],count=1 }, new ProductCount { product = products[5], count = 1 } },discount=5 },
                new Action{product_count=new List<ProductCount>{ new ProductCount {product=products[1],count=1 }, new ProductCount { product = products[5], count = 1 } },discount=5 },
                new Action{product_count=new List<ProductCount>{ new ProductCount {product=products[2],count=1 }, new ProductCount { product = products[5], count = 1 } },discount=5 },
            };


            foreach (var c in checkes)
            {
                c.Show(actions);
            }
            foreach (var pr in products)
            {
                var Sum = (from p in checkes select p.PricesOfProduct(pr).Sum()).Sum();
                var Count = (from p in checkes select p.PricesOfProduct(pr).Count()).Sum();
                if (Count != 0)
                {
                    var avg = Sum / Count;
                    Console.WriteLine("Среднаяя цена {0}: {1}", pr.Name, avg);
                }
            }

            Console.ReadKey();
        }
    }
}
