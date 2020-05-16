using System;
using System.Collections.Generic;
using System.IO;

namespace PracticalWork
{
    class CommandParts {
        public string Command { get; set; }
        public string First { get; set; }
        public double Second { get; set; }
    }

    class Calculator {
        // выполнить команды, вписанные вручную
        public void PerformCalculate() {
            Dictionary<string, double> varibleList = new Dictionary<string, double>();    // словарь с переменными

            while (true) {
                Console.WriteLine("\nВведите команду:");
                string inputCommand = Console.ReadLine();    // ввод команды с консоли
                if (inputCommand == "") break;

                var parsedCommand = ParsCommand(inputCommand);  // разделить команду на части

                bool checkLenghtCommand = CheckLenghtCommand(parsedCommand); // проверка длины команды
                CommandParts readyCommand = CreateCommandParts(checkLenghtCommand, parsedCommand); // создание класса c частями команды
                PerformCommand(readyCommand, varibleList);   // выполнить команду  
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Список всех переменных:");
            foreach(var item in varibleList) {
                Console.WriteLine(item);
            }
        }

        // выполнять команды, записанные в файле
        public void PerformCalculate(string path) {
            Dictionary<string, double> varibleList = new Dictionary<string, double>();    // словарь с переменными

            string[] commands = ReadFile(path);
            foreach (var item in commands) {
                Console.WriteLine(item);
                string inputCommand = item;
                var parsedCommand = ParsCommand(inputCommand);  // разделить команду на части

                bool checkLenghtCommand = CheckLenghtCommand(parsedCommand); // проверка длины команды
                CommandParts readyCommand = CreateCommandParts(checkLenghtCommand, parsedCommand); // создание класса c частями команды
                PerformCommand(readyCommand, varibleList);   // выполнить команду  
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Список всех переменных:");
            foreach (var item in varibleList) {
                Console.WriteLine(item);
            }
        }
        // считать команды из файла
        string[] ReadFile(string path) {
            string[] readedFile = File.ReadAllLines(path);
            return readedFile;
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

        // Создать класс с частями команды
        CommandParts CreateCommandParts(bool commLenght, string[] command) {
            if (commLenght)
                return new CommandParts {
                    Command = command[0],
                    First = command[1],
                    Second = double.Parse(command[2])
                };
            else
                return new CommandParts {
                    Command = command[0],
                    First = command[1],
                    Second = 0
                };
        }
        
        // Выполнение команды
        public void PerformCommand(CommandParts command, Dictionary<string, double> dict) {
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
