﻿using SharedModel.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IUserService
    {
        public Task<string> Authentication(UserLoginRequest request);
    }
}