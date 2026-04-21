using Snake.Models;
using Snake.Controller;

Random random = new Random();
// cord(width, hight)
Coord gridDimensions = new Coord(40, 25);

//start position snake
Coord snakePos = new Coord(10, 1);
Direction moveMentDirection = Direction.Down;
List<Coord> snakePosHistory = new List<Coord>();
int tailLength = 1;

//randomStart apple(a)
Coord applePos = new Coord(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
int frameDelayMilli = 100;
int score = 0;

//nested forloops for grid Y er for outer loop og x for inner loop.
while (true)
{
    Console.Clear();
    Console.WriteLine("Score: " + score);
    snakePos.ApplyMovementDirection(moveMentDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);

            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                Console.Write("■");
            else if (applePos.Equals(currentCoord))
                // hadde en feil her at jeg hadde skrevet writeline pga vane og det gjorde at en# ble displaced ingame.
                Console.Write("a");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
        /* Thread.Sleep(frameDelayMilli); */
    }

    if (snakePos.Equals(applePos))
    {
        tailLength++;
        score++;
        applePos = new Coord(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
    }
    else if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimensions.X - 1 || snakePos.Y ==
    gridDimensions.Y - 1 || snakePosHistory.Contains(snakePos))
    {
        score = 0;
        tailLength = 1;
        snakePos = new Coord(10, 1);
        snakePosHistory.Clear();
        moveMentDirection = Direction.Down;
        continue;
    }


    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
    if (snakePosHistory.Count > tailLength) snakePosHistory.RemoveAt(0);

    DateTime time = DateTime.Now;

    while ((DateTime.Now - time).Milliseconds < frameDelayMilli)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    moveMentDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    moveMentDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    moveMentDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    moveMentDirection = Direction.Down;
                    break;

            }
        }
    }

}