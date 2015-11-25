using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Smokeparticle
    {
        public Vector2 randomdirection;
        public float maxparticlespeed = 0.3f;

        public Vector2 startingpos = new Vector2(0.5f, 0.95f);
        private Vector2 currentpos;
        public Vector2 acceleration = new Vector2(0.0f, -0.75f);
        public Vector2 velocity;
        
        private float particleminsize = 0.09f;
        private float particlemaxsize = 0.5f;
        private float timetolive = 5f;
        private float lifepercentage;
        private float timehaslived;
        private float randrotation;
        private float particlesize;
        private float rotation;
        private float fade;



        public Smokeparticle(Texture2D spark, Random random) //Creates the random direction and speed
        {
            Spawnnewparticle();
            Getrandomdirection(random);
            randrotation = 0.1f * ((float)random.NextDouble() - (float)random.NextDouble());
        }

        private void Spawnnewparticle()
        {
            particlesize = particleminsize;
            timehaslived = 0;
            currentpos = startingpos;
            rotation = 0;
            fade = 1f;
        }

        private void Getrandomdirection(Random random)
        {
            randomdirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
            randomdirection.Normalize();

            randomdirection = randomdirection * ((float)random.NextDouble() * maxparticlespeed);
            velocity = randomdirection;
        }

        public void Updateposition(float elapsedtime)
        {
            rotation += randrotation;
            fade -= elapsedtime / timetolive;
            //Coursepress https://coursepress.lnu.se/kurs/grundlaggande-spelprogrammering/laborationsoversikt/laboration-2-simuleringar-och-partiklar/
            timehaslived += elapsedtime;
            lifepercentage = timehaslived / timetolive;
            particlesize = particleminsize + lifepercentage * particlemaxsize;

            velocity = elapsedtime * acceleration + velocity;
            currentpos = elapsedtime * velocity + currentpos;
        }

        public void Draw(SpriteBatch spritebatch, Camera camera, Texture2D smokecloud)
        {
            float scale = camera.Scale(smokecloud,particlesize);
            //Coursepress
            //color fades to 0
            Color color = new Color(fade, fade, fade, fade);
            spritebatch.Draw(smokecloud, camera.Converttovisualcoords(currentpos, smokecloud), null, Color.White, rotation, randomdirection, scale, SpriteEffects.None, 0);


        }
    }
}
