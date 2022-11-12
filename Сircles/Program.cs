using System;
using SFML.Learning;
using SFML.Window;
using SFML.System;
using SFML.Graphics;

namespace Сircles
{
    internal class Program : Game
    {
        static string click_space = LoadSound("click.wav");
        static string lose = LoadSound("lose.wav");
        static string music = LoadMusic("contra.wav");

        static float radius_first_circle = 200;//радиус красного круга
        static float radius_second_circle = 1;// радиус зеленого круга

        static float record = 0;
        static float points = 0;
        static float sum_points = 0;
        static float previous_result = 0; // предыдущий результат
        static float speed = 1;


        static void Main(string[] args)
        {
            InitWindow(800, 600);

            SetFont("Comic Sans MS.ttf");

            PlayMusic(music, 10);

            while (true)
            {
                DispatchEvents();

                ClearWindow();

                SetFillColor(150, 0, 0);
                FillCircle(590, 250, radius_first_circle);

                SetFillColor(167, 252, 0);
                FillCircle(590, 250, radius_second_circle);

                if (radius_second_circle < radius_first_circle)
                {
                    radius_second_circle += speed;

                }

                if (radius_second_circle >= radius_first_circle)
                {
                    radius_second_circle = 1;
                }

                points = (radius_second_circle * 100) / radius_first_circle + sum_points;

                if (GetKeyDown(Keyboard.Key.Space))
                {
                    PlaySound(click_space, 50);
                    radius_first_circle = radius_second_circle;
                    radius_second_circle = 1;
                    speed += 0.2f;
                    sum_points += points;

                }

                if (radius_first_circle < 30)
                {
                    PlaySound(lose, 50);
                    radius_first_circle = 200;
                    previous_result = sum_points;
                    if (record < sum_points)
                    {
                        record = sum_points;
                    }
                    sum_points = 0;
                    points = 0;
                    speed = 1;
                }

                SetFillColor(Color.White);
                DrawText(100, 10, "Инструкция", 20);
                DrawText(30, 40, "Набери как можно больше очков!", 20);
                DrawText(30, 70, "Остановить зеленый круг: ПРОБЕЛ", 20);
                DrawText(20, 100, "После каждого нажатия на пробел,", 15);
                DrawText(20, 120, "скорость заполнения зеленого круга увеличивается,", 15);
                DrawText(20, 140, "красный круг уменьшается по размеру зеленого", 15);
                DrawText(20, 450, "Максимальный результат: " + Convert.ToInt32(record), 30);
                DrawText(20, 500, "Ваш предыдущий результат: " + Convert.ToInt32(previous_result), 30);
                DrawText(20, 550, "Очки: " + Convert.ToInt32(points), 30);

                DisplayWindow();
                Delay(1);
            }
        }
    }
}
