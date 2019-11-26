using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        var classType = Type.GetType(className);
        var classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        var classInstance = Activator.CreateInstance(classType, new object[] { });
        var sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in classFields.Where(f => fieldNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
    
    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);

        var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        var classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        
        foreach (var method in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);

        var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);

        var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        var sb = new StringBuilder();

        foreach (var method in classMethods.Where(m=>m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
