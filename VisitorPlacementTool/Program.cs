using System;
using System.Collections.Generic;

namespace VisitorPlacementTool
{
    class Program
    {

        static void Main(string[] args)
        {
            Event varEvent = new Event(new List<Section>(){new Section("A", 2, 5)});
            Group group = new Group();
            group.AddVisitor(new Visitor());
            group.AddVisitor(new Visitor());
            group.AddVisitor(new Visitor());

            EventManager eventManager = new EventManager(varEvent, EventPromoter.GetVisitors(5), new List<Group>() { group });
            Event filledEvent = eventManager.GetFilledEvent();
            Console.ReadKey();
        }
    }
}