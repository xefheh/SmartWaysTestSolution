using System.Reflection;

namespace SmartWaysTestSolution.Persistence.Infrastructure.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(MemberInfo type, object value) :
        base($"{type.Name} with key {value} not found!") { }
}