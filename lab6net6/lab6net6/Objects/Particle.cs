using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6net6.Objects
{
    public class Particle
    {
        public int Radius;
        public float X;
        public float Y;
        /*public float Direction;// направление движения
        public float Speed;*/
        public float SpeedX;// скорость перемещения по оси X
        public float SpeedY;// скорость перемещения по оси Y
        public float Life;
        public static Random rand = new Random();
        public Particle()
        {
           
        }
        public virtual void Draw(Graphics canvas)
        {
            // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);
            // рассчитываем значение альфа канала в шкале от 0 до 255
            // по аналогии с RGB, он используется для задания прозрачности
            int alpha = (int)(k * 255);
            // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
            var color = Color.FromArgb(alpha, ColorTranslator.FromHtml("#43e86f"));
            var brush = new SolidBrush(color);
            // нарисовали залитый кружок радиусом Radius с центром в X, Y
            canvas.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            // удалили кисть из памяти, вообще сборщик мусора рано или поздно это сам сделает
            // но документация рекомендует делать это самому
            brush.Dispose();
        }
    }
    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }
        public override void Draw(Graphics canvas)
        {
            // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);
            // так как k уменьшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var brush = new SolidBrush(color);
            // нарисовали залитый кружок радиусом Radius с центром в X, Y
            canvas.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            // удалили кисть из памяти, вообще сборщик мусора рано или поздно это сам сделает
            // но документация рекомендует делать это самому
            brush.Dispose();
        }
    }
}
