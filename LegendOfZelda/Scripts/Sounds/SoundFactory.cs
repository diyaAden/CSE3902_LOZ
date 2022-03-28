using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Blocks
{
    class SoundFactory
    {
        private Song music;
        private SoundEffect openDoor;
        private static readonly SoundFactory instance = new SoundFactory(); 
        public static SoundFactory Instance => instance;

        private SoundFactory() { }

        public void LoadAllSounds(ContentManager content)
        {
            music = content.Load<Song>("Sounds/dungeonMusic");
            openDoor = content.Load<SoundEffect>("Sounds/openDoor");

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
    }
}
