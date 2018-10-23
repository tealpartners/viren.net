namespace Viren.Client.Execution.Dtos
{
    public class ModelVersionDto
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }
    }
}