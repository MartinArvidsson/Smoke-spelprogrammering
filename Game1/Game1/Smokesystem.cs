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
        private List<Smokeparticle> particles = new List<Smokeparticle>();
        private int numberofsmokes = 300;
        private int lifetimeofsmoke = 3;
        private static Random rand = new Random();
        private Texture2D smoke;

        public Smokesystem(Texture2D smokeTexture)
        {
            smoke = smokeTexture;
        }

        public void addnewsmoke()
        {
            if(particles.Count < numberofsmokes)
            {
                particles.Add(new Smokeparticle(smoke,rand,lifetimeofsmoke));
            }
        }

        public void Update(float elapsedtime)
        {
            if(elapsedtime >= (float)lifetimeofsmoke /(float)numberofsmokes)
            {
                addnewsmoke();
            }
            foreach(Smokeparticle particle in particles)
            {
                particle.Updateposition(elapsedtime);
                if(particle.islifeover())
                {
                    particle.Spawnnewparticle();
                }
            }
        }
        public void Draw(SpriteBatch spritebatch, Camera camera,Texture2D smokecloud)
        {
            spritebatch.Begin();

            foreach (Smokeparticle smoke in particles) 
            {
                smoke.Draw(spritebatch, camera, smokecloud);
            }
            spritebatch.End();
        }
    }
}
