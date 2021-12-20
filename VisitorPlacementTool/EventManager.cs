using System;
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
            foreach (var group in Groups)
            {
                if (Event.FreeSeats() >= group.NotPlaced.Count)
                {
                    while (group.NotPlaced.Count > 0)
                    {
                        var section = Event.SectionWithMostFreeSpace();
                        foreach (var visitor in group.NotPlaced)
                        {
                            visitor.IsPlaced = section.TryPlaceVisitor(visitor);
                        }
                    }
                }
            }
        }

        public void PlaceVisitors()
        {
            foreach (var visitor in Visitors)
            {
                foreach (var section in Event.SectionsWithFreeSeates(1))
                {
                    if (!visitor.IsPlaced)
                    {
                        visitor.IsPlaced = section.TryPlaceVisitor(visitor);
                    }
                }
            }
        }

        public void PlaceChildren()
        {
            foreach (var group in Groups)
            {
                foreach (var child in group.Children)
                {
                    
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