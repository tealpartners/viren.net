using System.Runtime.CompilerServices;
using Viren.Core.Dtos;

namespace Viren.Core.Helpers
{
    public static class UrlBuilder
    {
        public static string BuildUrl(IProject request)
        {
            return request.Project;
        }

        public static string BuildUrl(IProjectModel request)
        {
            return BuildUrl((IProject) request) + "/" + request.Model;
        }

        public static string BuildUrl(IProjectModelVersion request)
        {
            return BuildUrl((IProjectModel) request) + "/" + request.Version;
        }

        public static string BuildUrl(IProjectModelVersionRevision request)
        {
            return BuildUrl((IProjectModelVersion) request) + "/" + (request.Revision.HasValue ? request.Revision.Value.ToString() : "null");
        }
    }
}