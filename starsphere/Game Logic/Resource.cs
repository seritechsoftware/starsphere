using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starsphere.Game_Logic
{
    class Resource
    {
        private int amount;
        private Types.NatResource resourceType;
        private Types.EaseOfAccess ease;

        public Resource(int quantity, Types.NatResource type, Types.EaseOfAccess access)
        {
            amount = quantity;
            resourceType = type;
            ease = access;
        }

        public int ResourceAmount
        {
            get { return amount; }
        }

        public Types.NatResource Type
        {
            get { return resourceType;}
        }

        public Types.EaseOfAccess Ease
        {
            get { return ease; }
        }
    }
}
