namespace Viren.Core.Dtos
{
    public interface IProjectModelVersionRevision : IProjectModelVersion
    {
        int? Revision { get; set; }
    }
}