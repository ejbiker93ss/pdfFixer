using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace pdfFixer
{
    public enum ScanFileType
    {
        PDF,
        JPG
    }

    public class ScanDocument
    {
        public byte[] Contents { get; set; }
        public ScanFileType FileType { get; set; }
        public string FileName { get; set; }
    }

    
}
