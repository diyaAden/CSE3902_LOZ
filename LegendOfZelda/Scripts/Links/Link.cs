using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.HUDandInventoryManager;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponSprites;
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
        public bool HasClock { get; private set; } = false;
        public ILinkState State{ get {return state; } set { state = value; } }
        private ILinkState state;
        private int attackCooldown, hurtCooldown = 0, clockCooldown = 0;
        private const int cooldownLimit = 30, getTriforceCooldownLimit = 460, hurtCooldownLimit = 70, clockCooldownLimit = 300;
        private ICollision enemyCollisionSide;
        private readonly HandlerManager handlerManager;
        private readonly HUDInventoryManager HUDInventoryManager;
        private readonly List<Vector2> roomSwapPositions = new List<Vector2>() { new Vector2(122, 32), new Vector2(122, 127), new Vector2(208, 80), new Vector2(34, 80), new Vector2(48, 5), new Vector2(111, 80) };
        public int numKeys { get; set; } = 0;
        public int numRupees { get; set; } = 10;
        public int numBombs { get; set; } = 3;
        public List<IItem> linkInventory = new List<IItem>();
        //  Texture2D itemSprSheet = 
        IItem firstItem;
     
       // linkInventory.Add(new SwordWeaponSprite());
        public Link(Vector2 position, Vector2 screenOffset, int scale, HUDInventoryManager HUDManager, HandlerManager handlerManager)
        {
            
            this.handlerManager = handlerManager;
            HUDInventoryManager = HUDManager;
            position.X = (position.X + screenOffset.X) * scale;
            position.Y = (position.Y + screenOffset.Y) * scale;
            state = new RightIdleLinkState(this, position, false);
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
        public void GameOverLink()
        {
            state.GameOverLink();
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
            else if (name.Equals("Heart")) {
                HUDInventoryManager.gainHeart();
                SoundController.Instance.PlayGetHeartSound(); 
            }
            else if (name.Contains("Triforce"))
            {
                attackCooldown = getTriforceCooldownLimit;
                SoundController.Instance.PlayGetTriforceMusic();
                state.PickItem(name, scale);

            }
            else if (name.Equals("Bow"))
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
        }
        public void HandleDoorCollision(int direction, int scale)
        {
            state.Position = new Vector2(roomSwapPositions[direction].X * scale, roomSwapPositions[direction].Y * scale);
        }
        public void HandleEnemyCollision(IEnemy enemy, ICollision side) { HandleWeaponCollision(enemy, side); }

        public bool hasArrows()
        {
            if (numRupees> 0)
            {
                numRupees--;
                return true;
            }
            return false; 
        }
        public bool HasKeys()
        {
            if (numKeys > 0)
            {
                numKeys--;
                return true;
            }
            return false;
        }
        public bool hasBombs()
        {
            if (numBombs > 0)
            {
                numBombs--;
                return true;
            }
            return false;
        }
        public void addInventoryItem(IItem gameObject)
        {
            if (gameObject.Name == "BlueRupee") numRupees += 5;
            else if (gameObject.Name == "Rupee") numRupees++;
            else if (gameObject.Name == "Key") numKeys++;
            else if (gameObject.Name == "Clock")
            {
                HasClock = true;
                clockCooldown = clockCooldownLimit;
            }
            else
            {
                linkInventory.Add(gameObject);
                if (gameObject.Name == "Bomb") numBombs++;
            }
        }

        public List<IItem> getInventoryList()
        {
            return linkInventory;
        }

        public void HandleWeaponCollision(IGameObject gameObject, ICollision side)
        {
            if (!(side is ICollision.SideNone) && hurtCooldown == 0)
            {
                Debug.WriteLine("Link has been hurt");
                SoundController.Instance.PlayLinkGetsHurtSound();
                HUDInventoryManager.damageLink();
                state.ToDamaged();
                hurtCooldown = hurtCooldownLimit;
                enemyCollisionSide = side;
            }
        }
        public void HandleItemCollision(IGameObject gameObject, ICollision side, int scale)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine(((IItem)gameObject).Name);
                Debug.WriteLine("Pick up item!!!!");
                PickItem(((IItem)gameObject).Name, scale);
                addInventoryItem((IItem)gameObject);

            }
        }
        private void HurtRecoil()
        {
            int moveDist = 3;
            if (enemyCollisionSide == ICollision.SideTop)
            {
                for (int i = 0; i < moveDist; i++)
                {
                    state.PositionDown();
                    handlerManager.ForLinkBlocks();
                }
            }
            else if (enemyCollisionSide == ICollision.SideBottom)
            {
                for (int i = 0; i < moveDist; i++)
                {
                    state.PositionUp();
                    handlerManager.ForLinkBlocks();
                }
            }
            else if (enemyCollisionSide == ICollision.SideLeft)
            {
                for (int i = 0; i < moveDist; i++)
                {
                    state.PositionRight();
                    handlerManager.ForLinkBlocks();
                }
            }
            else if (enemyCollisionSide == ICollision.SideRight)
            {
                for (int i = 0; i < moveDist; i++)
                {
                    state.PositionLeft();
                    handlerManager.ForLinkBlocks();
                }
            }
        }
        //Update and draw
        public void Update()
        {
            if (attackCooldown > 0) attackCooldown--;
            state.Update();

            if (hurtCooldown > hurtCooldownLimit - 10)
            {
                --hurtCooldown;
                HurtRecoil();
            }
            else if (hurtCooldown > 0) --hurtCooldown;
            else enemyCollisionSide = ICollision.SideNone;

            if (HasClock && clockCooldown > 0) clockCooldown--;
            else if (clockCooldown == 0) HasClock = false;

            if (state.checkDamaged() && hurtCooldown == 0) state.ToDamaged();
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            state.Draw(spriteBatch, scale);
        }
    }
}
