using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Sounds
{
    class SoundController
    {
        private Song music;
        private SoundEffect openDoor, boomerang, getItem, getRupee, getTriforce, linkGetsHurt, useFire, placeAndExplodeBomb, 
            swordBeam, getHeart, bossRoar;
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
            placeAndExplodeBomb = content.Load<SoundEffect>("Sounds/ItemSounds/placeAndExplodeBomb");
            swordBeam = content.Load<SoundEffect>("Sounds/ItemSounds/useSwordBeam");
            getHeart = content.Load<SoundEffect>("Sounds/ItemSounds/getHeart");
            bossRoar = content.Load<SoundEffect>("Sounds/EnemySounds/bossRoar");
        }
        public void StartDungeonMusic()
        {
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayGetTriforceMusic()
        {
            MediaPlayer.Stop();
            getTriforce.Play();
        }
        public void PlayBossRoarSound() { bossRoar.Play(); }
        public void PlayGetHeartSound() { getHeart.Play(); }
        public void PlayLinkGetsHurtSound() { linkGetsHurt.Play(); }
        public void PlaySwordBeamSound() { swordBeam.Play(); }
        public void PlayBombSound() { placeAndExplodeBomb.Play(); }
        public void PlayOpenDoorSound() { openDoor.Play(); }
        public void StartBoomerangSound()
        {
            boomerangInstance = boomerang.CreateInstance();
            boomerangInstance.IsLooped = true;
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
            useFireInstance.Play();
        }
        public void StopFireSound() { useFireInstance.Stop(); }
        public void PlayGetItemSound() { getItem.Play(); }
        public void PlayGetRupeeSound() { getRupee.Play(); }
    }
}
