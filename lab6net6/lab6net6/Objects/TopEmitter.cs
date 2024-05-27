using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6net6.Objects
{
    public class TopEmitter : Emitter
    {
        public int Width;// длина экрана
        public override void ResetParticle(ParticleColorful particle)
        {
            base.ResetParticle(particle);
            // а теперь тут уже подкручиваем параметры движения
            particle.X=Particle.rand.Next(Width);
            particle.Y = 0;
            particle.SpeedY = 1;
            particle.SpeedX = Particle.rand.Next(-2, 2);// разброс влево и вправа у частиц
        }

    }
}
