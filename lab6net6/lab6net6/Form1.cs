using lab6net6.Objects;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace lab6net6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();//список емиторов
        List<IImpactPoint> points = new List<IImpactPoint>();//список точек
        List<Paint> paints = new List<Paint>();//список красок
        Emitter emitter;//емитор
        GravityPoint gravPoint1; // добавил поле под первую точку
        GravityPoint gravPoint2; // добавил поле под вторую точку
        AntiGravityPoint antigravPoint;//поле под антигравитон
        IImpactPoint target = null;//поле для взаимодействия точек взаимодействия с курсором
        bool targetisEmitter = false;//поле для взаимодействия емитора с курсором
        int curentEmitter = 0;//изменения емиттора
        Paint curentpaint;//текущая краска для взаимодействия с курсором
        public Form1()
        {
            InitializeComponent();
            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Magenta),
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            emitters.Add(this.emitter);// все равно добавляю в список emitters, чтобы он рендерился и обновлялся
            //создаю верхний эмитер
            TopEmitter topemitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            emitters.Add(topemitter);
            //создаю гравитоны
            gravPoint1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            points.Add(gravPoint1);
            gravPoint2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };
            //создаю антигравитон
            points.Add(gravPoint2);
            antigravPoint = new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 4,
            };
            points.Add(antigravPoint);

            //создаю и добавляю краски
            curentpaint = new Paint
            {
                X = picDisplay.Width / 2 - 300,
                Y = picDisplay.Height / 2 - 100,
            };
            curentpaint.ColorFrom = Color.Purple;
            curentpaint.ColorTo = Color.MediumPurple;
            paints.Add(curentpaint);

            curentpaint = new Paint
            {
                X = picDisplay.Width / 2 - 200,
                Y = picDisplay.Height / 2 - 50,
            };
            curentpaint.ColorFrom = Color.Pink;
            curentpaint.ColorTo = Color.LightPink;
            paints.Add(curentpaint);

            curentpaint = new Paint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2 - 20,
            };
            curentpaint.ColorFrom = Color.Orange;
            curentpaint.ColorTo = Color.DarkOrange;
            paints.Add(curentpaint);

            curentpaint = new Paint
            {
                X = picDisplay.Width / 2 + 300,
                Y = picDisplay.Height / 2 - 100,
            };
            curentpaint.ColorFrom = Color.Blue;
            curentpaint.ColorTo = Color.DarkBlue;
            paints.Add(curentpaint);

            curentpaint = new Paint
            {
                X = picDisplay.Width / 2 + 200,
                Y = picDisplay.Height / 2 - 50,
            };
            curentpaint.ColorFrom = Color.White;
            curentpaint.ColorTo = Color.DarkGray;
            paints.Add(curentpaint);

            curentpaint = new Paint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2 - 20,
            };
            curentpaint.ColorFrom = Color.Yellow;
            curentpaint.ColorTo = Color.Gold;
            curentpaint = new Paint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            curentpaint.ColorFrom = Color.LightGreen;
            curentpaint.ColorTo = Color.Green;
            paints.Add(curentpaint);
            // привязываем поля к эмиттеру
            foreach (var curr in emitters)
            {
                foreach (var point in points)
                    curr.impactPoints.Add(point);
                foreach (var paint in paints)
                    curr.impactPoints.Add(paint);
            }
            curentpaint = null;//зануляю текущую краску для дальнейшего взаимодействия с курсором
        }
        private void timer1_Tick(object sender, EventArgs e)//каждый тик таймера выполняем
        {
            emitters[curentEmitter].UpdateState();//обрабатываем выбранный эмитор
            using (var canvas = Graphics.FromImage(picDisplay.Image))
            {
                canvas.Clear(Color.Black);
                emitters[curentEmitter].Render(canvas);
            }
            picDisplay.Invalidate();//перерисовка изображения
        }


        private void picDisplay_MouseMove(object sender, MouseEventArgs e)//отслеживаем движение курсора на экране
        {
            // а тут передаем положение мыши, в положение эмитора
            if (targetisEmitter)
            {
                emitter.X = e.X;
                emitter.Y = e.Y;
            }
            else if (!(target is null))//а тут в положение выбранной точки взаимодействия
            {
                target.X = e.X;
                target.Y = e.Y;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)//выбор направление емиттора
        {
            foreach (var curr in emitters)
            {
                curr.Direction = tbDirection.Value;// направлению эмиттера присваиваем значение ползунка 
            }
            lblDirection.Text = $"Направление: {tbDirection.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)//выбор силы первого гравитона
        {
            gravPoint1.Power = tbGraviton1.Value;//считываем значение
            lblGraviton1.Text = $"Сила гравитонов: {tbGraviton1.Value}";//выводим значение на форму
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)//выбор силы второго гравитона
        {
            gravPoint2.Power = tbGraviton2.Value;
            lblGraviton2.Text = $"Сила гравитонов: {tbGraviton2.Value}";
        }

        private void tbAntiGrav_Scroll(object sender, EventArgs e)//выбор силы антигравитона гравитона
        {
            antigravPoint.Power = tbAntiGrav.Value;
            lblAntiGrav.Text = $"Сила антигравитонов: {tbAntiGrav.Value}";
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)//при нажатии на форму
        {
            if (target is null)//если ттаргет пуст то смотрим с чем пересекается курсор
            {
                if (emitter.Target(e.X, e.Y)) targetisEmitter = !targetisEmitter;//если пересеклись с эмиттором то меняем флаг
                else
                {
                    foreach (var point in points)//проверка пересечения с точкой взаимодействия
                    {
                        if (point.Target(e.X, e.Y))
                        {
                            target = point;
                            break;
                        }
                    }
                    if (target is null)
                    {
                        foreach (var paint in paints)//проверка пересечения с краской
                        {
                            if (paint.Target(e.X, e.Y))
                            {
                                target = paint;
                                break;
                            }
                        }
                    }
                }
            }
            else//зануляем таргет для фиксации положения объекта
            {
                target = null;
            }
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)//меняем разброс эмиттера
        {
            foreach (var curr in emitters)
            {
                curr.Spreading = tbSpreading.Value;// разбросу эмиттера присваиваем значение ползунка 
            }
            lblSpreading.Text = $"Распределение: {tbSpreading.Value}°";
        }

        private void PaintCB_CheckedChanged(object sender, EventArgs e)//включаем отображение краско на форму
        {
            foreach (var paint in paints)
            {
                paint.isVisible = !paint.isVisible;
            }
        }

        private void EmiterCB_CheckedChanged(object sender, EventArgs e)//меняем выбранный эмиттер
        {
            curentEmitter = (curentEmitter == 0) ? 1 : 0;
        }

    }
}
