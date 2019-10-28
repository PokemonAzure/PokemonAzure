using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace Engine
{
    abstract class GameComponent
    {
        protected static RenderWindow window { get; private set; }
        
        protected void println(object message)
        {
            Console.WriteLine(message);
        }

        protected void print(object message)
        {
            Console.Write(message);
        }

        protected void SetWindow(RenderWindow _window)
        {
            if(window == null)
                window = _window;
        }

        // Spriting
        protected void DrawSprite(Sprite sprite, Vector2f position)
        {
            sprite.Position = position;
            sprite.Draw(window, new RenderStates(sprite.Texture));
        }

        protected Sprite LoadSprite(string path)
        {
            return new Sprite(new Texture(ContentManager.ASSETS_PATH + path));
        }
    }
}
