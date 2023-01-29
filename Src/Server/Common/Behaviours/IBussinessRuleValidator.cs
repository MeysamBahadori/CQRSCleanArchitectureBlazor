namespace Mc2.CrudTest.Common.Behaviours;

public interface IBussinessRuleValidator
{
    bool IsValid();
    string InvalidMessage { get; }
}