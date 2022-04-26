﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class CompassMapDisplay
    {
        public List<int> roomsToDraw = new List<int>();
       // public Dictionary<int, Vector2> roomsList = new Dictionary<int, Vector2>();
        Texture2D r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16;
        public enum Rooms {
            Room1,
            Room2,
            Room3,
            Room4,
            Room5,
            Room6,
            Room7,
            Room8,
            Room9,
            Room10,
            Room11,
            Room12,
            Room13,
            Room14,
            Room15,
            Room16,
            Room17
        }
      
        public CompassMapDisplay()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            r1 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r1spr");
            r2 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r2spr");

            r3 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r3spr");
            r4 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r4spr");

            r5 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r5spr");
            r6 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r6spr");

            r7 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r7spr");
            r8 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r8spr");

            r9 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r9spr");
            r10 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r10spr");

            r11 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r11spr");
            r12 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r12spr");

            r13 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r13spr");
            r14 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r14spr");

            r15 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r15spr");
            r16 = content.Load<Texture2D>("SpriteSheets/RoomSprites/r16spr");

      

        }

      

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle rSprSource = new Rectangle(0, 0, r2.Width, r2.Height );


            foreach (int i in roomsToDraw)
            {

                switch (i)
                {
                    case 0:
                        
                        break;
                    case 1:
                        spriteBatch.Draw(r2, new Rectangle(430, 300, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 2:
                        spriteBatch.Draw(r16, new Rectangle(446, 300, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 3:
                        spriteBatch.Draw(r3, new Rectangle(462, 300, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 4:
                        spriteBatch.Draw(r13, new Rectangle(446, 284, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 5:
                        spriteBatch.Draw(r9, new Rectangle(430, 268, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 6:
                        spriteBatch.Draw(r8, new Rectangle(446, 268, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 7:
                        spriteBatch.Draw(r6, new Rectangle(462, 267, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 8:
                        spriteBatch.Draw(r2, new Rectangle(414, 252, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 9:
                        spriteBatch.Draw(r6, new Rectangle(430, 252, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 10:
                        spriteBatch.Draw(r12, new Rectangle(446, 252, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 11:
                        spriteBatch.Draw(r4, new Rectangle(462, 252, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 12:
                        spriteBatch.Draw(r11, new Rectangle(478, 252, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 13:
                        spriteBatch.Draw(r13, new Rectangle(446, 236, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 14:
                        spriteBatch.Draw(r5, new Rectangle(478, 236, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 15:
                        spriteBatch.Draw(r3, new Rectangle(494, 236, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 16:
                        spriteBatch.Draw(r1, new Rectangle(414, 220, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 17:
                        spriteBatch.Draw(r2, new Rectangle(430, 220, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                    case 18:
                        spriteBatch.Draw(r3, new Rectangle(446, 220, r2.Width * scale, r2.Height * scale), rSprSource, Color.White);
                        break;
                   
                    default:
                        //location = new Vector2(0, 0);
                        break;
                }
            }
        }
    }
}
