using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Sounds
{
    class SoundController
    {
        private Song music;
        private SoundEffect openDoor, boomerang, getItem;
        private SoundEffectInstance boomerangInstance;
        private static readonly SoundController instance = new SoundController(); 
        public static SoundController Instance => instance;

        private SoundController() { }

        public void LoadAllSounds(ContentManager content)
        {
            music = content.Load<Song>("Sounds/dungeonMusic");
            openDoor = content.Load<SoundEffect>("Sounds/openDoor");
            boomerang = content.Load<SoundEffect>("Sounds/boomerang");
            getItem = content.Load<SoundEffect>("Sounds/getItem");

        }
        public void StartMusic()
        {
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
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
    }
}
