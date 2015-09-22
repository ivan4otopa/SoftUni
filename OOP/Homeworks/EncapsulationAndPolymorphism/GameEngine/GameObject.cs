using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    abstract class GameObject
    {
        protected GameObject(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
