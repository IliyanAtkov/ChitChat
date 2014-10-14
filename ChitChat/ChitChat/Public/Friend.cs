using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChat.Private;

namespace ChitChat.Public
{
    public class Friend
    {
        private string name;
        private int id;
        private Stances currentStance;

        public Friend(int id, string name, Stances currentStance)
        {
            Id = id;
            Name = name;
            this.currentStance = currentStance;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set 
            {
                this.name = value;
            }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            set 
            {
                this.id = value;
            }
        }
        public Stances Stance
        {
            get
            {
                return this.currentStance;
            }
            set
            {
                this.Stance = value;
            }
        }
            
    }
}
