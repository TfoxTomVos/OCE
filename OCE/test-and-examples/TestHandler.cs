using System;

namespace OCE
{
    public class TestHandler : Listener
    {

        [EventHandler(EventPriority.NORMAL)]
        public void testEvent(TestEvent e)
        {
            
            Console.WriteLine(e.testMessage);
            
        }
        
    }
}