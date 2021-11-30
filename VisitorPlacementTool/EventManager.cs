using System.Collections.Generic;

namespace VisitorPlacementTool
{
    public class EventManager
    {
        public List<Visitor> Visitors;
        public List<Group> Groups;
        public Event Event;
        
        public EventManager(Event eventParm, List<Visitor> visitors, List<Group> groups)
        {
            Event = eventParm;
            Visitors = visitors;
            Groups = groups;
        }

        public void PlaceGroups()
        {
            foreach (var section in Event.Sections)
            {
                foreach (var group in Groups)
                {
                    if (section.FreeSeats() >= group.NotPlaced)
                    {
                        foreach (var visitor in group.Visitors)
                        {
                            foreach (var row in section.Rows)
                            {
                                if (!visitor.IsPlaced)
                                {
                                    visitor.IsPlaced = row.TryPlaceVisitor(visitor);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PlaceVisitors()
        {
            foreach (var section in Event.Sections)
            {
                foreach (var row in section.Rows)
                {
                    foreach (var visitor in Visitors)
                    {
                        if (!visitor.IsPlaced)
                        {
                            if (!row.TryPlaceVisitor(visitor))
                            {
                                break;
                            }

                            visitor.IsPlaced = true;
                        }
                    }
                }
            }
        }

        public Event GetFilledEvent()
        {
            PlaceGroups();
            PlaceVisitors();
            return Event;
        }
    }
}