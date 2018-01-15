using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Robot
    {
        private Dictionary<string, ComponentBase> components = new Dictionary<string, ComponentBase>();

        public T GetComponent<T>(string name) where T : ComponentBase
        {
            ComponentBase ret;
            if (components.TryGetValue(name, out ret))
            {
                return (T)ret;
            }
            return null;
        }

        public T GetComponent<T>() where T : ComponentBase
        {
            Type t = typeof(T);
            return GetComponent<T>(t.Name);
        }

        public bool AddComponent(ComponentBase component)
        {
            Type t = component.GetType();
            //Console.WriteLine("------{0}", t.Name);
            components.Add(t.Name, component);
            return true;
        }

        public bool RemoveComponent(string name)
        {
            ComponentBase ret;
            if (!components.TryGetValue(name, out ret))
            {
                return false;
            }
            components.Remove(name);
            return true;
        }

        public void Update()
        {
            Console.WriteLine("I'm a robot.");
            foreach (var pair in components)
            {
                pair.Value.Update();
            }
        }

    }
}
