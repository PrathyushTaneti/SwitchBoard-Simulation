using System;
using System.Collections.Generic;
using System.Linq;
namespace Task{

    class SwitchBoardSimulator{
        private List<Appliance> ApplianceList;
        public SwitchBoardSimulator(){
            this.ApplianceList = new List<Appliance>();
        }

        public void CreateSwitchBoardSimulator()
        {
            int bulbCount = ReadApplicanceCount("Bulbs");
            int acCount = ReadApplicanceCount("AC");
            int fanCount = ReadApplicanceCount("Fan");
            int applianceId = 1;
            for (int i = 0; i < bulbCount; i++)
            {
                this.ApplianceList.Add(new Bulb(applianceId++));
            }
            for (int i = 0; i < acCount; i++)
            {
                this.ApplianceList.Add(new AC(applianceId++));
            }
            for (int i = 0; i < fanCount; i++)
            {
                this.ApplianceList.Add(new Fan(applianceId++));
            }
        }

        public void DisplaySwitchBoardSimulator(){
            while (true)
            {
                DisplayAvailableDevices();
                string message = "Enter Device Id To Select The Device : \nEnter 0 To Exit";
                int applianceId = ReadUserInput(message);
                if (applianceId == 0)
                {
                    Console.WriteLine("Good Bye");
                    break;
                }
                else
                {
                    CheckAndUpdateApplianceStatus(applianceId);
                }
            }
        }

        private void DisplayAvailableDevices(){
            Console.WriteLine("\nDisplaying Switch Board Devices");
            if (this.ApplianceList.Count == 0)
            {
                Console.WriteLine("No Appliances Found");
                return;
            }
            foreach (var appliance in this.ApplianceList)
            {
                Console.WriteLine(appliance.Name + " " + appliance.Id + " is \"" + appliance.State + "\"");
            }
        }

        private int ReadApplicanceCount(string applianceName)
        {
            string message = "Enter Number Of " + applianceName + "'s : ";
            return ReadUserInput(message);
        }

        private int ReadUserInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        private void CheckAndUpdateApplianceStatus(int applianceId)
        {
            var requiredAppliance = this.ApplianceList.SingleOrDefault(appliance => appliance.Id == applianceId);
            if (requiredAppliance != null)
            {
                string message = "1. Select " + requiredAppliance.Name + " " + requiredAppliance.Id + " is \"" + requiredAppliance.State + "\"" + "\n2. Back";
                int selectedOption = ReadUserInput(message);
                switch (selectedOption)
                {
                    case 1:
                        UpdateDeviceStatus(requiredAppliance);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No Appliance Found");
            }
        }
        
        private void UpdateDeviceStatus(Appliance requiredAppliance)
        {
            requiredAppliance.State = (requiredAppliance.State == State.Off) ? State.On : State.Off;
        }        
    }
}


// Ienumerable