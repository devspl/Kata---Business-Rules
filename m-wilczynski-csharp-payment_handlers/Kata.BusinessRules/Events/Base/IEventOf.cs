namespace Kata.BusinessRules.Events 
{
    public interface IEventOf<TSource> : IEvent where TSource : EventSource
    {
        TSource Source { get; }
    }
}
