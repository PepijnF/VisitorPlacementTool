using System.Collections.Generic;

namespace VisitorPlacementTool
{
    public class EventPromoter
    {
        public static List<Visitor> GetVisitors(int amount)
        {
            List<Visitor> visitors = new List<Visitor>();
            for (int i = 0; i < amount; i++)
            {
                visitors.Add(new Visitor());
            }

            return visitors;
        }
    }
}