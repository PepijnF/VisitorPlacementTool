using System;
using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool
{
    public class Group
    {
        public Guid Id { get; }
        public readonly List<Visitor> Visitors = new List<Visitor>();
        public int NotPlaced
        {
            get => Visitors.FindAll(v => v.IsPlaced == false).Count;
        }

        public Group()
        {
            Id = Guid.NewGuid();
        }
        
        public Group(List<Visitor> visitors)
        {
            Id = Guid.NewGuid();
            Visitors = visitors;
        }

        public void AddVisitor(Visitor visitor)
        {
            Visitors.Add(visitor);
        }
    }
}