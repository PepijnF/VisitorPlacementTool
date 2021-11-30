using System;

namespace VisitorPlacementTool
{
    public class Visitor
    {
        public Guid Id { get; }
        
        // TODO change this into function
        public bool IsPlaced = false;

        public Visitor()
        {
            Id = Guid.NewGuid();
        }
    }
}