using System;
using System.Collections.Generic;
using VisitorPlacementTool;

namespace VisitorPlacementVisualiser
{
    class Program
    {
        static void Main(string[] args)
        {
            Section section = new Section("A", 2, 3);
            Event varEvent = new Event(new List<Section>(){section});

            foreach (var sectionVar in varEvent.Sections)
            {
                
            }
        }
    }
}