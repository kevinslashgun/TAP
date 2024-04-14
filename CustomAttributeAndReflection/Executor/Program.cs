using MyAttribute;
using System.Reflection;

namespace Executor
{
    public class Program
    {
        public static void Main()
        {
            // Load the assembly from MyLibrary.dll
            //var assembly = Assembly.LoadFrom("MyLibrary.dll"); // Using the project reference
            var assembly = Assembly.LoadFrom("../../../../MyLibrary/bin/Debug/net7.0/MyLibrary.dll"); // Using the relative path of the .dll file
            foreach (var type in assembly.GetTypes()) // Now I get all the types inside the file MyLibrary.dll
            {
                if (type.IsClass && !type.IsSubclassOf(typeof(Attribute))) // Need the second condition because GetTypes() returns also Attribute classes
                {
                    var methods = type.GetMethods(); // Get methods of that class
                    Console.WriteLine(type.FullName);
                    foreach (var method in methods) // Now I want to call all those methods with their tagged custom attributes
                    {
                        object[] attributes = method.GetCustomAttributes(typeof(ExecuteMeAttribute), false); // Get the custom attributes of type ExecuteMeAttribute
                        if (attributes.Length > 0)  // Check if there is at least one ExecuteMeAttribute
                        {
                            foreach (ExecuteMeAttribute attribute in attributes.Cast<ExecuteMeAttribute>())
                            {
                                //Use the Activator class to create the object, invoke the methods passin ad argument parameters of ExecuteMeAttribute
                                try
                                {
                                    method.Invoke(Activator.CreateInstance(type), attribute.Parameters);
                                }
                                catch (TargetParameterCountException ex)
                                {
                                    Console.WriteLine($"[Exception in method: {method.Name}] [Message: {ex.Message}]");
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine($"[Exception in method: {method.Name}] [Message: {ex.Message}]");
                                }
                                catch (MissingMethodException ex)
                                {
                                    Console.WriteLine($"[Exception in class: {type.FullName}] [Message: {ex.Message}]");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}