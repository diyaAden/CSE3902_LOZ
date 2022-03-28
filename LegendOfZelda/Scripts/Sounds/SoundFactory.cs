using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZelda.Scripts.Blocks
{
    class SoundFactory
    {
        private Song music;
        private static readonly SoundFactory instance = new SoundFactory(); 
        public static SoundFactory Instance => instance;

        private SoundFactory() { }

        public void LoadAllSounds(ContentManager content)
        {
            music = content.Load<Song>("Sounds/dungeonMusic");

        }
        public void StartMusic()
        {
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
        }
    }
}
