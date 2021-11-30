using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool
{
    public class Section
    {
        public string Id { get; }

        public List<Row> Rows = new List<Row>();

        public Section(string id, int numRows, int numChairs)
        {
            Id = id;
            for (int i = 0; i < numRows; i++)
            {
                Rows.Add(new Row(numChairs));
            }
        }

        public int FreeSeats()
        {
            return Rows.Sum(r => r.FreeSeats());
        }
    }
}