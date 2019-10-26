using System;
using System.Collections.Generic;
using System.Linq;

namespace ai
{
    public class BaseStrategy : IUnitStrategy
    {
        private readonly IMap Map;
        private readonly IUnitManager UnitManager;


        public BaseStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            Map = map;
            UnitManager = unitManager;
        }

        public AICommand BuildCommand(Unit unit)
        {
            if (unit.ResourcesAvailable > 130 && UnitManager.ScoutCount == 0) {
                return new AICommand { Command = AICommand.Create, Type = "scout" };
            }
            return null;
        }
    }
}