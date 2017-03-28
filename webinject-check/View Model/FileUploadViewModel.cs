using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webinject_check.Models
{
    public class FileUploadViewModel
    {
        public IFormFile fileUpload { get; set; }
    }
}