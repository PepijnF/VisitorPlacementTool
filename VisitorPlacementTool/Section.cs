using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool
{
    public class Section
    {
        public string Id { get; }
        private List<Row> _rows = new List<Row>();

        public IReadOnlyList<Row> Rows => _rows.AsReadOnly();

        public Section(string id, int numRows, int numChairs)
        {
            Id = id;
            for (int i = 0; i < numRows; i++)
            {
                _rows.Add(new Row(numChairs));
            }
        }

        public bool TryPlaceVisitor(Visitor visitor)
        {
            bool result = false;
            foreach (var row in Rows)
            {
                if (row.TryPlaceVisitor(visitor))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public int FreeSeats()
        {
            return Rows.Sum(r => r.FreeSeats());
        }

        public bool IsVisitorSeated(Visitor visitor)
        {
            return Rows.Aggregate(
                new { exists = false },
                (result, row) => 
                    (row.IsVisitorSeated(visitor)) ? new { exists = true } : result).exists;
        }
    }
}