﻿using OpenFiddle.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using OpenFiddle.Helpers;
using OpenFiddle.Resources;

namespace OpenFiddle.Controllers
{
     public class ConsoleController : ApiController
    {
        private DBContext db = new DBContext();

        public RoleManager<IdentityRole> RoleManager { get; private set; }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        public Models.ConsoleOutput Run(Models.ConsoleInput input)
        {
            var co = new Models.ConsoleOutput();
            co.Code = input.Code;
            co.Output =  CompileHelper.CompileAndRun(input.Code);
            return co;
        }

        [HttpGet]
        public string Code(Guid? id = null)
        {
            if (id.HasValue)
            {
                throw new NotImplementedException();
            }
            else
            {
                return CodeSamples.HelloWorldConsole;
            }
        }
         
        [HttpPost]
        public bool Compile(Models.ConsoleInput input)
        {
            throw new NotImplementedException();
        }
    }
}
