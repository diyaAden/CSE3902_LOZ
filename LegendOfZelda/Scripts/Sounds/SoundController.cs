using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Sounds
{
    class SoundController
    {
        private const float gameVolume = 0.25f;
        private Song music;
        private SoundEffect openDoor, boomerang, getItem, getRupee, getTriforce, linkGetsHurt, useFire, placeBomb, 
            swordBeam, getHeart, bossRoar, findSecret, useStairs, bombExplosion;
        private SoundEffectInstance boomerangInstance, useFireInstance;
        private static readonly SoundController instance = new SoundController(); 
        public static SoundController Instance => instance;

        private SoundController() { }

        public void LoadAllSounds(ContentManager content)
        {
            music = content.Load<Song>("Sounds/Music/dungeonMusic");
            getTriforce = content.Load<SoundEffect>("Sounds/ItemSounds/getTriforce");
            openDoor = content.Load<SoundEffect>("Sounds/Environment/openDoor");
            boomerang = content.Load<SoundEffect>("Sounds/ItemSounds/boomerang");
            getItem = content.Load<SoundEffect>("Sounds/ItemSounds/getItem");
            getRupee = content.Load<SoundEffect>("Sounds/ItemSounds/getRupee");
            linkGetsHurt = content.Load<SoundEffect>("Sounds/LinkSounds/playerGetsHurt");
            useFire = content.Load<SoundEffect>("Sounds/ItemSounds/useFire");
            placeBomb = content.Load<SoundEffect>("Sounds/ItemSounds/placeBomb");
            bombExplosion = content.Load<SoundEffect>("Sounds/ItemSounds/explodeBomb");
            swordBeam = content.Load<SoundEffect>("Sounds/ItemSounds/useSwordBeam");
            getHeart = content.Load<SoundEffect>("Sounds/ItemSounds/getHeart");
            bossRoar = content.Load<SoundEffect>("Sounds/EnemySounds/bossRoar");
            findSecret = content.Load<SoundEffect>("Sounds/Environment/findSecret");
            useStairs = content.Load<SoundEffect>("Sounds/Environment/useStairs");
        }
        public void StartDungeonMusic()
        {
            MediaPlayer.Volume = gameVolume;
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayGetTriforceMusic()
        {
            MediaPlayer.Stop();
            SoundEffectInstance triforce = getTriforce.CreateInstance();
            triforce.Volume = gameVolume;
            triforce.Play();
        }
        public void PlayFindSecretSound() {
            SoundEffectInstance secret = findSecret.CreateInstance();
            secret.Volume = gameVolume * 0.25f;
            secret.Play();
        }
        public void PlayBossRoarSound() {
            SoundEffectInstance roar = bossRoar.CreateInstance();
            roar.Volume = gameVolume * 0.15f;
            roar.Play();
        }
        public void PlayGetHeartSound() { 
            SoundEffectInstance getHeartInstance = getHeart.CreateInstance();
            getHeartInstance.Volume = gameVolume * 0.5f;
            getHeartInstance.Play();
        }
        public void PlayLinkGetsHurtSound() {
            SoundEffectInstance hurt = linkGetsHurt.CreateInstance();
            hurt.Volume = gameVolume * 0.1f;
            hurt.Play();
        }
        public void PlaySwordBeamSound()
        {
            SoundEffectInstance beam = swordBeam.CreateInstance();
            beam.Volume = gameVolume * 0.5f;
            beam.Play();
        }
        public void PlayPlaceBombSound() {
            SoundEffectInstance bomb = placeBomb.CreateInstance();
            bomb.Volume = gameVolume * 0.5f;
            bomb.Play();
        }
        public void PlayExplodeBombSound()
        {
            SoundEffectInstance explosion = bombExplosion.CreateInstance();
            explosion.Volume = gameVolume * 0.5f;
            explosion.Play();
        }
        public void PlayOpenDoorSound() { 
            SoundEffectInstance door = openDoor.CreateInstance();
            door.Volume = gameVolume * 0.25f;
            door.Play();
        }
        public void StartBoomerangSound()
        {
            boomerangInstance = boomerang.CreateInstance();
            boomerangInstance.IsLooped = true;
            boomerangInstance.Volume = gameVolume * 0.25f;
            boomerangInstance.Play();
        }
        public void StopBoomerangSound()
        { 
            if (boomerangInstance != null) boomerangInstance.Stop();
            boomerangInstance = null;
        }
        public void StartFireSound()
        {
            useFireInstance = useFire.CreateInstance();
            useFireInstance.IsLooped = true;
            useFireInstance.Volume = gameVolume * 0.25f;
            useFireInstance.Play();
        }
        public void StopFireSound()
        {
            if (useFireInstance != null) useFireInstance.Stop();
            useFireInstance = null;
        }
        public void PlayGetItemSound() { 
            SoundEffectInstance getItemInstance = getItem.CreateInstance();
            getItemInstance.Volume = gameVolume * 0.25f;
            getItemInstance.Play();
        }
        public void PlayGetRupeeSound() {
            SoundEffectInstance getRupeeInstance = getRupee.CreateInstance();
            getRupeeInstance.Volume = gameVolume * 0.5f;
            getRupeeInstance.Play();
        }
        public void PlayUseStairsSound() { 
            SoundEffectInstance stairs = useStairs.CreateInstance();
            stairs.Volume = gameVolume * 0.5f;
            stairs.Play();
        }
    }
}
