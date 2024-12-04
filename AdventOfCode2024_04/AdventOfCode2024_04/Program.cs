using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;

namespace AdventOfCode2024_04 {
	internal class Program {

		static bool IsValid(char[,] wordSearch, string targetWord, int startX, int startY, int dirX, int dirY) {
			for (int i = 0; i < targetWord.Length; i++) {
				int x = startX + i * dirX;
				int y = startY + i * dirY;

				if (x < 0 || x >= wordSearch.GetLength(0) || y < 0 || y >= wordSearch.GetLength(1)) {
					return false;
				}
				if (wordSearch[x, y] != targetWord[i]) {
					return false;
				}
			}
			return true;
		}

		static void Part1() {
			string[] lines = File.ReadAllLines("input.txt");
			char[,] wordSearch = new char[lines[0].Length, lines.Length];

			for (int y = 0; y < lines.Length; y++) {
				for (int x = 0; x < lines[y].Length; x++) {
					wordSearch[x, y] = lines[y][x];
				}
			}

			(int dirX, int dirY)[] directions = new (int, int)[] {
				(1, 0),
				(1, 1),
				(0, 1),
				(-1, 1),
				(-1, 0),
				(-1, -1),
				(0, -1),
				(1, -1)
			};

			int occ = 0;

			for (int x = 0; x < wordSearch.GetLength(0); x++) {
				for (int y = 0; y < wordSearch.GetLength(1); y++) {
					for (int dirI = 0; dirI < directions.Length; dirI++) {
						(int dirX, int dirY) = directions[dirI];

						if (IsValid(wordSearch, "XMAS", x, y, dirX, dirY)) {
							occ++;
						}
					}
				}
			}

			Console.WriteLine(occ);

		}

		static char[,] GenerateCrossArray(string word, int dir1, int dir2) {
			char[,] crossArray = new char[word.Length, word.Length];

			for (int i = 0; i < word.Length; i++) {
				if (dir1 > 0) {
					crossArray[i, i] = word[i];
				} else {
					crossArray[word.Length - i - 1, word.Length - i - 1] = word[i];
				}

				if (dir2 > 0) {
					crossArray[word.Length - i - 1, i] = word[i];
				} else {
					crossArray[i, word.Length - i - 1] = word[i];
				}
			}

			return crossArray;

		}

		static bool IsMaskedMatch(char[,] wordSearch, char[,] maskedArray, int topLeftX, int topLeftY) {
			for (int xOff = 0; xOff < maskedArray.GetLength(0); xOff++) {
				for (int yOff = 0; yOff < maskedArray.GetLength(1); yOff++) {
					int x = topLeftX + xOff;
					int y = topLeftY + yOff;

					if (x < 0 || x >= wordSearch.GetLength(0) || y < 0 || y >= wordSearch.GetLength(1)) {
						return false;
					}

					if (maskedArray[xOff, yOff] != default) {
						if (maskedArray[xOff, yOff] != wordSearch[x, y]) {
							return false;
						}
					}
				}
			}
			return true;
		}

		static void Part2() {
			string[] lines = File.ReadAllLines("input.txt");
			char[,] wordSearch = new char[lines[0].Length, lines.Length];

			for (int y = 0; y < lines.Length; y++) {
				for (int x = 0; x < lines[y].Length; x++) {
					wordSearch[x, y] = lines[y][x];
				}
			}

			(int dir1, int dir2)[] directions = new (int, int)[] {
				(1, 1),
				(1, -1),
				(-1, -1),
				(-1, 1),
			};

			int occ = 0;

			for (int x = 0; x < wordSearch.GetLength(0); x++) {
				for (int y = 0; y < wordSearch.GetLength(0); y++) {

					for (int dirI = 0; dirI < directions.Length; dirI++) {
						(int dir1, int dir2) = directions[dirI];

						char[,] crossArray = GenerateCrossArray("MAS", dir1, dir2);

						if (IsMaskedMatch(wordSearch, crossArray, x, y)) {
							occ++;
						}
					}

				}
			}

			Console.WriteLine(occ);

		}

		static void Main(string[] args) {

			Part2();

		}
	}
}
