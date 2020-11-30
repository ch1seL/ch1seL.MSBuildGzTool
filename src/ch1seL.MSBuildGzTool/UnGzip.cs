using System.IO;
using System.IO.Compression;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ch1seL.MSBuildGzTool
{
    public class UnGzip : Task
    {
        public override bool Execute()
        {
            using var fInStream = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
            using var zipStream = new GZipStream(fInStream, CompressionMode.Decompress);
            using var fOutStream = new FileStream(DestinationFile, FileMode.Create, FileAccess.Write);
            var tempBytes = new byte[4096];
            int i;
            while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0) fOutStream.Write(tempBytes, 0, i);
            return true;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        [Required]
        public string SourceFile { get; set; }
        [Required]
        // ReSharper disable once MemberCanBePrivate.Global
        public string DestinationFile { get; set; }
    }
}