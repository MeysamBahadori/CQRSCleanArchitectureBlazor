using Mc2.CrudTest.Common.Behaviours;
using Mc2.CrudTest.Common.Exceptions;

namespace Mc2.CrudTest.Domain.Entities;

public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid>
{
    protected static void CheckRule(IBussinessRuleValidator rule)
    {
        if (!rule.IsValid())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}