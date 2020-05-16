using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_16._05._2020
{
    class ReadyCommand {
        public string Command { get; set; }
        public string First { get; set; }
        public double Second { get; set; }
    }

    class Calculator {
        public void PerformCalculate() {
            Dictionary<string, double> varibleList = new Dictionary<string, double>();    // словарь с переменными
            while (true) {
                Console.WriteLine("\nВведите команду:");
                string inputCommand = Console.ReadLine();    // ввод команды с консоли
                if (inputCommand == "") break;

                var parsCommand = ParsCommand(inputCommand);  // разделить команду на части

                bool checkLenghtCommand = CheckLenghtCommand(parsCommand); // проверка длины команды
                ReadyCommand readyCommand = CreateCommandParts(checkLenghtCommand, parsCommand); // создание класса Команда
                PerformCommand(readyCommand, varibleList);   // выполнить команду  
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Список всех переменных:");
            foreach(var item in varibleList) {
                Console.WriteLine(item);
            }
        }
        // Разделить введённую команду на части
        public string[] ParsCommand(string inputCommand) {
            string[] parsedCommand = inputCommand.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            return parsedCommand;
        }

        // Проверить длинну введённой команды
        bool CheckLenghtCommand(string[] command) {
            if (command.Length == 3)
                return true;
            else
                return false;
        }

        // Создать класс Команда
        ReadyCommand CreateCommandParts(bool commLenght, string[] command) {
            if (commLenght)
                return new ReadyCommand {
                    Command = command[0],
                    First = command[1],
                    Second = double.Parse(command[2])
                };
            else
                return new ReadyCommand {
                    Command = command[0],
                    First = command[1],
                    Second = 0
                };
        }
        
        // Выполнение команды
        public void PerformCommand(ReadyCommand command, Dictionary<string, double> dict) {
            switch (command.Command) {
                case "var": Var(dict, command.First); break;
                case "mov": Mov(dict, command.First, command.Second); break;
                case "add": Add(dict, command.First, command.Second); break;
                case "sub": Sub(dict, command.First, command.Second); break;
                case "div": Div(dict, command.First, command.Second); break;
                case "mul": Mul(dict, command.First, command.Second); break;
            }
        }

        void Var(Dictionary<string, double> dict, string first) {
            dict.Add(first, 0);
        }
        void Mov(Dictionary<string, double> dict, string first, double second) {
            dict[first] = second;
        }
        void Add(Dictionary<string, double> dict, string first, double second) {
            dict[first] += second;
        }
        void Sub(Dictionary<string, double> dict, string first, double second) {
            dict[first] -= second;
        }
        void Div(Dictionary<string, double> dict, string first, double second) {
            dict[first] /= second;
        }
        void Mul(Dictionary<string, double> dict, string first, double second) {
            dict[first] *= second;
        }
    }
}
