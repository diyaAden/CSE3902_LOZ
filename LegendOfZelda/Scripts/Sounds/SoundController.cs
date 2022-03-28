using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Sounds
{
    class SoundController
    {
        private Song music;
        private SoundEffect openDoor, magicBoomerang;
        private SoundEffectInstance magicBoom;
        private static readonly SoundController instance = new SoundController(); 
        public static SoundController Instance => instance;

        private SoundController() { }

        public void LoadAllSounds(ContentManager content)
        {
            music = content.Load<Song>("Sounds/dungeonMusic");
            openDoor = content.Load<SoundEffect>("Sounds/openDoor");
            magicBoomerang = content.Load<SoundEffect>("Sounds/magicBoomerang");

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
        public void StartMagicBoomerangSound()
        {
            magicBoom = magicBoomerang.CreateInstance();
            magicBoom.IsLooped = true;
            magicBoom.Play();
        }
        public void StopMagicBoomerangSound()
        {
            magicBoom.Stop();
        }
    }
}
