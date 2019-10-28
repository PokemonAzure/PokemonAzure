using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

using SFML.Audio;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using PokemonAzure.Engine;

namespace Game
{
    class Game : GameWindow
    {
        public Game() : base(240 * 4, 160 * 4) { }

        Sprite sprite;
        Sprite owo;

        Vector2f position = new Vector2f();

        protected override void LoadContent()
        {
            sprite = LoadSprite("Sprites/Player.png");
            owo = LoadSprite("Sprites/owo.png");
        }

        protected override void Update()
        {
            if(Input.GetKey(Keyboard.Key.A))
            {
                position.X += 1;
            }
        }

        protected override void Render()
        {
            DrawSprite(sprite, position);
            DrawSprite(owo, new Vector2f(0,400));
        }
    }
}
