using lab6net6.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6net6.Objects
{
    public class AntiGravityPoint:IImpactPoint
    {
        public int Power = 0;//сила антигравитона
        public Color color = Color.DarkOrange;//цвет антигравитона
        public override void ImpactParticle(ParticleColorful particle)
        {
            // сделаем сначала для одной точки
            // и так считаем вектор притяжения к точке
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            // пересчитываем вектор скорости с учетом отталкивания от точке
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                // то отталкиваем её
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX -= gX * Power / r2;
                particle.SpeedY -= gY * Power / r2;
            }
        }
        public override void Render(Graphics canvas)
        {
            // буду рисовать окружность с диаметром равным Power
            canvas.DrawEllipse(
                   new Pen(color),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
            if (Power > 0)//если окружности нет то не рисую текст
            {
                var stringFormat = new StringFormat(); // создаем экземпляр класса
                stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
                stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали
                var text = $"{Power}";
                var font = new Font("Verdana", 10);
                // рисуем подложнку под текст
                canvas.DrawString(
                    text,
                    font,
                    new SolidBrush(Color.White),
                    X,
                    Y,
                    stringFormat
                );
            }
        }
        public override bool Target(float tX, float tY)//проверка пересечение с курсором
        {
            float gX = X - tX;
            float gY = Y - tY;
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + 5 < Power / 2) return true; 
            return false;
        }


       
    }
}
