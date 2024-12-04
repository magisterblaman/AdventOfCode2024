using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2024_03 {
	internal class Program {
		static void Part1() {
			string text = File.ReadAllText("input.txt");

			Regex regex = new Regex(@"mul\((\d+),(\d+)\)");
			MatchCollection matches = regex.Matches(text);

			int sum = 0;
			for (int i = 0; i < matches.Count; i++) {
				sum += int.Parse(matches[i].Groups[1].Value) * int.Parse(matches[i].Groups[2].Value);
			}
			Console.WriteLine(sum);
		}

		static void Part2() {
			string text = File.ReadAllText("input.txt");

			Regex regex = new Regex(@"(?:mul\((\d+),(\d+)\))|(?:do(?:n't)?\(\))");
			MatchCollection matches = regex.Matches(text);

			bool mulEnabled = true;
			int sum = 0;
			for (int i = 0; i < matches.Count; i++) {
				if (matches[i].Value == "do()") {
					mulEnabled = true;
				} else if (matches[i].Value == "don't()") {
					mulEnabled = false;
				} else if (mulEnabled) {
					sum += int.Parse(matches[i].Groups[1].Value) * int.Parse(matches[i].Groups[2].Value);
				}
			}
			Console.WriteLine(sum);
		}
		static void Main(string[] args) {

			Part2();

		}
	}
}
