namespace Empire.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using Models.EventsArgs;

    public class Engine : IRunnable
    {
        private readonly IFactory factory;
        private readonly IEmpireData data;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(IFactory factory, IEmpireData data, IInputReader reader, IOutputWriter writer)
        {
            this.factory = factory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public virtual void Run()
        {
            while (true)
            {
                string[] input = this.reader.Read().Split();

                this.ExecuteCommand(input);
                this.UpdateBuildings();
            }
        }

        protected virtual void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "empire-status":
                    this.ExecuteStatusCommand();
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                case "skip":
                    break;
                case "build":
                    this.ExecuteBuildCommand(inputParams[1]);
                    break;
                default: throw new ArgumentException("Unknown command");
            }

        }

        private void UpdateBuildings()
        {
            foreach (IBuilding building in this.data.Buildings)
            {
                building.Update();
            }

        }

        private void ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();
            this.AppendTreasuryInfo(output);
            this.AppnedBuildingsInfo(output);
            this.AppnedUnitsInfo(output);

            this.writer.Print(output.ToString().Trim());
        }


        private void ExecuteBuildCommand(string buildingType)
        {
            IBuilding building = this.factory.CreateBuilding(buildingType, this.factory);
            building.OnResourceProducer += this.AddResource;
            building.OnUnitProducer += this.AddUnit;

            this.data.AddBuilding(building);
        }

        private void AddUnit(object sender, UnitProducerEventArgs e)
        {
            var unit = e.Unit;
            this.data.AddUnit(unit);
        }

        private void AddResource(object sender, ResourceProducerEventArgs e)
        {
            var resource = e.Resource;
            this.data.Resources[resource.ResourceType] += resource.Quantity;

        }

        private void AppnedBuildingsInfo(StringBuilder output)
        {
            output.AppendLine("Buildings:");
            if (this.data.Buildings.Any())
            {
                this.data.Buildings.ToList().ForEach(b =>
                {
                    output.AppendLine(b.ToString());
                });
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppnedUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");
            if (this.data.Units.Any())
            {
                this.data.Units.ToList().ForEach(u =>
                {
                    output.AppendLine($"--{u.Key}: {u.Value}");
                });
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendTreasuryInfo(StringBuilder output)
        {
            output.AppendLine("Treasury:");
            
            this.data.Resources.ToList().ForEach(r =>
            {
                output.Append($"--{r.Key}: {r.Value}{Environment.NewLine}");
            });
        }
    }
}