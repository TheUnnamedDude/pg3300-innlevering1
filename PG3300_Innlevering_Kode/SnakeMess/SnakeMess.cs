using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER!
//          "Aaaargh!"
//          "My eyes bleed!"
//          "I facepalmed my facepalm."
//          Etc.
//          I had a lot of fun obfuscating this code though! And I can now (proudly?) say that this is the uggliest short piece of code I've ever worked with! :-)
//          (And yes, it could have been a lot ugglier! But the idea wasn't to make it fuggly-uggly, just funny-uggly, sweet-uggly, or whatever you want to call it.)
//
//          -Tomas
//
namespace SnakeMess
{
	class SnakeMess
	{
		public static void Main(string[] arguments)
		{
			bool originalCursorVisible = Console.CursorVisible; // Save the state
			Console.Clear(); // Lets clear the console window
			bool gg = false, pause = false, inUse = false;
			Coordinate direction = Coordinate.DOWN;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			Random rng = new Random();
			Coordinate app = new Coordinate();
			List<Coordinate> snake = new List<Coordinate>();
			snake.Add(new Coordinate(10, 10)); snake.Add(new Coordinate(10, 10)); snake.Add(new Coordinate(10, 10)); snake.Add(new Coordinate(10, 10));
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");
			while (true) {
				app = new Coordinate(rng.Next(0, boardW), rng.Next(0, boardH));
				if (!snake.Any(snakePart => snakePart.X == app.X && snakePart.Y == app.Y)) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.X, app.Y); Console.Write("$");
					break;
				}
			}
			Stopwatch t = new Stopwatch();
			t.Start();
			while (!gg) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gg = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (cki.Key == ConsoleKey.UpArrow && !direction.isOpposite(Coordinate.UP))
						direction = Coordinate.UP;
					else if (cki.Key == ConsoleKey.RightArrow && !direction.isOpposite(Coordinate.RIGHT))
						direction = Coordinate.RIGHT;
					else if (cki.Key == ConsoleKey.DownArrow && !direction.isOpposite(Coordinate.DOWN))
						direction = Coordinate.DOWN;
					else if (cki.Key == ConsoleKey.LeftArrow && !direction.isOpposite(Coordinate.LEFT))
						direction = Coordinate.LEFT;
				}
				if (!pause) {
					if (t.ElapsedMilliseconds < 100)
						continue;
					t.Restart();
					Coordinate tail = new Coordinate(snake.First());
					Coordinate head = new Coordinate(snake.Last());
					Coordinate newH = new Coordinate(head);
					newH += direction;
					if (newH.X < 0 || newH.X >= boardW)
						gg = true;
					else if (newH.Y < 0 || newH.Y >= boardH)
						gg = true;
					if (newH.X == app.X && newH.Y == app.Y) {
						if (snake.Count + 1 >= boardW * boardH)
							// No more room to place apples -- game over.
							gg = true;
						else {
							while (true) {
								app = new Coordinate(rng.Next(0, boardW), rng.Next(0, boardH));
								bool found = true;
								foreach (Coordinate i in snake)
									if (i.X == app.X && i.Y == app.Y) {
										found = false;
										break;
									}
								if (found) {
									inUse = true;
									break;
								}
							}
						}
					}
					if (!inUse) {
						snake.RemoveAt(0);
						foreach (Coordinate x in snake)
							if (x.X == newH.X && x.Y == newH.Y) {
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}
					}
					if (!gg) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y); Console.Write("0");
						if (!inUse) {
							Console.SetCursorPosition(tail.X, tail.Y); Console.Write(" ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.X, app.Y); Console.Write("$");
							inUse = false;
						}
						snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.X, newH.Y); Console.Write("@");
					}
				}
			}
			// Set the cursor visible back to the original value to leave the console in a usable state...
			Console.CursorVisible = originalCursorVisible;
			Console.Clear();
		}
	}
}
