﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.DeleteRoleUseCase
{
    public class DeleteRole : IRequest
    {
        public string RoleId { get; set; }
    }
}