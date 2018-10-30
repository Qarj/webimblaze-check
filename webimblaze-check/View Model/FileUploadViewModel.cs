using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webimblaze_check.Models
{
    public class FileUploadViewModel
    {
        public IFormFile fileUpload { get; set; }
    }
}