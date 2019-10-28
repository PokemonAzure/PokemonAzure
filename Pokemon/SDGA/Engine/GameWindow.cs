using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;
using SFML.System;
using PokemonAzure.Engine;

namespace Engine
{
    abstract class GameWindow : GameComponent
    {
        // Render window
        private RenderWindow Window;

        // FPS
        public float FPS
        {
            get
            {
                return currentFPS;
            }

            set
            {
                frameDelay = 1f / value;
                targetFPS = (int)Math.Round(value);
            }
        }

        private int targetFPS;
        private float currentFPS;
        private float frameDelay;

        // Settings
        static readonly string VERSION = "InDev 281019a";

        public GameWindow(uint _width, uint _height)
        {
            // Content call
            ContentManager.Setup();
            LoadContent();

            // Loading window icon
            //if(windowIcon == null)
            //    windowIcon = new Image("C:\\Users\\Gerbuiker\\source\\repos\\SDGA\\SDGA\\SDGA\\windowicon.png");

            // Setting the console name
            Console.Title = "Pokemon Azure Debug";

            // Setting default target FPS
            FPS = 60;

            // Creating the window
            Window = new RenderWindow(new VideoMode(_width, _height), "Pokemon Azure   " + VERSION, Styles.Titlebar | Styles.Close);
            //Window.SetIcon(256,256,windowIcon.Pixels);
            Window.Closed += CloseEvent;

            Window.KeyPressed += Input.KeyPressed;
            Window.KeyReleased += Input.KeyReleased;

            SetWindow(Window);

            // Running the window
            Run();
        }

        private void Run()
        {
            // Start call
            Start();

            double updateTime = 0d;
            float totalTime = 0f;
            float oldTime = 0f;
            float deltaTime = 0f;

            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                totalTime = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTime - oldTime;
                oldTime = totalTime;

                updateTime += deltaTime;

                if (updateTime >= frameDelay)
                {
                    updateTime = 0;
                    
                    Update();

                    Window.Clear(Color.Black);
                    Render();
                    Window.Display();
                }

            }
        }

        // Virtuals
        protected virtual void LoadContent() { }
        protected virtual void Start() { }
        protected virtual void Update() { }
        protected virtual void Render() { }

        // Events
        private void CloseEvent(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
