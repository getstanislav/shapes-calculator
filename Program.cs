using System;
using System.Collections.Generic;

namespace ShapesSystem
{
    public interface IShape
    {
        double CalculateArea();
        void DisplayInfo();
    }

    public class Triangle : IShape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public double CalculateArea()
        {
            return (BaseLength * Height) / 2;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\nТрикутник:");
            Console.WriteLine($"Основа: {BaseLength}");
            Console.WriteLine($"Висота: {Height}");
            Console.WriteLine($"Площа: {CalculateArea()}");
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\nПрямокутник:");
            Console.WriteLine($"Ширина: {Width}");
            Console.WriteLine($"Висота: {Height}");
            Console.WriteLine($"Площа: {CalculateArea()}");
        }
    }

    public class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double CalculateArea()
        {
            return Side * Side;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\nКвадрат:");
            Console.WriteLine($"Сторона: {Side}");
            Console.WriteLine($"Площа: {CalculateArea()}");
        }
    }

    public class Menu
    {
        private List<IShape> shapes;

        public Menu()
        {
            shapes = new List<IShape>();
        }

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;

            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateTriangle();
                        break;
                    case "2":
                        CreateRectangle();
                        break;
                    case "3":
                        CreateSquare();
                        break;
                    case "4":
                        ViewAllShapes();
                        break;
                    case "5":
                        ViewTotalArea();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("\nДо побачення!");
                        break;
                    default:
                        Console.WriteLine("\nНевірний вибір!");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("     МЕНЮ ФІГУР");
            Console.WriteLine("1. Створити трикутник");
            Console.WriteLine("2. Створити прямокутник");
            Console.WriteLine("3. Створити квадрат");
            Console.WriteLine("4. Переглянути всі фігури");
            Console.WriteLine("5. Загальна площа всіх фігур");
            Console.WriteLine("0. Вихід");
            Console.WriteLine("\n");
            Console.Write("\nВаш вибір: ");
        }

        private void CreateTriangle()
        {
            Console.Clear();
            Console.WriteLine("Створення трикутника");
            Console.WriteLine("\n");

            Console.Write("Введіть довжину основи: ");
            if (double.TryParse(Console.ReadLine(), out double baseLength) && baseLength > 0)
            {
                Console.Write("Введіть висоту: ");
                if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
                {
                    Triangle triangle = new Triangle(baseLength, height);
                    shapes.Add(triangle);
                    Console.WriteLine("\nТрикутник успішно створено!");
                    triangle.DisplayInfo();
                }
                else
                {
                    Console.WriteLine("\nНевірна висота!");
                }
            }
            else
            {
                Console.WriteLine("\nНевірна довжина основи!");
            }
        }

        private void CreateRectangle()
        {
            Console.Clear();
            Console.WriteLine("Створення прямокутника");
            Console.WriteLine("\n");

            Console.Write("Введіть ширину: ");
            if (double.TryParse(Console.ReadLine(), out double width) && width > 0)
            {
                Console.Write("Введіть висоту: ");
                if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
                {
                    Rectangle rectangle = new Rectangle(width, height);
                    shapes.Add(rectangle);
                    Console.WriteLine("\nПрямокутник успішно створено!");
                    rectangle.DisplayInfo();
                }
                else
                {
                    Console.WriteLine("\nНевірна висота!");
                }
            }
            else
            {
                Console.WriteLine("\nНевірна ширина!");
            }
        }

        private void CreateSquare()
        {
            Console.Clear();
            Console.WriteLine("Створення квадрата");
            Console.WriteLine("\n");

            Console.Write("Введіть довжину сторони: ");
            if (double.TryParse(Console.ReadLine(), out double side) && side > 0)
            {
                Square square = new Square(side);
                shapes.Add(square);
                Console.WriteLine("\nКвадрат успішно створено!");
                square.DisplayInfo();
            }
            else
            {
                Console.WriteLine("\nНевірна довжина сторони!");
            }
        }

        private void ViewAllShapes()
        {
            Console.Clear();
            Console.WriteLine("Список всіх фігур");
            Console.WriteLine("\n");

            if (shapes.Count == 0)
            {
                Console.WriteLine("\nСписок фігур порожній!");
            }
            else
            {
                for (int i = 0; i < shapes.Count; i++)
                {
                    Console.WriteLine($"\nФігура #{i + 1}:");
                    shapes[i].DisplayInfo();
                }
            }
        }

        private void ViewTotalArea()
        {
            Console.Clear();
            Console.WriteLine("Загальна площа всіх фігур");
            Console.WriteLine("\n");

            if (shapes.Count == 0)
            {
                Console.WriteLine("\nНемає жодної фігури!");
            }
            else
            {
                double totalArea = 0;

                foreach (var shape in shapes)
                {
                    totalArea += shape.CalculateArea();
                }

                Console.WriteLine($"\nКількість фігур: {shapes.Count}");
                Console.WriteLine($"Загальна площа: {totalArea}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}