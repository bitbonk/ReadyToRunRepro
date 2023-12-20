namespace ReadyToRunRepro;

public class Service : IService
{
    // Make sure the type from the type hierarchy is actually used (deleting this line will make the error go away)
    private readonly NestedDictionary<NodeIdentifier, EventDefinitionIdentifier, EventDefinitionBase> dict = new();
}

public interface IService
{
}

public class NestedDictionary<TPrimaryKey, TSecondaryKey, TValue>
    where TPrimaryKey : notnull
    where TSecondaryKey : notnull
{
}