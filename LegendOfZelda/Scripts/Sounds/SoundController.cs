using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Sounds
{
    class SoundController
    {
        private Song music;
        private SoundEffect openDoor, boomerang, getItem, getRupee, getTriforce;
        private SoundEffectInstance boomerangInstance;
        private static readonly SoundController instance = new SoundController(); 
        public static SoundController Instance => instance;

        private SoundController() { }

        public void LoadAllSounds(ContentManager content)
        {
            music = content.Load<Song>("Sounds/dungeonMusic");
            getTriforce = content.Load<SoundEffect>("Sounds/getTriforce");
            openDoor = content.Load<SoundEffect>("Sounds/openDoor");
            boomerang = content.Load<SoundEffect>("Sounds/boomerang");
            getItem = content.Load<SoundEffect>("Sounds/getItem");
            getRupee = content.Load<SoundEffect>("Sounds/getRupee");
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
        public void PlayOpenDoorSound()
        {
            openDoor.Play();
        }
        public void StartBoomerangSound()
        {
            boomerangInstance = boomerang.CreateInstance();
            boomerangInstance.IsLooped = true;
            boomerangInstance.Play();
        }
        public void StopBoomerangSound()
        {
            boomerangInstance.Stop();
        }
        public void PlayGetItemSound()
        {
            getItem.Play();
        }
        public void PlayGetRupeeSound()
        {
            getRupee.Play();
        }
    }
}
