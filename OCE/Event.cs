using System.Collections.ObjectModel;

namespace OCE
{
    public abstract class Event
    {

        private bool cancelled;
        
        protected Event()
        {
            
            
        }

        public bool isCancelled()
        {

            return cancelled;

        }

        public void setCancelled(bool cancelled)
        {

            this.cancelled = cancelled;

        }
        
    }
}