﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.Services
{
    public class BaseService
    {
        protected HttpClient Client { get; private set; } = App.client;


        public BaseService()
        {
             
        }

    }
}
