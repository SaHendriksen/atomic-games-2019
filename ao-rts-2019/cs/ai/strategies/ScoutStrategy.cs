using System;
using System.Collections.Generic;
using System.Linq;

namespace ai
{
    public class ScoutStrategy : IUnitStrategy
    {
        private readonly IMap Map;
        private readonly IUnitManager UnitManager;
        private bool isFirstMove;


        public ScoutStrategy(IMap map, Unit unit, UnitManager unitManager, bool isFirstMove)
        {
            Map = map;
            UnitManager = unitManager;
            isFirstMove = isFirstMove;
        }

        public AICommand BuildCommand(Unit unit)
        {
            if (isFirstMove) {
                isFirstMove = false;
                return AICommand.BuildMoveCommand(unit, unit.NextMove());
            } else if (!unit.HasPath) {
                int Xincrementer = 2;
                int Yincrementer = 2;
                // var tileLocation = unit.Location;
                // tileLocation.X = tileLocation.X * incrementer;
                // tileLocation.Y = tileLocation.Y * incrementer;
                
                PathFinder pF = new PathFinder(Map);
                
                unit.Path = pF.FindPath(unit.Location, (unit.Location.X * Xincrementer, unit.Location.Y * Yincrementer));

                while (Yincrementer < 3 && !unit.HasPath) {
                    // tileLocation.X = tileLocation.X + 1;
                    // tileLocation.Y = tileLocation.Y + 1;
                    Yincrementer = Yincrementer + 1;
                    Xincrementer = Xincrementer + 1;

                    unit.Path = pF.FindPath(unit.Location, (unit.Location.X, unit.Location.Y * Yincrementer));
                }

                while (Xincrementer < 3 && !unit.HasPath) {
                    // tileLocation.X = tileLocation.X + 1;
                    // tileLocation.Y = tileLocation.Y + 1;
                    Yincrementer = Yincrementer + 1;
                    Xincrementer = Xincrementer + 1;

                    unit.Path = pF.FindPath(unit.Location, (unit.Location.X * Xincrementer, unit.Location.Y));
                }

                while (Xincrementer < 3 && Yincrementer < 5 && !unit.HasPath) {
                    // tileLocation.X = tileLocation.X + 1;
                    // tileLocation.Y = tileLocation.Y + 1;
                    Yincrementer = Yincrementer + 1;
                    Xincrementer = Xincrementer + 1;

                    unit.Path = pF.FindPath(unit.Location, (unit.Location.X * Xincrementer, unit.Location.Y * Yincrementer));
                }

                return AICommand.BuildMoveCommand(unit, unit.NextMove());
            } else {
                return AICommand.BuildMoveCommand(unit, unit.NextMove());
            }


            // if (!unit.HasPath) {
            //     PathFinder pF = new PathFinder(Map);
            //     unit.Path = pF.FindPath(unit.Location, (1000, 1000));


            //     return AICommand.BuildMoveCommand(unit, unit.NextMove());
            // } else {
            //     return AICommand.BuildMoveCommand(unit, unit.NextMove());

            // }
        }
    }
}