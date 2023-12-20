namespace ReadyToRunRepro;

public abstract class DataElementBase
{
    private protected DataElementBase(IdentifierBase id)
    {
        this.Id = id;
    }

    public virtual IdentifierBase Id { get; }
}

public abstract class DataElementBase<TIdentifier> : DataElementBase
    where TIdentifier : DataElementIdentifierBase
{
    private protected DataElementBase(
        TIdentifier id)
        : base(id)
    {
    }
    
    public override TIdentifier Id => (TIdentifier) base.Id;
}

public sealed class EventDefinition : DataElementBase<EventDefinitionIdentifier>
{
    internal EventDefinition(EventDefinitionIdentifier id)
        : base(id)
    {
    }
}

public abstract class EventDefinitionBase : DataElementBase<EventDefinitionIdentifier>
{
    private protected EventDefinitionBase(
        NodeIdentifier nodeId,
        EventSettingsBase settings,
        Type? argumentType = null)
        : base(
            new EventDefinitionIdentifier(nodeId))
    {
    }

    protected internal abstract EventSettingsBase Settings { get; }
}

public abstract class EventDefinitionBase<TSettings> : EventDefinitionBase
    where TSettings : EventSettingsBase
{
    private protected EventDefinitionBase(
        NodeIdentifier nodeId,
        TSettings settings,
        Type? argumentType = null)
        : base(nodeId, settings, argumentType)
    {
        this.Settings = settings;
    }

    protected internal override TSettings Settings { get; }
}

public abstract class IdentifierBase
{
}

public sealed class NodeIdentifier : IdentifierBase, IEquatable<NodeIdentifier>
{
    public bool Equals(NodeIdentifier? other)
    {
        return true;
    }
}

public abstract class OwnedIdentifierBase<TOwner> : IdentifierBase, IEquatable<OwnedIdentifierBase<TOwner>>
    where TOwner : IdentifierBase
{
    public OwnedIdentifierBase(TOwner owner)
    {
        this.Owner = owner;
    }

    public TOwner Owner { get; }

    public bool Equals(OwnedIdentifierBase<TOwner>? other)
    {
        return true;
    }
}

public abstract class DataElementIdentifierBase : OwnedIdentifierBase<NodeIdentifier>
{
    protected DataElementIdentifierBase(NodeIdentifier owner)
        : base(owner)
    {
    }
}

public abstract record DataElementSettingsBase
{
    private protected DataElementSettingsBase()
    {
    }
}

public sealed class EventDefinitionIdentifier : DataElementIdentifierBase
{
    public EventDefinitionIdentifier(NodeIdentifier owner)
        : base(owner)
    {
    }
}

public abstract record EventSettingsBase : DataElementSettingsBase;

public record EventSettings : EventSettingsBase;