using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    abstract class Game2DLayout
    {
        public bool Paused { get; set; }
        public bool GameOver { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Renderer renderer;

        public Game2DLayout(int width, int height, Renderer renderer)
        {
            this.Width = width;
            this.Height = height;
            this.renderer = renderer;
        }

    }
}
