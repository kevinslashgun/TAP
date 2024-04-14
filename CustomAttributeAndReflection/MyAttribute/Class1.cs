namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)] // ExecuteMe can be used only on methods and can be used multiple time on the same method
    public class ExecuteMeAttribute : Attribute
    {
        public object[] Parameters { get; } // ExecuteMe can have any type and number of parameters

        public ExecuteMeAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }
    }

    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true)]
    public class BuildMeAttribute : Attribute
    {
        public object[] Parameters { get; }

        public BuildMeAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }
    }
}
