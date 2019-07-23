namespace Viren.Execution.Requests
{
    internal static class RoutePrefix
    { 
        public const string Api = "/v1";
        public const string Client = Api + "/client";
        public const string Project = Api + "/projects";
        public const string Calculation = Api + "/calculation";
        public const string Calculations = Api + "/calculations";
        public const string InteractiveRun = Api + "/interactiverun";
        public const string InteractiveModelData = InteractiveRun + "/modeldata";



        public const string ApiV2 = "/v2";
        public const string CalculationsV2 = ApiV2 + "/calculations";
    }
}