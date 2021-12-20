using System;
using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool
{
    public class Group
    {
        public Guid Id { get; }
        private List<Visitor> _visitors = new List<Visitor>();
        public List<Visitor> NotPlaced => _visitors.FindAll(v => v.IsPlaced == false);

        public List<Visitor> Children => _visitors.FindAll(v => v.IsChild);

        public Group()
        {
            Id = Guid.NewGuid();
        }
        
        public Group(List<Visitor> visitors)
        {
            Id = Guid.NewGuid();
            _visitors = visitors;
        }

        public void AddVisitor(Visitor visitor)
        {
            _visitors.Add(visitor);
        }
    }
}