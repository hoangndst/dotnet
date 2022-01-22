using System;
using System.Collections.Generic;

namespace Factory06
{
    public class Flask : Machine
    {
        private readonly uint [] upgrades = { 300 };
        private readonly int maxLevel = 2;

        // TODO
        public Flask()
        {
            items = new List<Item>();
            type = MachineType.Flask;
            level = 1;
            capacity = 20;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        public override bool Upgrade(ref long money)
        {
            if (level < maxLevel)
            {
                if (money >= upgrades[level - 1])
                {
                    money -= upgrades[level - 1];
                    level++;
                    if (level == 2)
                    {
                        capacity += 10;
                    } else
                    {
                        capacity *= 2;
                    }
                    return true;
                }
            }
            return false;
            // throw new NotImplementedException("Fix me!");
        }
        
        // TODO
        public override bool Produce(uint count, ref long money)
        {
            throw new NotImplementedException("Fix me!");
        }

        // TODO
        public override void Clear()
        {
            throw new NotImplementedException("Fix me!");
        }

        // TODO
        public override uint Destroy()
        {
            throw new NotImplementedException("Fix me!");
        }
    }
}