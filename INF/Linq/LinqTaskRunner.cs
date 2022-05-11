using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Linq
{
    public class LinqTaskRunner
    {
        /// <summary>
        /// Товар 
        /// </summary>
        private class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Product(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        /// <summary>
        /// Сделка
        /// </summary>
        private class Deal
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public double Price { get; set; }
            public int Count { get; set; }
        }
        public void Run()
        {
            //Создать перечень продуктов из 10 товаров
            var listProduct = new List<Product>()
            {
                new Product (1,"Яблоко"),
                new Product (2,"Банан"),
                new Product (3,"Картошка"),
                new Product (4,"Сахар"),
                new Product (5,"Соль"),
                new Product (6,"Макароны"),
                new Product (7,"Гречка"),
                new Product (8,"Негр"),
                new Product (9,"Сок"),
                new Product (10,"Молоко")
            };
            //Создать перечень сделок 20 шт
            var listDeal = new List<Deal>()
            {
                new Deal(){Id=1,ProductId=1,Price=30,Count=10},
                new Deal(){Id=2,ProductId=2,Price=50,Count=10},
                new Deal(){Id=3,ProductId=3,Price=70,Count=10},
                new Deal(){Id=4,ProductId=4,Price=90,Count=10},
                new Deal(){Id=5,ProductId=5,Price=104,Count=10},
                new Deal(){Id=6,ProductId=6,Price=105,Count=10},
                new Deal(){Id=7,ProductId=7,Price=106,Count=10},
                new Deal(){Id=8,ProductId=8,Price=107,Count=10},
                new Deal(){Id=9,ProductId=9,Price=108,Count=10},
                new Deal(){Id=10,ProductId=10,Price=109,Count=10},
                new Deal(){Id=11,ProductId=11,Price=110,Count=10},
                new Deal(){Id=12,ProductId=12,Price=111,Count=10},
                new Deal(){Id=13,ProductId=13,Price=112,Count=10},
                new Deal(){Id=14,ProductId=14,Price=113,Count=10},
                new Deal(){Id=15,ProductId=15,Price=114,Count=10},
                new Deal(){Id=16,ProductId=16,Price=115,Count=10},
                new Deal(){Id=17,ProductId=17,Price=116,Count=10},
                new Deal(){Id=18,ProductId=18,Price=117,Count=10},
                new Deal(){Id=19,ProductId=19,Price=118,Count=10},
                new Deal(){Id=20,ProductId=20,Price=119,Count=10},
            };
            //Выбрать все сделки, которые были дороже 50
            var answer1 = listDeal.Where(x => (x.Price * x.Count) > 50).ToList();
            Console.WriteLine(answer1);
            //Вывести первые 10 сделок, отсортированных по коду товара и цене
            var answer2 = listDeal.OrderBy(x => x.ProductId).ThenBy(x => x.Price).Take(10);
            Console.WriteLine(answer2);
            //Вывести первые 3 сделки, цена которых между 30 и 70
            var answer3 = listDeal
                .Where(x =>
                {
                    var price = x.Price * x.Count;
                    return price > 29 && price < 71;
                })
                .Take(3)
                .ToList();
            Console.WriteLine(answer3);
            //Создать второй список сделок 10 шт
            var listDeal2 = new List<Deal>()
            {
                new Deal(){Id=1,ProductId=1,Price=100,Count=10},
                new Deal(){Id=2,ProductId=2,Price=101,Count=10},
                new Deal(){Id=3,ProductId=3,Price=102,Count=10},
                new Deal(){Id=4,ProductId=4,Price=103,Count=10},
                new Deal(){Id=5,ProductId=5,Price=104,Count=10},
                new Deal(){Id=6,ProductId=6,Price=105,Count=10},
                new Deal(){Id=7,ProductId=7,Price=106,Count=10},
                new Deal(){Id=8,ProductId=8,Price=107,Count=10},
                new Deal(){Id=9,ProductId=9,Price=108,Count=10},
                new Deal(){Id=10,ProductId=10,Price=109,Count=10},
            };
            //Найти пересечение продуктов из двух списков сделок
            var res1 = listDeal
                .Select(x => x.ProductId)
                .Distinct()
                .Intersect(listDeal2.Select(x => x.ProductId).Distinct());
            //разницу
            var res2 = listDeal
                .Select(x => x.ProductId)
                .Distinct()
                .Except(listDeal2.Select(x => x.ProductId).Distinct());
            //объединение
            var res3 = listDeal
                .Select(x => x.ProductId)
                .Distinct()
                .Union(listDeal2.Select(x => x.ProductId).Distinct());
            //Вывести самую дорогую сделку
            var res4 = listDeal
                .Max(x => (x.Price * x.Count));//Можно без Select;
            //Вывести среднюю стоимость сделки
            var res5 = listDeal
                .Select(x => (x.Price * x.Count))
                .Average();//Также можно без Select
            //Посчитать количество сделок с суммой 50
            var res6 = listDeal.Select(x => (x.Price * x.Count) == 50).Count();
            //Сгруппировать сделки по продуктам и вывести
            var res7 = listDeal
                .GroupBy(x => x.ProductId);
            //код продукта, количество сделок, среднюю стоимость
            var res8 = listDeal
                .GroupBy(x => x.ProductId)
                .Select(x => new
                {
                    x.Key,
                    DealCount = x.Count(),
                    AveragePrice = x.Average(y => y.Price * y.Count)
                });
            //Вывести сделки, соединив со справочником продуктов:
            //Наименование продукта, цена
            var res9 = listProduct.Join(listDeal,
                prod => prod.Id,
                deal => deal.ProductId,
                (prod, deal) => new { prod.Name, deal.Price });
            //Проверить наличие продукта с кодом 4
            var res10 = listProduct.Any(x => x.Id == 4);
            //Проверить, все ли сделки дороже 20
            var res11 = listDeal.All(x => x.Count * x.Price > 20);
        }
    }
}
