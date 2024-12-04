using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2024_02 {
	internal class Program {
		
		static bool IsReportSafe(int[] report) {
			int lastDiff = 0;
			bool valid = true;
			for (int j = 1; j < report.Length; j++) {
				int newDiff = report[j] - report[j - 1];

				if (Math.Abs(newDiff) < 1 || Math.Abs(newDiff) > 3) {
					return false;
				}
				if (j != 1 && Math.Sign(lastDiff) != Math.Sign(newDiff)) {
					return false;
				}

				lastDiff = newDiff;
			}
			return true;
		}

		static int[] ExceptIndex(int[] input, int index) {
			int[] output = new int[input.Length - 1];
			int outputI = 0;
			for (int inputI = 0; inputI < input.Length; inputI++) {
				if (inputI == index) {
					continue;
				}
				output[outputI] = input[inputI];
				outputI++;
			}
			return output;
		}

		static void Part1() {
			string[] lines = File.ReadAllLines("input.txt");

			int safes = 0;
			for (int i = 0; i < lines.Length; i++) {
				string[] splitLine = lines[i].Split(' ');
				int[] report = new int[splitLine.Length];
				for (int j = 0; j < splitLine.Length; j++) {
					report[j] = int.Parse(splitLine[j]);
				}
				
				if (IsReportSafe(report)) {
					safes++;
				}
			}

			Console.WriteLine(safes);
		}

		static void Part2() {
			string[] lines = File.ReadAllLines("input.txt");

			int safes = 0;
			for (int i = 0; i < lines.Length; i++) {
				string[] splitLine = lines[i].Split(' ');
				int[] report = new int[splitLine.Length];
				for (int j = 0; j < splitLine.Length; j++) {
					report[j] = int.Parse(splitLine[j]);
				}

				for (int j = 0; j < report.Length; j++) {
					if (IsReportSafe(ExceptIndex(report, j))) {
						safes++;
						break;
					}
				}
			}

			Console.WriteLine(safes);
		}

		static void Main(string[] args) {

			Part2();

		}
	}
}
