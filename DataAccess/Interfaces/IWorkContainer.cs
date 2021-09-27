﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IWorkContainer : IDisposable
    {
        ICustomerRepository Customer { get; }

        void Save();
    }
}
