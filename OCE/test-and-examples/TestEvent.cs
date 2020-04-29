namespace OCE
{
    public class TestEvent : Event
    {

        public string testMessage { get;}

        
        public TestEvent(string testMessage)
        {

            this.testMessage = testMessage;

        }

    }
}