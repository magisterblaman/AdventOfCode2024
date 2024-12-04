using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2024_01 {
	internal class Program {
		static void InsertionSort(int[] inputArray) {
			for (int i = 1; i < inputArray.Length; i++) {
				int value = inputArray[i];

				int j = i - 1;
				while (j >= 0 && inputArray[j] > value) {
					inputArray[j + 1] = inputArray[j];
					j--;
				}
				inputArray[j + 1] = value;
			}
		}

		static void Part1() {
			string[] lines = File.ReadAllLines("input.txt");

			int[] leftColumn = new int[lines.Length];
			int[] rightColumn = new int[lines.Length];

			for (int i = 0; i < lines.Length; i++) {
				string[] splitLine = lines[i].Split(new string[] { "   " }, StringSplitOptions.None);
				leftColumn[i] = int.Parse(splitLine[0]);
				rightColumn[i] = int.Parse(splitLine[1]);
			}

			InsertionSort(leftColumn);
			InsertionSort(rightColumn);

			int sum = 0;

			for (int i = 0; i < leftColumn.Length; i++) {
				if (leftColumn[i] > rightColumn[i]) {
					sum += leftColumn[i] - rightColumn[i];
				} else {
					sum += rightColumn[i] - leftColumn[i];
				}
			}

			Console.WriteLine(sum);
		}

		static void Part2() {
			string[] lines = File.ReadAllLines("input.txt");

			int[] leftColumn = new int[lines.Length];
			int[] rightColumn = new int[lines.Length];

			for (int i = 0; i < lines.Length; i++) {
				string[] splitLine = lines[i].Split(new string[] { "   " }, StringSplitOptions.None);
				leftColumn[i] = int.Parse(splitLine[0]);
				rightColumn[i] = int.Parse(splitLine[1]);
			}

			int sum = 0;

			for (int i = 0; i < leftColumn.Length; i++) {
				for (int j = 0; j < rightColumn.Length; j++) {
					if (leftColumn[i] == rightColumn[j]) {
						sum+=leftColumn[i];
					}
				}
			}
			Console.WriteLine(sum);
		}

		static void Main(string[] args) {

			Part2();
			
		}
	}
}
