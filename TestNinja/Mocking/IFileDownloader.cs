﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
       void DownloadFile(string url, string path);
    }
}
