using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace VisitorPlacementTool.Specs.Steps
{
    [Binding]
    public sealed class VisitorPlacementStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        
        private Event _event;
        private EventManager _eventManager;

        private List<Group> _groups = new List<Group>();
        private List<Visitor> _visitors = new List<Visitor>();
        private List<Section> _sections = new List<Section>();

        private int _numSections;
        private int _numRows;
        private int _numSeats;

        public VisitorPlacementStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"there are (.*) sections")]
        public void GivenThereIsSection(string numSections)
        {
            _numSections = Convert.ToInt32(numSections);
        }

        [Given(@"the section has (.*) rows")]
        public void GivenTheSectionHasRows(int numRows)
        {
            _numRows = numRows;
        }

        [Given(@"every row has (.*) seats")]
        public void GivenEveryRowHasSeats(int numSeats)
        {
            _numSeats = numSeats;
        }

        [Given(@"there are (.*) visitors")]
        public void GivenThereAreVisitors(int numVisitors)
        {
            _visitors = EventPromoter.GetVisitors(numVisitors);
        }

        [Then(@"(.*) seats should be filled")]
        public void ThenAllSeatsShouldBeFilled(string parm)
        {
            List<Section> sections = new List<Section>();
            for (int i = 0; i < _numSections; i++)
            {
                sections.Add(new Section(i.ToString(), _numRows, _numSeats));
            }
            
            _event = new Event(sections);

            _eventManager = new EventManager(_event, _visitors, _groups);

            Event filledEvent = _eventManager.GetFilledEvent();

            if (parm == "all")
            {
                foreach (var section in filledEvent.Sections)
                {
                    foreach (var row in section.Rows)
                    {
                        Assert.False(row.TryPlaceVisitor(new Visitor()));
                    }
                }
            } else if (parm == "not all")
            {
                foreach (var visitor in _eventManager.Visitors)
                {
                    Assert.True(visitor.IsPlaced);
                }
            }
        }

        [Given(@"there are (.*) groups each has (.*) people")]
        public void GivenThereAreGroupsEachHasPeople(int numGroups, int numPeople)
        {
            for (int i = 0; i < numGroups; i++)
            {
                Group group = new Group();
                for (int j = 0; j < numPeople; j++)
                {
                    group.AddVisitor(new Visitor());
                }
                _groups.Add(group);
            }
        }

        [Given(@"(.*) individual visitors")]
        public void GivenIndividualVisitors(int numVisitors)
        {
            _visitors = EventPromoter.GetVisitors(numVisitors);
        }
    }
}