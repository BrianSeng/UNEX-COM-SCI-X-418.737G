using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UCLAExtension.DesignPatterns.Builder.ComputerBuilder.Lab
{
    // Product class
    public class Computer
    {
        public Computer(string name)
        { Name = name; }

        // Computer parts
        public string Name { get; private set; }
        public string Case { get; set; }
        public string Motherboard { get; set; }
        public string VideoCard { get; set; }
        public string SoundCard { get; set; }
        public string PowerSupply { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string OpticalDrive { get; set; }
        public string CoolingDevice { get; set; }
        public string Cables { get; set; }
        public string Monitor { get; set; }
        public string Keyboard { get; set; }
        public string Mouse { get; set; }
        public string OS { get; set; }
        public string Office { get; set; }

        // Display computer details
        public override string ToString()
        {
            string display = string.Format(
                " Name: {0}\n" +
                " Case: {1}\n" +
                " Motherboard: {2}\n" +
                " Video Card: {3}\n" +
                " Sound Card: {4}\n" +
                " Power Supply: {5}\n" +
                " CPU: {6}\n" +
                " RAM: {7}\n" +
                " Hard Drive: {8}\n" +
                " Optical Drive: {9}\n" +
                " Cooling Device: {10}\n" +
                " Cables: {11}\n" +
                " Monitor: {12}\n" +
                " Keyboard: {13}\n" +
                " Mouse: {14}\n" +
                " OS: {15}\n" +
                " Office: {16}",
                Name, Case, Motherboard, VideoCard,
                SoundCard, PowerSupply, CPU, RAM, OpticalDrive,
                HardDrive, CoolingDevice, Cables, Monitor,
                Keyboard, Mouse, OS, Office);

            return display;
        }
    }

    // Builder interface
    public interface IComputerBuilder
    {
        void BuildCase();
        void BuildMotherboard();
        void BuildVideoCard();
        void BuildSoundCard();
        void BuildPowerSupply();
        void BuildCPU();
        void BuildRAM();
        void BuildHardDrive();
        void BuildOpticalDrive();
        void BuildCoolingDevice();
        void BuildCables();
        void BuildMonitor();
        void BuildKeyboard();
        void BuildMouse();
        void BuildOS();
        void BuildOffice();
        Computer Computer { get; }
    }

    // ConcreteBuilder class
    public class FalconNorthwest_Mach5 : IComputerBuilder
    {
        Computer computer;

        public FalconNorthwest_Mach5()
        { computer = new Computer("Falcon Northwest Mach5 Custom-Built"); }

        #region IComputerBuilder Members

        public void BuildCase()
        { computer.Case = "ICON2 - Black Anodized Chassis"; }

        public void BuildMotherboard()
        { computer.Motherboard = "Asus Z87 Deluxe Motherboard"; }

        public void BuildVideoCard()
        { computer.VideoCard = "NVIDIA GeForce® GTX 760 2GB Video Card"; }

        public void BuildSoundCard()
        { computer.SoundCard = "Creative Sound Blaster Z Sound Card"; }

        public void BuildPowerSupply()
        { computer.PowerSupply = "SilverStone 750 Watt Modular"; }

        public void BuildCPU()
        { computer.CPU = "Intel Core i5 4670K 3.4GHz Processor"; }

        public void BuildRAM()
        { computer.RAM = "1866MHz 2x8GB (16GB) Memory"; }

        public void BuildHardDrive()
        { computer.HardDrive = "Western Digital Black™ 2TB Hard Drive"; }

        public void BuildOpticalDrive()
        { computer.OpticalDrive = "Asus 16x DVD Writer Optical Drive"; }

        public void BuildCoolingDevice()
        { computer.CoolingDevice = "Chassis Fan Kit"; }

        public void BuildCables()
        { computer.Cables = "Standard Cable Package"; }

        public void BuildMonitor()
        { computer.Monitor = "ASUS Designo Series MX299Q 29\" 5ms LED"; }

        public void BuildKeyboard()
        { computer.Keyboard = "Logitech K120"; }

        public void BuildMouse()
        { computer.Mouse = "Logitech M100 Mouse"; }

        public void BuildOS()
        { computer.OS = "Microsoft Windows 8.1 64-Bit Operating System"; }

        public void BuildOffice()
        { computer.Office = "Microsoft Office 365 Home Premium"; }

        // GetResult Method returning actual computer
        public Computer Computer
        { get { return computer; } }

        #endregion
    }

	// ConcreteBuilder class
	public class PhoenixDown_v3 : IComputerBuilder
	{
		Computer computer;

		public PhoenixDown_v3()
		{ computer = new Computer("Phoenix Down Version 3 Custom-Built"); }

		#region IComputerBuilder Members

		public void BuildCase()
		{ computer.Case = "FRIG3 - White Anodized Mini-Refrigerator Body"; }

		public void BuildMotherboard()
		{ computer.Motherboard = "Asus GTR Plus Ultra Motherboard"; }

		public void BuildVideoCard()
		{ computer.VideoCard = "NVIDIA GeForce® GTX 760 2GB Video Card"; }

		public void BuildSoundCard()
		{ computer.SoundCard = "Creative Sound Blaster Z Sound Card"; }

		public void BuildPowerSupply()
		{ computer.PowerSupply = "SilverStone 750 Watt Modular"; }

		public void BuildCPU()
		{ computer.CPU = "Hamster On A Wheel 6.4GHz Processor"; }

		public void BuildRAM()
		{ computer.RAM = "2x8GB DDR4 (16GB) Memory"; }

		public void BuildHardDrive()
		{ computer.HardDrive = "Black Hole"; }

		public void BuildOpticalDrive()
		{ computer.OpticalDrive = "3.5 inch Floppy Disk Drive"; }

		public void BuildCoolingDevice()
		{ computer.CoolingDevice = "Trained Mice w/ Palm Fronds"; }

		public void BuildCables()
		{ computer.Cables = "Standard Cable Package"; }

		public void BuildMonitor()
		{ computer.Monitor = "Professional Mime That Charades Me the UI"; }

		public void BuildKeyboard()
		{ computer.Keyboard = "Logitech K120"; }

		public void BuildMouse()
		{ computer.Mouse = "Logitech M100 Mouse"; }

		public void BuildOS()
		{ computer.OS = "Microsoft Windows 95 Operating System"; }

		public void BuildOffice()
		{ computer.Office = "Microsoft Office 365 Home Premium"; }

		// GetResult Method returning actual computer
		public Computer Computer
		{ get { return computer; } }

		#endregion
	}


	// Director class
	public class ComputerManufacturer
    {
        public void Construct(IComputerBuilder computerBuilder)
        {
            computerBuilder.BuildCase();
            computerBuilder.BuildMotherboard();
            computerBuilder.BuildVideoCard();
            computerBuilder.BuildSoundCard();
            computerBuilder.BuildPowerSupply();
            computerBuilder.BuildCPU();
            computerBuilder.BuildRAM();
            computerBuilder.BuildHardDrive();
            computerBuilder.BuildOpticalDrive();
            computerBuilder.BuildCoolingDevice();
            computerBuilder.BuildCables();
            computerBuilder.BuildMonitor();
            computerBuilder.BuildKeyboard();
            computerBuilder.BuildMouse();
            computerBuilder.BuildOS();
            computerBuilder.BuildOffice();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Builder Pattern: Computers";
            Console.WindowHeight = (int)(Console.LargestWindowHeight * 0.75);
            Console.BufferHeight = 5000;

            // Create a Falcon Northwest Mach 5 Computer
            Console.WriteLine(
                "\n Create a Falcon Northwest Mach 5 Computer.\n");

            ComputerManufacturer manufacturer = new ComputerManufacturer();
            IComputerBuilder falconBuilder = null;

            falconBuilder = new FalconNorthwest_Mach5();
            manufacturer.Construct(falconBuilder);

            Console.WriteLine("{0}", falconBuilder.Computer.ToString());

            // *** Build your own custom-built computer. ***
            Console.WriteLine(
                "\n Create your own custom-built computer.\n");

			// *** Add code here ***
			IComputerBuilder phoenixBuilder = new PhoenixDown_v3();
			manufacturer.Construct(phoenixBuilder);

			Console.WriteLine("{0}", phoenixBuilder.Computer.ToString());

			Console.ReadKey();
        }
    }
}


