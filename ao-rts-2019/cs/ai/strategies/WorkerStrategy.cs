using System;
using System.Collections.Generic;
using System.Linq;

namespace ai
{
    public class WorkerStrategy : IUnitStrategy
    {
        private readonly IMap Map;
        private readonly IUnitManager UnitManager;


        public WorkerStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            Map = map;
            UnitManager = unitManager;
        }

        public AICommand BuildCommand(Unit unit)
        {
            if (!unit.HasPath) {
                PathFinder pF = new PathFinder(Map);

                if (unit.CarryingResource) {
                    unit.Path = pF.FindPath(unit.Location, (0, 0));
    
                    return AICommand.BuildMoveCommand(unit, unit.NextMove());
                } else if (Map.IsResourceAdjacentTo(unit.Location)) {
                    var direction = MapDirections.CardinalDirection(unit.Location, Map.ResourceLocationsNearest(unit.Location).First());

                    return AICommand.BuildGatherCommand(unit, direction);
                } else if (!unit.AdjacentToResource(Map)) {
                    if (Map.ResourceLocationsNearest(unit.Location).Count > 0) {
                        Console.WriteLine(Map.ResourceLocationsNearest(unit.Location).First());
                        var location = Map.ResourceLocationsNearest(unit.Location).First();

                        unit.Path = pF.FindPath(unit.Location, location, 1);
                        Console.WriteLine("unit path is " + unit.Path);

                        return AICommand.BuildMoveCommand(unit, unit.NextMove());
                    }
                } else {
                    return null;
                }
            } else {
                return AICommand.BuildMoveCommand(unit, unit.NextMove());
            }

            return null;
        }

        private void GetBestRoute((int X, int Y) location, Unit unit) {
            PathFinder pF = new PathFinder(Map);

            pF.FindPath(unit.Location, (10, 10));

            Console.WriteLine(unit.NextMove());
            
        }
    }
}