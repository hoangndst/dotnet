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
            if (count == 0)
            {
                return true;
            } else if (count <= capacity)
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < items.Count)
                    {
                        items[i] = new Item(ItemType.Flask);
                    } else
                    {
                        items.Add(new Item(ItemType.Flask));
                    }

                    if (money - items[i].Price < 0)
                    {
                        items.RemoveAt(i);
                        return false;
                    } else
                    {
                        money -= items[i].Price;
                    }
                }
            }
            return false;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        public override void Clear()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i] = null;
            }
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        public override uint Destroy()
        {
            level = 1;
            capacity = 20;
            Clear();
            return (uint) MachinePrice.Flask / 3;
            // throw new NotImplementedException("Fix me!");
        }
    }
}