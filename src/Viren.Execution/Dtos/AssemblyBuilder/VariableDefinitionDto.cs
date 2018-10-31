namespace Viren.Execution.Dtos.AssemblyBuilder
{
    public class VariableDefinitionDto
    {
        public string Name { get; set; }
        public string ResultName { get; set; }
        public string TypeName { get; set; }

        public static string CleanVariableName(string variable)
        {
            return variable.Trim('[', ']', '\t', ' ');
        }
    }
}