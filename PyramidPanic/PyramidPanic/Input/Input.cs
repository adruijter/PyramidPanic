using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public static class Input
    {
        //Fields
        private static MouseState ms, oms;
        private static KeyboardState ks, oks;
        private static Rectangle mouseRectangle;

        //Properties
        public static Rectangle MouseRectangle
        {
            get {
                    mouseRectangle.X = ms.X;
                    mouseRectangle.Y = ms.Y;
                    return mouseRectangle;
                }
        }


        //Constructor
        static Input()
        {
            ms = Mouse.GetState();
            ks = Keyboard.GetState();
            mouseRectangle = new Rectangle(ms.X, ms.Y, 1, 1);
        }


        //Methods

        //Update
        public static void Update(GameTime gameTime)
        {
            oms = ms;
            oks = ks;
            ms = Mouse.GetState();
            ks = Keyboard.GetState();
        }

        public static bool MouseClickLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed);
        }

        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        public static bool LevelDetectKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }

    }
}
