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
        Color color = new Color();
        public float maxparticlespeed = 0.2f;

        public Vector2 startingpos = new Vector2(0.5f, 0.95f);
        private Vector2 currentpos;
        public Vector2 acceleration = new Vector2(0.0f, -0.75f);
        public Vector2 velocity;
        Random random = new Random();
        private float particleminsize = 0.09f;
        private float particlemaxsize = 0.5f;
        private float timetolive;
        private float lifepercentage;
        private float timehaslived;

        private float randrotation;
        private float particlesize;
        private float rotation;
        private float fade;



        public Smokeparticle(Texture2D spark, Random _random,float lifetime) //Creates the random direction and speed
        {
            random = _random;
            timetolive = lifetime;
            Spawnnewparticle();
            randrotation = 0.01f * ((float)random.NextDouble() - (float)random.NextDouble());
        }

        public void Spawnnewparticle()
        {
            particlesize = particleminsize;
            timehaslived = 0;
            currentpos = startingpos;
            rotation = 0;
            fade = 0.8f;
            color = new Color(fade, fade, fade, fade);
            randomdirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
            randomdirection.Normalize();

            randomdirection = randomdirection * ((float)random.NextDouble() * maxparticlespeed);
            velocity = randomdirection;
 
        }

        public bool islifeover()
        {
            if(timehaslived >= timetolive)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            color = new Color(fade, fade, fade, fade);
        }

        public void Draw(SpriteBatch spritebatch, Camera camera, Texture2D smokecloud)
        {
            float scale = camera.Scale(smokecloud,particlesize);
            //Coursepress
            //color fades to 0
            spritebatch.Draw(smokecloud, camera.Converttovisualcoords(currentpos, smokecloud), null, color, rotation, randomdirection, scale, SpriteEffects.None, 0);


        }
    }
}
