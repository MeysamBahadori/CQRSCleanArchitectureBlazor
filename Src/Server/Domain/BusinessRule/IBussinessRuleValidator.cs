namespace Mc2.CrudTest.Domain.BusinessRule;

public interface IBussinessRuleValidator
{
    bool IsValid();
    string InvalidMessage { get; }
}