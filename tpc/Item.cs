using System;

namespace Factory06
{
    public class Item
    {
        private readonly uint price;
        private ItemType type;
        
        // TODO
        // Getters
        // Add a getter Price
        public uint Price
        {
            get
            {
                return price;
            }
        }
        // Add a getter Type

        public ItemType Type
        {
            get
            {
                return type;
            }
        }

        // TODO
        public Item(ItemType type)
        {
            this.type = type;
            this.price = (uint)type;
            // throw new NotImplementedException("Fix me!");
        }

        // TODO
        /**
         * Sell the item.
         * A hat is worth 3 times its price.
         * A coat is worth 4 times its price.
         * A flask is worth 6 times its price.
         */
        public uint Sell()
        {   
            switch (type)
            {
                case ItemType.Hat:
                    return price * 3;
                case ItemType.Coat:
                    return price * 4;
                case ItemType.Flask:
                    return price * 6;
                default:
                    return price;
            }
            // throw new NotImplementedException("Fix me!");
        }
    }
}