using System;
using System.Collections.Generic;

namespace Factory06
{
    public class Factory
    {
        private long money;
        private int maxNbMachines = 50;
        private List <Machine> machines;

        // TODO
        // Getters
        // Add a getter Money
        public long Money
        {
            get
            {
                return money;
            }
        }

        // TODO
        public Factory(long initialMoney)
        {   
            money = initialMoney;
            machines = new List<Machine>();
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Return a list of all the machines of the corresponding type.
         * <param name="type">The type of machine to search for</param>
         */
        public List <Machine> GetMatchMachines(MachineType type)
        {  
            List <Machine> matchMachines = new List<Machine>();
            foreach (Machine machine in machines)
            {
                if (machine.Type == type)
                {
                    matchMachines.Add(machine);
                }
            }
            return matchMachines;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Returns a machine of the specified type which still has
         * some capacity left to produce an item.
         * <param name="type">The type of the machine to search for</param>
         */
        public Machine FindAvailableMachine(MachineType type)
        {
            foreach (Machine machine in machines)
            {
                if (machine.Type == type && machine.Capacity > 0)
                {
                    return machine;
                }
            }
            return null;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Build a new machine of the specified type if the factory
         * has enough money and places.
         * Returns true if built, false otherwise
         * <param name="type">The type of the machine to build</param>
         */
        public bool Build(MachineType type)
        {
            int price = 0;
            switch (type)
            {
                case MachineType.Hat:
                    price = (int) MachinePrice.Hat;
                    break;
                case MachineType.Coat:
                    price = (int) MachinePrice.Coat;
                    break;
                case MachineType.Flask:
                    price = (int) MachinePrice.Flask;
                    break;
                default:
                    return false;
            }
            
            if (money >= price && machines.Count < maxNbMachines)
            {
                money -= price;
                switch (type)
                {
                    case MachineType.Hat:
                        machines.Add(new Hat());
                        break;
                    case MachineType.Coat:
                        machines.Add(new Coat());
                        break;
                    case MachineType.Flask:
                        machines.Add(new Flask());
                        break;
                }
                return true;
            }

            return false;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Try to produce count items from machines of the specified type
         * in the factory.
         * Returns true if count items were produced, false otherwise.
         * <param name="type">The type of machine to search for</param>
         * <param name="count">The number of items to produce</param>
         */
        public bool Produce(MachineType type, int count)
        {
            if (count < 0)
            {
                return false;
            }
            return FindAvailableMachine(type).Produce((uint) count, ref money);
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
        * Upgrade all machine on the factory if enough money.
        * Returns true if all upgrade were done, false otherwise.
        */
        public bool UpgradeAll()
        {
            bool upgradeDone = true;
            foreach (Machine machine in machines)
            {
                if (!machine.Upgrade(ref money))
                {
                    upgradeDone = false;
                }
            }
            return upgradeDone;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
        * Upgrade up to count machine on the factory of the specified type
        * and level if the factory has enough money.
        * Returns true if count upgrades were done, false otherwise
        * <param name="type">The type of the machines to upgrade</param>
        * <param name="level">The level of the machines to upgrade</param>
        * <param name="count">The number of machine to upgrade</param>
         */
        public bool UpgradeMatch(MachineType type, int level, int count)
        {
            if (count < 0)
            {
                return false;
            }
            List<Machine> matchMachines = GetMatchMachines(type);
            int nbMachines = (int) Math.Min(count, matchMachines.Count);
            bool upgradeDone = true;
            for (int i = 0; i < nbMachines; i++)
            {
                if (!matchMachines[i].Upgrade(ref money))
                {
                    upgradeDone = false;
                }
            }
            return upgradeDone;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Destroy all the machines in the factory.
         * Returns the total money gained, and also updates the factory's money.
         */
        public uint DestroyAll()
        {
            uint moneyGained = 0;
            foreach (Machine machine in machines)
            {
                moneyGained += machine.Destroy();
            }
            money += moneyGained;
            machines.Clear();
            return moneyGained;
            // throw new NotImplementedException("Fix me!");;
        }

        // TODO
        /**
         * Destroy all the machines in the factory of the specified type.
         * Returns the total money gained, and also updates the factory's money.
         * <param name="type">The type of machine to destroy</param>
         */
        public uint DestroyMatch(MachineType type)
        {
            uint moneyGained = 0;
            List<Machine> matchMachines = GetMatchMachines(type);
            foreach (Machine machine in matchMachines)
            {
                moneyGained += machine.Destroy();
            }
            money += moneyGained;

            for (int i = 0; i < matchMachines.Count; i++)
            {
                machines.Remove(matchMachines[i]);
            }
            return moneyGained;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Collect all the items on the factory.
         */
        public List <Item> CollectAll()
        {
            List <Item> items = new List<Item>();
            
            foreach (Machine machine in machines)
            {
                items.AddRange(machine.Items);
            }
            return items;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Collect all the items on the factory from the machine of the
         * corresponding type.
         * <param name="type">The type of machine to collect from</param>
         */
        public List <Item> CollectMatch(MachineType type)
        {
            List <Item> items = new List<Item>();
            List <Machine> matchMachines = GetMatchMachines(type);
            foreach (Machine machine in matchMachines)
            {
                items.AddRange(machine.Items);
            }
            return items;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Sell all the machines' items on the factory.
         * Returns the total money gained, and updates the factory's money.
         */
        public uint SellAll()
        {
            uint moneyGained = 0;
            List <Item> items = CollectAll();
            foreach (Item item in items)
            {
                moneyGained += item.Sell();
            }
            money += moneyGained;
            ClearAll();
            return moneyGained;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Sell all the items on the factory from the machine of the
         * corresponding type.
         * <param name="type">The type of machine to sell items</param>
         */
        public uint SellMatch(MachineType type)
        {
            uint moneyGained = 0;
            List <Item> items = CollectMatch(type);
            foreach (Item item in items)
            {
                moneyGained += item.Sell();
            }
            money += moneyGained;
            ClearMatch(type);
            return moneyGained;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Clear all machines items on the factory.
         */
        public void ClearAll()
        {
            foreach (Machine machine in machines)
            {
                machine.Items.Clear();
            }
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Clear the items on the factory from the machine of the
         * corresponding type.
         * <param name="type">The type of machine to clear items</param>
         */
        public void ClearMatch(MachineType type)
        {
            List <Machine> matchMachines = GetMatchMachines(type);
            foreach (Machine machine in matchMachines)
            {
                machine.Items.Clear();
            }
            // throw new NotImplementedException("Fix me!");
        }
    }
}