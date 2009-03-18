﻿using System.Collections.Generic;
using System.IO;
using Docu.Documentation;

namespace Docu.Generation
{
    public class BulkPageWriter : IBulkPageWriter
    {
        private readonly IPageWriter writer;

        public BulkPageWriter(IPageWriter writer)
        {
            this.writer = writer;
        }

        public void CreatePagesFromDirectory(string templatePath, string destination, IList<AssemblyDoc> assemblies)
        {
            writer.SetTemplatePath(templatePath);

            foreach (string file in Directory.GetFiles(templatePath, "*.spark", SearchOption.AllDirectories))
            {
                if (IsPartial(file)) continue;

                writer.CreatePages(file, destination, assemblies);
            }
        }

        private bool IsPartial(string file)
        {
            return Path.GetFileName(file).StartsWith("_");
        }
    }
}