namespace Viren.Client.Execution.Core.Dtos
{
    internal interface IProjectModelVersion: IProjectModel
    {
        int Version { get; set; }
    }
}
