namespace Viren.Client.Execution.Core.Dtos
{
    internal interface IProjectModelVersionRevision: IProjectModelVersion
    {
        int? Revision { get; set; }
    }
}
