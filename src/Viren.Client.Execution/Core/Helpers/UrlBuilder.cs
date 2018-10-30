using Viren.Client.Execution.Core.Dtos;

namespace Viren.Client.Execution.Core.Helpers
{
    internal static class UrlBuilder
    {
        internal static string BuildUrl(IProject request)
        {
            return request.Project;
        }

        internal static string BuildUrl(IProjectModel request)
        {
            return BuildUrl((IProject) request) + "/" + request.Model;
        }

        internal static string BuildUrl(IProjectModelVersion request)
        {
            return BuildUrl((IProjectModel) request) + "/" + request.Version;
        }

        internal static string BuildUrl(IProjectModelVersionRevision request)
        {
            return BuildUrl((IProjectModelVersion) request) + "/" + (request.Revision.HasValue ? request.Revision.Value.ToString() : "null");
        }
    }
}