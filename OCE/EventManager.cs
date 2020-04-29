using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OCE
{
    
    
    public static class EventManager
    {

        private static readonly  Dictionary<Type, Dictionary<EventPriority, Dictionary<Listener, MethodInfo>>> EventList = 
            new Dictionary<Type, Dictionary<EventPriority, Dictionary<Listener, MethodInfo>>>();

        public static void initTest()
        {
            
            registerEvent(typeof(TestEvent));
            registerEventHandlers(new TestHandler(), typeof(TestEvent));
            
        }

        public static void registerEvent(Type type)
        {
           
            EventList.TryAdd(type, new Dictionary<EventPriority, Dictionary<Listener, MethodInfo>>());
            
        }

        public static void registerEventHandlers(Listener listener, Type eventType)
        {

            var methods = listener.GetType().GetMethods();

            foreach (var m in methods)
            {
                if (m.GetCustomAttribute(typeof(EventHandlerAttribute), false) == null) continue;
                var attribute = (EventHandlerAttribute) m.GetCustomAttribute(typeof(EventHandlerAttribute), false);
                if (!EventList[eventType].ContainsKey(attribute.Priority))
                {
                    EventList[eventType].TryAdd(attribute.Priority, new Dictionary<Listener, MethodInfo>());
                }

                EventList[eventType][attribute.Priority].Add(listener, m);
            }

        }

        public static void callEvent(Event @event)
        {
            
            var priorityDictionary = EventList[@event.GetType()];
            var priorityList = Array.ConvertAll(priorityDictionary.Keys.ToArray(), value => (int) value);
            Array.Sort(priorityList);
            Array.Reverse(priorityList);

            foreach (var i in priorityList)
            {

                foreach (var keyValuePair in priorityDictionary[(EventPriority) i])
                {
                    if (@event.isCancelled() == true) return;
                    keyValuePair.Value.Invoke(keyValuePair.Key, new object[]{@event});

                }
                
            }

        }
        
    }
}