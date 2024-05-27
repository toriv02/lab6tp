using lab6net6.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6net6.Objects
{
    internal class Paint : IImpactPoint
    {
        public bool isVisible = true;//отображение краски
        public int R = 76;//радиус куга
        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.DarkGray); // конечный цвет частиц
        public override void ImpactParticle(ParticleColorful particle)
        {
            if (!isVisible)
            {
                // сделаем сначала для одной точки
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
                if (r + particle.Radius < R / 2) // если частица оказалось внутри окружности
                {
                    particle.FromColor = ColorFrom;//меняем цвет частицы
                    particle.ToColor = ColorTo;
                }
            }
        }
        
        public override void Render(Graphics canvas)
        {
            if (!isVisible)
            {
                // буду рисовать окружность с диаметром равным R
                canvas.DrawEllipse(
                       new Pen(ColorFrom,4),
                       X - R / 2,
                       Y - R / 2,
                       R,
                       R
                   );
            }
        }
        public override bool Target(float tX, float tY)
        {
            if (!isVisible)
            {
                float gX = X - tX;
                float gY = Y - tY;
                double r = Math.Sqrt(gX * gX + gY * gY);
                if (r + 5 < R / 2) return true;
            }
            return false;
        }
    }
}
