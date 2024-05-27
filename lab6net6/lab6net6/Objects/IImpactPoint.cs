using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6net6.Objects
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        // абстрактный метод с помощью которого будем изменять состояние частиц
        public abstract void ImpactParticle(ParticleColorful particle);
        public virtual void Render(Graphics canvas)
        {
            // нарисовали залитый кружок радиусом Radius с центром в X, Y
            canvas.FillEllipse(new SolidBrush(Color.MediumPurple), X - 5, Y - 5, 10, 10);
        }
        public abstract bool Target(float tX, float tY);//абстрактный метод для пересеченимя с курсором
    }
}
