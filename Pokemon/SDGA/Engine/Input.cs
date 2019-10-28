using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAzure.Engine
{
    static class Input
    {
        private static bool[] keys = new bool[255];

        public static void KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            keys[(int)e.Code] = true;
        }

        public static void KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            keys[(int)e.Code] = false;
        }

        public static bool GetKey(Keyboard.Key key)
        {
            return keys[(int) key];
        }
    }
}
