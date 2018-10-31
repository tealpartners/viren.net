namespace Viren.Execution.Requests
{
    internal static class RoutePrefix
    {
        public const string Api = "/v1";
        public const string Project = Api + "/projects";
        public const string Calculation = Api + "/calculation";
        public const string InteractiveRun = Api + "/interactiverun";
        public const string InteractiveModelData = InteractiveRun + "/modeldata";
    }
}