using System;
using System.Collections.Generic;

namespace Viren.Execution.Dtos.Documentation
{
    public class BlockDocumentationOptionalInfoDto
    {
        public IDictionary<string, bool> BooleanInfo { get; set; }

        public IDictionary<string, decimal> DecimalInfo { get; set; }

        public IDictionary<string, string> StringInfo { get; set; }

        public IDictionary<string, DateTime> DateTimeInfo { get; set; }

        public BlockDocumentationOptionalInfoDto(
            IDictionary<string, bool> booleanInfo = null,
            IDictionary<string, decimal> decimalInfo = null,
            IDictionary<string, string> stringInfo = null,
            IDictionary<string, DateTime> dateTimeInfo = null)
        {
            BooleanInfo = booleanInfo ?? new Dictionary<string, bool>();
            DecimalInfo = decimalInfo ?? new Dictionary<string, decimal>();
            StringInfo = stringInfo ?? new Dictionary<string, string>();
            DateTimeInfo = dateTimeInfo ?? new Dictionary<string, DateTime>();
        }

        public BlockDocumentationOptionalInfoDto()
        {
        }
    }
}