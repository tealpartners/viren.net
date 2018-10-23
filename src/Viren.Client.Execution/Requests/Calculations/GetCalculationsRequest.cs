using System;
using System.Collections.Generic;
using Viren.Client.Execution.Core.Dtos;

namespace Viren.Client.Execution.Requests.Calculations
{
    public class GetCalculationsRequest
    {
        public string Id { get; set; }
        public Guid? ImportId { get; set; }
        public Guid? ConversationId { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int? Version { get; set; }
        public int? Revision { get; set; }

        public int Page { get; set; }
        public int? PageSize { get; set; }

        public bool? IsValid { get; set; }
        public bool? HasWarning { get; set; }
        public bool? HasError { get; set; }
        public bool SortDescending { get; set; }
    }

    public class GetCalculationsResponse
    {
        public Calculation[] Calculations { get; set; }

        public int Page { get; set; }
        public int LastPage { get; set; }
        public long Total { get; set; }
    }

    public class Calculation
    {
        public string Id { get; set; }
        public Guid? ConversationId { get; set; }
        public Guid? ImportId { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public DateTime ExecutionBegin { get; set; }
        public DateTime ExecutionEnd { get; set; }

        public IDictionary<string, object> Result { get; set; }
        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }

        public bool IsValid { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
    }
}