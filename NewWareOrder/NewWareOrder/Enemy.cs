using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NewWareOrder
{
    class Enemy
    {

        // Animation representing the enemy
        public Animation EnemyAnimation;

        // The position of the enemy ship relative to the top left corner of thescreen
        public Vector2 Position;

        public Vector2 delta;

        // The state of the Enemy Ship
        public bool Active;

        // The hit points of the enemy, if this goes to zero the enemy dies
        public int Health;

        // The amount of damage the enemy inflicts on the player ship
        public int Damage;

        // The amount of score the enemy will give to the player
        public int Value;

        // Get the width of the enemy ship
        public int Width
        {
            get { return EnemyAnimation.FrameWidth; }
        }

        // Get the height of the enemy ship
        public int Height
        {
            get { return EnemyAnimation.FrameHeight; }
        }

        // The speed at which the enemy moves
        float enemyMoveSpeed;

        public void Initialize(Animation animation, Vector2 position, Vector2 player_pos)
        {
            // Load the enemy ship texture
            EnemyAnimation = animation;

            // Set the position of the enemy
            Position = position;


            // We initialize the enemy to be active so it will be update in the game
            Active = true;


            // Set the health of the enemy
            Health = 1;

            // Set the amount of damage the enemy can do
            Damage = 10;

            // Set how fast the enemy moves
            enemyMoveSpeed = 4f;


            // Set the score value of the enemy
            Value = 100;

        }


        public void Update(GameTime gameTime, int boundry, Vector2 player_pos, Vector2 boss_pos)
        {
            // The enemy always moves to the left so decrement it's xposition
            //Position.Y += enemyMoveSpeed;

            // Get the enemy to go towards the player
            Vector2 delta;
            delta = player_pos - Position;
            delta.Normalize();
           
            /*
            double delta_len;
            delta_len = Math.Sqrt((delta.X * delta.X) + (delta.Y * delta.Y));

            Position.X = delta.X * (20 / (float)delta_len);
            Position.Y = delta.Y * (20 / (float)delta_len);
            */

            Position += delta * 4;

           //  var distance = player.position - this.position; 
            //distance.Normalize(); 
            //this.position += distance * enemy_speed * delta_time;

            // Update the position of the Animation
            EnemyAnimation.Position = Position;

            // Update Animation
            EnemyAnimation.Update(gameTime);

            // If the enemy is past the screen or its health reaches 0 then deactivateit
            if (Position.Y > boundry  || Health <= 0)
            {
                // By setting the Active flag to false, the game will remove this objet fromthe 
                // active game list
                Active = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the animation
            EnemyAnimation.Draw(spriteBatch);
        }
    }
}
