﻿using FreshShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
