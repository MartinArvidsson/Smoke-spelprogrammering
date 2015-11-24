using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Smokesystem
    {
         private int numberofsmokes = 10;

        public Smokeparticle[] smokes;
        private static Random rand = new Random();

        public Smokesystem(Texture2D smoke)
        {
            smokes = new Smokeparticle[numberofsmokes];
            for (int i = 0; i < smokes.Length; i++)
            {
                smokes[i] = new Smokeparticle(smoke, rand);
            }
        }

        public void Draw(SpriteBatch spritebatch, Camera camera,Texture2D smokecloud)
        {
            spritebatch.Begin();

            foreach (Smokeparticle smoke in smokes) 
            {
                smoke.Draw(spritebatch, camera, smokecloud);
            }
            spritebatch.End();
        }
    }
}
