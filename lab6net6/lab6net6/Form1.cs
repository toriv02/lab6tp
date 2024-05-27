using lab6net6.Objects;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace lab6net6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();//������ ��������
        List<IImpactPoint> points = new List<IImpactPoint>();//������ �����
        List<Paint> paints = new List<Paint>();//������ ������
        Emitter emitter;//������
        GravityPoint gravPoint1; // ������� ���� ��� ������ �����
        GravityPoint gravPoint2; // ������� ���� ��� ������ �����
        AntiGravityPoint antigravPoint;//���� ��� ������������
        IImpactPoint target = null;//���� ��� �������������� ����� �������������� � ��������
        bool targetisEmitter = false;//���� ��� �������������� ������� � ��������
        int curentEmitter = 0;//��������� ��������
        Paint curentpaint;//������� ������ ��� �������������� � ��������
        public Form1()
        {
            InitializeComponent();
            // �������� �����������
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // ������ ������� � ���������� ��� � ���� emitter
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
            emitters.Add(this.emitter);// ��� ����� �������� � ������ emitters, ����� �� ���������� � ����������
            //������ ������� ������
            TopEmitter topemitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            emitters.Add(topemitter);
            //������ ���������
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
            //������ ������������
            points.Add(gravPoint2);
            antigravPoint = new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 4,
            };
            points.Add(antigravPoint);

            //������ � �������� ������
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
            // ����������� ���� � ��������
            foreach (var curr in emitters)
            {
                foreach (var point in points)
                    curr.impactPoints.Add(point);
                foreach (var paint in paints)
                    curr.impactPoints.Add(paint);
            }
            curentpaint = null;//������� ������� ������ ��� ����������� �������������� � ��������
        }
        private void timer1_Tick(object sender, EventArgs e)//������ ��� ������� ���������
        {
            emitters[curentEmitter].UpdateState();//������������ ��������� ������
            using (var canvas = Graphics.FromImage(picDisplay.Image))
            {
                canvas.Clear(Color.Black);
                emitters[curentEmitter].Render(canvas);
            }
            picDisplay.Invalidate();//����������� �����������
        }


        private void picDisplay_MouseMove(object sender, MouseEventArgs e)//����������� �������� ������� �� ������
        {
            // � ��� �������� ��������� ����, � ��������� �������
            if (targetisEmitter)
            {
                emitter.X = e.X;
                emitter.Y = e.Y;
            }
            else if (!(target is null))//� ��� � ��������� ��������� ����� ��������������
            {
                target.X = e.X;
                target.Y = e.Y;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)//����� ����������� ��������
        {
            foreach (var curr in emitters)
            {
                curr.Direction = tbDirection.Value;// ����������� �������� ����������� �������� �������� 
            }
            lblDirection.Text = $"�����������: {tbDirection.Value}�";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)//����� ���� ������� ���������
        {
            gravPoint1.Power = tbGraviton1.Value;//��������� ��������
            lblGraviton1.Text = $"���� ����������: {tbGraviton1.Value}";//������� �������� �� �����
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)//����� ���� ������� ���������
        {
            gravPoint2.Power = tbGraviton2.Value;
            lblGraviton2.Text = $"���� ����������: {tbGraviton2.Value}";
        }

        private void tbAntiGrav_Scroll(object sender, EventArgs e)//����� ���� ������������� ���������
        {
            antigravPoint.Power = tbAntiGrav.Value;
            lblAntiGrav.Text = $"���� ��������������: {tbAntiGrav.Value}";
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)//��� ������� �� �����
        {
            if (target is null)//���� ������� ���� �� ������� � ��� ������������ ������
            {
                if (emitter.Target(e.X, e.Y)) targetisEmitter = !targetisEmitter;//���� ����������� � ��������� �� ������ ����
                else
                {
                    foreach (var point in points)//�������� ����������� � ������ ��������������
                    {
                        if (point.Target(e.X, e.Y))
                        {
                            target = point;
                            break;
                        }
                    }
                    if (target is null)
                    {
                        foreach (var paint in paints)//�������� ����������� � �������
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
            else//�������� ������ ��� �������� ��������� �������
            {
                target = null;
            }
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)//������ ������� ��������
        {
            foreach (var curr in emitters)
            {
                curr.Spreading = tbSpreading.Value;// �������� �������� ����������� �������� �������� 
            }
            lblSpreading.Text = $"�������������: {tbSpreading.Value}�";
        }

        private void PaintCB_CheckedChanged(object sender, EventArgs e)//�������� ����������� ������ �� �����
        {
            foreach (var paint in paints)
            {
                paint.isVisible = !paint.isVisible;
            }
        }

        private void EmiterCB_CheckedChanged(object sender, EventArgs e)//������ ��������� �������
        {
            curentEmitter = (curentEmitter == 0) ? 1 : 0;
        }

    }
}
