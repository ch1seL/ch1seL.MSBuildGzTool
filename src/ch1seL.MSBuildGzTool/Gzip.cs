using System.IO;
using System.IO.Compression;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ch1seL.MSBuildGzTool
{
    public class Gzip : Task
    {
        public override bool Execute()
        {
            using var fStream = new FileStream(SourceFile,
                FileMode.Create, FileAccess.Write);
            using var zipStream = new GZipStream(fStream,
                CompressionMode.Compress);
            var inputFile = File.ReadAllBytes(DestinationFile);
            zipStream.Write(inputFile, 0, inputFile.Length);

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