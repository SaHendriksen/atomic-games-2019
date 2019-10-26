using System;
using System.Collections.Generic;
using System.Linq;

namespace ai
{
    public class ScoutStrategy : IUnitStrategy
    {
        private readonly IMap Map;
        private readonly IUnitManager UnitManager;


        public ScoutStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            Map = map;
            UnitManager = unitManager;
        }

        public AICommand BuildCommand(Unit unit)
        {
            if (!unit.HasPath) {
                PathFinder pF = new PathFinder(Map);
                unit.Path = pF.FindPath(unit.Location, (5, 5));

                // Console.WriteLine(unit.NextMove());

                return AICommand.BuildMoveCommand(unit, unit.NextMove());
            } else {
                return AICommand.BuildMoveCommand(unit, unit.NextMove());

            }
        }
    }
}