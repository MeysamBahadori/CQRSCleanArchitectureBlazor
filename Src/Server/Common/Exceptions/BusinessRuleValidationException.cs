using Mc2.CrudTest.Common.Behaviours;

namespace Mc2.CrudTest.Common.Exceptions;

public class BusinessRuleValidationException : Exception
{
    public IBussinessRuleValidator Rule { get; }

    public string Details { get; }

    public BusinessRuleValidationException(IBussinessRuleValidator rule) : base(rule.InvalidMessage)
    {
        Rule = rule;
        Details = rule.InvalidMessage;
    }

    public override string ToString()
    {
        return $"{Rule.GetType().FullName}: {Rule.InvalidMessage}";
    }
}