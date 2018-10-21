using System;
using System.Collections.Generic;

namespace streamany.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileAsByte { get; set; }
        public string FileExtension { get; set; }
        public string FileContentType { get; set; }
    }
}
