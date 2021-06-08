﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace Shop.Model
{
    class Product
    {
        Market _market;
        private int _count = 1;
        public double Price { get; set; }
        public int Count { get; set; }
        public int ShowcaseId { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime DaliteTime { get; set; }
        private List<Product> _products;
        public Product(Market market) 
        {
            _market = market;
            _products = _market.GetProducts();

        }
        public Product(string name, int capacity)
        {
           
            ID = _count;
            Name = name;
            Capacity = capacity;
            CreateTime = DateTime.Now;
            DaliteTime = DateTime.MinValue;
        }
        public Product FindProduct(int id)
        {
            Product thisproduct = this;
            foreach (var item in _products )
            {
                if (item.ID == id)
                {
                    thisproduct = item;
                    return thisproduct;
                }
            }
            return thisproduct;
        }

        public void Print()
        {
            foreach (var x in _products)
            {
                if (x.ShowcaseId == 0)
                {
                    Console.WriteLine(x.ID + ")" + "Title:" + x.Name + " Capacity:" + x.Capacity);
                }
            }
        }

        public void CheckId(int id)
        {
            if (id > _count-1)
            {
                Console.WriteLine("Такого ID не существует,введите другой ID");
                id = Validate();
                CheckId(id);
            }
        }

        private int Validate()
        {
            var input = Console.ReadLine();
            var num = 0;
            var x = int.TryParse(input, out num);
            while (!int.TryParse(input, out num))
            {
                Console.Write("Введите целое число больше нуля:");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public void Create(string name,int capacity)
        {
            _count++;
            Product product = new Product(name, capacity);
            _products.Add(product);
        }

        public void EditName(int id,string name)
        {
            var thisproduct = FindProduct(id);
            thisproduct.Name = name;
        }

        public void EditCapacity(int id,int capacity)
        {
            var thisproduct = FindProduct(id);
            thisproduct.Capacity = capacity;
        }

        public void Remove(int id)
        {
            var product = FindProduct(id);
            _products.Remove(product);
           product.DaliteTime = DateTime.Now;
           _count--;
        }
    }
}

     
