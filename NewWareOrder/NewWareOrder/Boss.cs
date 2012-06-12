// Projectile.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NewWareOrder
{
    class Boss
    {
        // Image representing the Projectile
        public Texture2D Texture;

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int Damage;

        // Represents the viewable boundary of the game
        Viewport viewport;

        public int boundry;

        // direction
        String direction = "right";

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeed;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position, int boundry_coord)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;

            Active = true;

            Damage = 2;

            projectileMoveSpeed = 40f;

            boundry = boundry_coord;
            

        }
        public void Update()
        {
            // Projectiles always move to the right
            //Position.X -= 1;

            if (Position.X > (this.boundry - Texture.Width))
            {
                direction = "left";
            }

            if (Position.X < 0)
            {
                direction = "right";
            }


            if (direction == "right")
            {
                Position.X += 1;
            }

            if (direction == "left")
            {
                Position.X -= 1;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            //spriteBatch.Draw(Texture, Position, null, Color.White, 0f, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        
        }
    }
}
