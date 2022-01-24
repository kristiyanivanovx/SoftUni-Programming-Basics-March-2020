using System;
using System.Linq;
using System.Collections.Generic;

using MilitaryElite.Interfaces;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Classes;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer): this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = this.reader.ReadLine().Trim();

            while (command != "End")
            {
                string[] arguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                string soldierType = arguments[0];
                //string rank = arguments[0];

                int id = int.Parse(arguments[1]);
                string firstName = arguments[2];
                string lastName = arguments[3];

                ISoldier soldier = null;
                
                if (soldierType == "Private")
                {
                    soldier = AddPrivate(arguments, id, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddLieutenantGeneral(arguments, id, firstName, lastName);
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(arguments[4]);
                    string corps = arguments[5];

                    try
                    {
                        soldier = CreateCommando(arguments, id, firstName, lastName, salary, corps);
                    }
                    catch 
                    {
                        continue;
                    }
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(arguments[4]);
                    string corps = arguments[5];

                    try
                    {
                        Engineer engineer = CreateEngineer(arguments, id, firstName, lastName, salary, corps);
                        soldier = engineer;
                    }
                    catch
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(arguments[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

                command = Console.ReadLine().Trim();
            }

            foreach (ISoldier soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier CreateCommando(string[] arguments, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            Commando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArguments = arguments.Skip(6).ToArray();

            for (int i = 0; i < missionArguments.Length; i += 2)
            {
                try
                {
                    string codeName = missionArguments[i];
                    string state = missionArguments[i + 1];
                    Mission missionToAdd = new Mission(codeName, state);
                    commando.AddMission(missionToAdd);
                }
                catch
                {
                    continue;
                }
            }

            soldier = commando;
            return soldier;
        }

        private static Engineer CreateEngineer(string[] arguments, int id, string firstName, string lastName, decimal salary, string corps)
        {
            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairElements = arguments.Skip(6).ToArray();

            for (int i = 0; i < repairElements.Length; i += 2)
            {
                string partName = repairElements[i];
                int hoursWorked = int.Parse(repairElements[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private static ISoldier AddPrivate(string[] arguments, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(arguments[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }

        private ISoldier AddLieutenantGeneral(string[] arguments, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(arguments[4]);
            int[] privatesIDs = arguments.Skip(5).ToArray().Select(x => int.Parse(x)).ToArray();
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (string pid in arguments.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.FirstOrDefault(p => p.Id == int.Parse(pid));
                lieutenantGeneral.AddPrivate(privateToAdd as IPrivate);
            }

            soldier = lieutenantGeneral;
            return soldier;
        }
    }
}
