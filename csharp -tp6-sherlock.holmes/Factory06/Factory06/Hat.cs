using System;
using System.Collections.Generic;

namespace Factory06
{
    public class Hat : Machine // public protected private
    {
        private readonly uint [] upgrades = { 200, 300, 400 };
        private readonly int maxLevel = 4;

        // TODO
        public Hat()
        {
            items = new List<Item>();
            type = MachineType.Hat;
            level = 1;
            capacity = 300;
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
                        capacity += 300;
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
                        items[i] = new Item(ItemType.Hat);
                    } else
                    {
                        items.Add(new Item(ItemType.Hat));
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
                return true;
            }
            return false;
            // throw new NotImplementedException("Fix me!");
            // int: –2147483648 to 2147483647 
            // uint: 0 to 4294967295
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
            capacity = 300;
            Clear();
            return (uint) MachinePrice.Hat / 3;
            // throw new NotImplementedException("Fix me!");
        }
    }
}


