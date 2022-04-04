using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.GameStateMachine
{
    public class GameStateManager
    {
        private Texture2D PauseScreen,GameOverScreen;

        public GameState gameState { get; set; }

        public GameState getState()
        {
            return gameState;
        }
        public void setState(GameState state)
        {
            gameState = state;
        }

        public GameStateManager()
        {
            gameState = GameState.Playing;
        }

        public void LoadContent(int scale, Vector2 screenOffset, ContentManager content)
        {
            int posX;
            int posY;


            posX = ((int)screenOffset.X) * scale;
            posY = ((int)screenOffset.Y) * scale;


            PauseScreen = content.Load<Texture2D>("Paused");

            GameOverScreen = content.Load<Texture2D>("GameOver");


        }


        public void Update()
        {
        
        
        }
        public void Draw()
        {
            
        }
    }
}
