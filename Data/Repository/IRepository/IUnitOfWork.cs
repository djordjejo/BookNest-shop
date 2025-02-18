﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; }
        public IProductRepository productRepository { get; }
        public ICompanyRepository companyRepository { get; }
        public IShoppingCardRepository shoppingCardRepository { get; }
        public IOrderDetailRepository orderDetailRepository { get; }
        public IOrderHeaderRepository headerRepository  { get; }
        public IUserRepository userRepository  { get; }
        public void Save();

    }
}
