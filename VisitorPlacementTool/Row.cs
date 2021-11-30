using System;
using System.Collections.Generic;

namespace VisitorPlacementTool
{
    public class Row
    {
        private int _numChairs;
        private List<Visitor> _visitors = new List<Visitor>();

        private int _visitorCount => _visitors.Count;

        public Row(int numChairs)
        {
            _numChairs = numChairs;
        }

        public int FreeSeats()
        {
            return _numChairs - _visitorCount;
        }

        public bool TryPlaceVisitor(Visitor visitor)
        {
            if (_visitorCount == _numChairs)
            {
                return false;
            }
            else
            {
                _visitors.Add(visitor);
                return true;
            }
        }

        public bool Exists(Predicate<Visitor> match)
        {
            return _visitors.Exists(match);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}