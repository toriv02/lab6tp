using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6net6.Objects
{
    public class Emitter
    {
        List<ParticleColorful> particles = new List<ParticleColorful>();
        public int X = 0;
        public int Y = 0;

        public int ParticlesCount = 643;//кол-во генерируемых частиц
        public int ParticlesPerTick = 6;//кол-во частиц в такт
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // тут буду хранится точки притяжения
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.DarkGray); // конечный цвет частиц

        public float GravitationX = 0;//гравитация по оси Y
        public float GravitationY = 1;// пусть гравитация будет силой один пиксель за такт

        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;// фиксируем счетчик сколько частиц нам создавать за тик
            foreach (var particle in particles)//пробегаем все чаицы
            {
                if (particle.Life <= 0)// если частицы умерла
                {
                    /* 
                     * то проверяем надо ли создать частицу
                     */
                    if (particlesToCreate-- > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы
                         * поэтому уменьшаем счётчик созданных частиц на 1 
                         */
                        ResetParticle(particle);
                    }
                   
                }
                else
                {
                    particle.X += particle.SpeedX;//измеяем положение частицы по осям 
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;//сокращаем жизнь чатстице 
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);//передаём чатицу в точки контакта
                    }
                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                    // так как теперь мы храним вектор скорости в явном виде и его не надо пересчитывать
                    
                }
            }
            // добавил генерацию частиц
            // второй цикл while, 
            // этот новый цикл также будет срабатывать только в самом начале работы эмиттера
            // собственно пока не накопится критическая масса частиц
            while (particlesToCreate-- >=1) {
                var particle = CreateParticle();//создаём частицу
                ResetParticle(particle);
                particles.Add(particle);
            }

                
        }

        public void Render(Graphics canvas)//отрисовывем частицы и точки контакта
        {
            foreach (var particle in particles)
            {
                particle.Draw(canvas);
            }
            foreach (var point in impactPoints)
            {
                point.Render(canvas);
            }
          
        }
        // добавил новый метод, виртуальным, чтобы переопределять можно было в нём обновляю частицу
        public virtual void ResetParticle(ParticleColorful particle)//обновляем поля чатицы
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2; // Направление
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
        public virtual ParticleColorful CreateParticle()//задаём цвет частице
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        public bool Target(float tX, float tY)//проверяем пересечение с курсором
        {
            float gX = X - tX;
            float gY = Y - tY;
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + 5 < 20 / 2) return true;
            return false;
        }

    }
}
