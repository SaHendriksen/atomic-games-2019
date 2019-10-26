using System;

namespace ai
{
    public class UnitStrategyFactory
    {
        public void AssignStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            if (unit.Strategy == null)
            {
                unit.Strategy = BuildStrategy(map, unit, unitManager);
            }
        }

        private IUnitStrategy BuildStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            if (unit.IsBase) {
                return BuildBaseStrategy(map, unit, unitManager);
            } else if (unit.IsWorker && !map.EnemyBaseFound) {
                return BuildWorkerStrategy(map, unit, unitManager);
            } else if (unit.IsScout && !map.EnemyBaseFound) {
                return BuildScoutStrategy(map, unit, unitManager);
            } else {
                // Attack
            }


            // if (unit.IsMobile)
            // {
            //     return BuildExploreStrategy(map, unit, unitManager);
            // }
            return null;
        }

        private ExploreStrategy BuildExploreStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            return new ExploreStrategy(map, unit, unitManager);
        }

        private BaseStrategy BuildBaseStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            return new BaseStrategy(map, unit, unitManager);
        }

        private WorkerStrategy BuildWorkerStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            return new WorkerStrategy(map, unit, unitManager);
        }

        private ScoutStrategy BuildScoutStrategy(IMap map, Unit unit, UnitManager unitManager)
        {
            return new ScoutStrategy(map, unit, unitManager);
        }
    }
}