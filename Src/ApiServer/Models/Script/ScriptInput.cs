﻿using OpenFiddle.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenFiddle.Models.Script
{
    public class ScriptInput
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Input is Required.")]
        public string Code { get; set; }
        public Language Language { get; set; }
    }
}