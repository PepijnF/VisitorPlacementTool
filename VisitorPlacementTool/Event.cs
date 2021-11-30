using System.Collections.Generic;

namespace VisitorPlacementTool
{
    public class Event
    {
        public List<Section> Sections;

        public Event(List<Section> sections)
        {
            Sections = sections;
        }

        //public bool IsVisitorSeated(Visitor visitor)
        //{
        //    
        //}
    }
}