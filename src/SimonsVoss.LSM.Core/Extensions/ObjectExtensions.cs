using System.Reflection;
using System.Runtime.CompilerServices;

namespace SimonsVoss.LSM.Core.Extensions;

public static class ObjectExtensions
{
    public static T ToType<T>(this object obj, [CallerArgumentExpression("obj")] string objName = null)
    {
        //create instance of T type object:
        object result = Activator.CreateInstance(typeof(T)!)!;

        //loop through the properties of the object you want to covert:          
        foreach (PropertyInfo pi in obj.GetType().GetProperties())
        {
            try
            {
                //get the value of property and try to assign it to the property of T type object:
                result.GetType().GetProperty(pi.Name)!.SetValue(result, pi.GetValue(obj, null), null);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"Properties of the {objName} do not match properties of the {typeof(T).Name}", innerException: ex);
            }
        }

        //return the T type object:         
        return (T)result;
    }
}