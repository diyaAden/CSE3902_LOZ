using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links.State;
using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Links
{
    public class Link: ILink
    {
        public ILinkState State{ get {return state; } set { state = value; } }
        private ILinkState state;
        bool isDamaged = false;
        private int attackCooldown;
        private const int cooldownLimit = 30, getTriforceCooldownLimit = 460;
        private readonly List<Vector2> roomSwapPositions = new List<Vector2>() { new Vector2(122, 32), new Vector2(122, 127), new Vector2(208, 80), new Vector2(34, 80), new Vector2(48, 5), new Vector2(111, 80) };
        private int numKeys = 0;
        private int numRupees = 10;
        private int numBombs = 0;


       
        public List<IGameObject> linkInventory = new List<IGameObject>();
        public Link(Vector2 position, Vector2 screenOffset, int scale)
        {
            position.X = (position.X + screenOffset.X) * scale;
            position.Y = (position.Y + screenOffset.Y) * scale;
            state = new RightIdleLinkState(this, position, isDamaged);
            attackCooldown = 0;
            for (int i = 0; i < roomSwapPositions.Count; i++)
            {
                roomSwapPositions[i] = new Vector2(roomSwapPositions[i].X + screenOffset.X, roomSwapPositions[i].Y + screenOffset.Y);
            }
        }

        //Motions that link will have, and change the state.
        public void ToIdle()
        {
            if (attackCooldown == 0) state.ToIdle();
        }
        public void MoveUp()
        {
            if (attackCooldown == 0) state.MoveUp();
        }
        public void MoveDown()
        {
            if (attackCooldown == 0) state.MoveDown();
        }
        public void MoveRight()
        {
            if (attackCooldown == 0) state.MoveRight();
        }
        public void MoveLeft()
        {
            if (attackCooldown == 0) state.MoveLeft();
        }
        public void UseItem()
        {
            if (attackCooldown == 0)
            {
                attackCooldown = cooldownLimit;
                state.UseItem();
            }
        }
        public void Attack(int scale)
        {
            if (attackCooldown == 0)
            {
                attackCooldown = cooldownLimit;
                state.Attack(scale);
            }
        }

        public void PickItem(string name, int scale)
        {
            if (name.Contains("Rupee")) SoundController.Instance.PlayGetRupeeSound();
            else if (name.Equals("Heart")) SoundController.Instance.PlayGetHeartSound();
            else if (name.Contains("Triforce"))
            {
                attackCooldown = getTriforceCooldownLimit;
                SoundController.Instance.PlayGetTriforceMusic();
                state.PickItem(name, scale);
                
            }
            else
            {
                attackCooldown = cooldownLimit;
                state.PickItem(name, scale);
            }
        }
        public void HandleBlockCollision(IGameObject gameObject, ICollision side)
        {
            if (side is ICollision.SideTop)
            {
                state.PositionDown();
            }
            else if (side is ICollision.SideBottom)
            {
                state.PositionUp();
            }
            else if (side is ICollision.SideLeft)
            {
                state.PositionRight();
            }
            else if (side is ICollision.SideRight)
            {
                state.PositionLeft();
            }
            else if (side is ICollision.SideNone)
            {
                //do nothing
            }
        }
        public void HandleDoorCollision(int direction, int scale)
        {
            state.Position = new Vector2(roomSwapPositions[direction].X * scale, roomSwapPositions[direction].Y * scale);
        }
        public void HandleEnemyCollision(IEnemy enemy, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("enemy collision registered");
                // isDamaged = true;
                SoundController.Instance.PlayLinkGetsHurtSound();
                state.ToDamaged();
            }

        }

        public void addInventoryItem(IGameObject gameObject)
        {
            if (((IItem)gameObject).Name == "Rupee")
            {
                //add to rupee count
                numRupees++;
            }
            else if (((IItem)gameObject).Name != "Key")
            {
                //add to key
                numKeys++;
            }
            else
            {
                linkInventory.Add(gameObject);
                if (((IItem)gameObject).Name == "Bomb")
                {
                    numBombs++;
                }
                    Debug.WriteLine("item added!");
            }
        }

        public void HandleWeaponCollision(IGameObject gameObject, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("hurt by urs weapon");
                isDamaged = true;
                SoundController.Instance.PlayLinkGetsHurtSound();
                state.ToDamaged();
            }

        }
        public void HandleItemCollision(IGameObject gameObject, ICollision side, int scale)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine(((IItem)gameObject).Name);
                Debug.WriteLine("Pick up item!!!!");
                PickItem(((IItem)gameObject).Name, scale);
                addInventoryItem(gameObject);

            }
        }
        //Update and draw
        public void Update()
        {
            if (attackCooldown != 0) attackCooldown--;
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            state.Draw(spriteBatch, scale);
        }
    }
}
