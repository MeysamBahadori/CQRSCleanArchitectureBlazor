namespace Mc2.CrudTest.Domain.BusinessRule;

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