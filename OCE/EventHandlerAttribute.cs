using System;

namespace OCE
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EventHandlerAttribute : Attribute
    {
        public EventPriority Priority { get; }

        public EventHandlerAttribute(EventPriority priority)
        {

            Priority = priority;

        }

    }
}