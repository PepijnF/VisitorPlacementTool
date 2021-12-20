using System;
using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool
{
    public class Event
    {
        private List<Section> _sections;
        public IReadOnlyList<Section> Sections => _sections.AsReadOnly();

        public Event(List<Section> sections)
        {
            _sections = sections;
        }

        public List<Section> SectionsWithFreeSeates(int neededSeats)
        {
            return _sections.FindAll(s => s.FreeSeats() >= neededSeats);
        }

        public int FreeSeats()
        {
            return _sections.Sum(s => s.FreeSeats());
        }

        public Section SectionWithMostFreeSpace()
        {
            return _sections.Aggregate(
                new { MaxValue = Int32.MinValue, Section = (Section)null }, 
                (maxFreeSeatsSection, section) => (section.FreeSeats() > maxFreeSeatsSection.MaxValue) 
                    ? new { MaxValue = section.FreeSeats(), Section = section } : maxFreeSeatsSection).Section;
        }

        public bool IsVisitorSeated(Visitor visitor)
        {
            return _sections.Aggregate(
                new { exists = false },
                (result, section) => 
                    (section.IsVisitorSeated(visitor)) ? new { exists = true } : result).exists;
        }
    }
}