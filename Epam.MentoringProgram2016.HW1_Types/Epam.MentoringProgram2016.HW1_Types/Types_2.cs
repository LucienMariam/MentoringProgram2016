﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MentoringProgram2016.HW1_Types
{
    // Вам необходимо  описать структуру, которая представляет собой товар в интернет-магазине.Товар имеет наименование, цену и количество едениц на складе.
    // В дальнейшем вы будете работать со списком товара и осуществлять различные выборки с помощью LINQ to Object.
    // Спроектируйте и опишите структуру правильно с точки зрения реализации ValueType.

    public struct Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public bool Equals(Product obj)
        {
            return Id == obj.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                Product temp = (Product)obj;
                return temp.Equals(this);
            }

            else return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Id, Id).GetHashCode();
        }
    }
}
