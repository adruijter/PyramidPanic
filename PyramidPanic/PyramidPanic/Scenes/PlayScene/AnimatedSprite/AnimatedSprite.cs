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
    public class AnimatedSprite
    {
        // Fields
        private IEntity entity;
        protected Rectangle destinationRectangle, sourceRectangle;
        private float timer = 0f;
        protected SpriteEffects effect = SpriteEffects.None;
        protected float rotation = 0f;
        
        // Properties


        // Constructor
        public AnimatedSprite(IEntity entity)
        {
            this.entity = entity;
            this.sourceRectangle = new Rectangle(32,
                                                 0,
                                                 this.entity.Texture.Width / 4,
                                                 this.entity.Texture.Height);
        }



        // Update
        public virtual void Update(GameTime gameTime)
        {
            if (this.timer > 5f / 60f)
            {
                if (this.sourceRectangle.X < 96)
                {
                    this.sourceRectangle.X += 32;
                }
                else
                {
                    this.sourceRectangle.X = 0;
                }
                this.timer = 0f;
            }
            this.timer += 1f / 60f;
        }


        // Draw
        public virtual void Draw(GameTime gameTime)
        {
            this.entity.Game.SpriteBatch.Draw(this.entity.Texture,
                                                this.destinationRectangle,
                                                this.sourceRectangle,
                                                Color.White,
                                                this.rotation,
                                                Vector2.Zero,
                                                this.effect,
                                                0f);        
        }
    }
}
