using System;
using System.Collections.Generic;
using Viren.Core.Enums;

namespace Viren.Execution.Dtos.Documentation
{
    public class TypeDocumentationDto
    {
        public string Name { get; set; }

        public TypeKind TypeKind { get; set; }

        //simple
        public SystemType SystemType { get; set; }
        public string Formatting { get; set; }
        public string Label { get; set; }

        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }
        public decimal? MinDecimal { get; set; }
        public decimal? MaxDecimal { get; set; }
        public IDictionary<string, string> PossibleStringValues { get; set; }

        public IDictionary<string, bool> OptionalBooleanInfo { get; set; }
        public IDictionary<string, decimal> OptionalDecimalInfo { get; set; }
        public IDictionary<string, string> OptionalStringInfo { get; set; }
        public IDictionary<string, DateTime> OptionalDateTimeInfo { get; set; }


        //table
        public string TableTypeComplexTypeName { get; set; }


        //complex
        public List<VirenComplexTypePropertyDto> Properties { get; set; }
    }


    public class VirenComplexTypePropertyDto
    {
        public string Name { get; set; }

        public string VirenTypeName { get; set; }
    }
}