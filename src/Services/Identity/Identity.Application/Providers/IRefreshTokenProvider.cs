﻿using Identity.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Abstractions.Interfaces;
public interface IRefreshTokenProvider
{
    TokenResult Genereate();
}
