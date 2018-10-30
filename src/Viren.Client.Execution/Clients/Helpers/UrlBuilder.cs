using Viren.Client.Execution.Core.Dtos;

namespace Viren.Client.Execution.Clients.Helpers
{
    static class UrlBuilder
    {
        internal static string BuildUrl(IProject request) => request.Project;
        internal static string BuildUrl(IProjectModel request) => BuildUrl((IProject) request) + "/" + request.Model;
        internal static string BuildUrl(IProjectModelVersion request) => BuildUrl((IProjectModel) request) + "/" + request.Version;
        internal static string BuildUrl(IProjectModelVersionRevision request) => BuildUrl((IProjectModelVersion) request) + "/" + (request.Revision.HasValue ? request.Revision.Value.ToString() : "null");
    }
}