using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;
using System.Globalization;

namespace PiSharper
{
    //Broadcom Pin Numbers
    public enum BCMPin
    {
        //Pin 2
        Two = 2,

        //Pin 3
        Three = 3,

        //Pin 4
        Four = 4,

        //Pin 14
        Fourteen = 14,

        //Pin 17
        Seventeen = 17,

        //Pin 15
        Fifteen = 15,

        //Pin 18
        Eighteen = 18,

        //Pin 27
        TwentySeven = 27,

        //Pin 22
        Twentytwo = 22,

        //pin 23
        TwentyThree = 23,

        //pin 24
        TwentyFour = 24,

        //pin 10
        Ten = 10,

        //pin 9
        Nine = 9,

        //Pin 11
        Eleven = 11,

        //Pin 25
        TwentyFive = 25,

        //Pin 8
        Eight = 8,

        //Pin 7
        Seven = 7,

        //Pin 5
        Five = 5,

        //Pin 6
        Six = 6,

        //Pin 12
        Twelve = 12,

        //Pin 13
        Thirteen = 13,

        //Pin 19
        Nineteen = 19,

        //Pin 16
        Sixteen = 16,

        //Pin 26
        TwentySix = 26,

        //Pin 20
        Twenty = 20,

        //Pin 21
        TwentyOne = 21,
    }

    //Physical Pin Numbers
    public enum PhysicalPin
    {
        //GPIO pins use the Broadcom pin numbers in linux
        //So we call the Broadcom pin number at each physical location

        //Physical pin 3 = bcm pin 2
        Three = 2,

        //Physical pin 5 = bcm pin 3
        Five = 3,

        //Physical pin 7 = bcm pin 4
        Seven = 4,

        //Physical pin 8 = bcm pin 14
        Eight = 14,

        //Physical pin 10 = bcm pin 15
        Ten = 15,

        //Physical pin 11 = bcm pin 17
        Eleven = 17,

        //Physical pin 12 = bcm pin 18
        Twelve = 18,

        //Physical pin 13 = bcm pin 27
        Thirteen = 27,

        //Physical pin 15 = bcm pin 22
        Fifteen = 22,

        //Physical pin 16 = bcm pin 23
        Sixteen = 23,

        //Physical pin 18 = bcm pin 24
        Eighteen = 24,

        //Physical pin 19 = bcm pin 10
        Ninteen = 10,

        //Physical pin 21 = bcm pin 9
        Twentyone = 9,

        //Physical pin 22 = bcm pin 25
        TwentyTwo = 25,

        //Physical pin 23 = bcm pin 11
        TwentyThree = 11,

        //Physical pin 24 = bcm pin 8
        TwentyFour = 8,

        //Physical pin 26 = bcm pin 7
        TwentySix = 7,

        //Physical pin 29 = bcm pin 5
        TwentyNine = 5,

        //Physical pin 31 = bcm pin 6
        ThirtyOne = 6,

        //Physical pin 32 = bcm pin 12
        ThirtyTwo = 12,

        //Physical pin 33 = bcm pin 13
        ThirtyThree = 13,

        //Physical pin 35 = bcm pin 19
        ThirtyFive = 19,

        //Physical pin 36 = bcm pin 16
        ThirtySix = 16,

        //Physical pin 37 = bcm pin 26
        ThirtySeven = 26,

        //Physical pin 38 = bcm pin 20
        ThirtyEight = 20,

        //Physical pin 40 = bcm pin 21
        Fourty = 21,
    }

    //Direction pin is used
    public enum Direction
    {//
        // GPIO pin is input
        Input,

        // GPIO pin is output(3v out)
        Output,
    }

    public class PiSharper
    {
        // We use a singleton to prevent a pin from being asked to be an input
        // and output at the same time, may not be necessary but we can determine that through testing
        // Stores the singleton instance of the class
        private static PiSharper instance;

        // Stores the configured directions of the GPIO ports
        private Dictionary<BCMPin, Direction> directions = new Dictionary<BCMPin, Direction>();

        //  Prevents a default instance of the LibGpio class from being created.
        private PiSharper()
        {
            var gpioPath = this.GetGpioPath();
            if (!Directory.Exists(gpioPath))
            {
                Directory.CreateDirectory(gpioPath);
            }
        }

        // Gets the class instance
        public static PiSharper Gpio
        {
            get
            {
                if (instance == null)
                {
                    instance = new PiSharper();
                }

                return instance;
            }
        }

        /// <summary>
        /// Closes a GPIO channel
        /// </summary>
        /// <param name="pinNumber">The physical pin number to configure</param>
        public void CloseChannel(PhysicalPin pinNumber)
        {
            this.CloseChannel(pinNumber);
        }

        /// <summary>
        /// Closes a GPIO channel
        /// </summary>
        /// <param name="pinNumber">The Broadcom pin number to configure</param>
        public void CloseChannel(BCMPin pinNumber)
        {
            var outputName = string.Format("gpio{0}", (int)pinNumber);
            var gpioPath = Path.Combine(this.GetGpioPath(), outputName);

            if (Directory.Exists(gpioPath))
            {
                this.UnExport(pinNumber);

                // Sets direction back to input.
                this.SetDirection(pinNumber, Direction.Input);
            }
            
            Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', configured for use", pinNumber));
        }

        /// <summary>
        /// Configures a GPIO channel for use
        /// </summary>
        /// <param name="pinNumber">The physical pin number to configure</param>
        /// <param name="direction">The direction to configure the pin for</param>
        public void SetupChannel(PhysicalPin pinNumber, Direction direction)
        {
            this.SetupChannel(pinNumber, direction);
        }

        /*
        private static BCMPin ConvertToBC(PhysicalPin pinNumber)
        {
           // return PhysicalPin(pinNumber);

             switch (pinNumber)
            {
                case PhysicalPin.Seven:
                    return BCMPin.Four;

                case PhysicalPin.Eleven:
                    return BCMPin.Seventeen;

                case PhysicalPin.Twelve:
                    return BCMPin.Eighteen;

                case PhysicalPin.Thirteen:
                    return BCMPin.TwentyOne;

                case PhysicalPin.Fifteen:
                    return BCMPin.Twentytwo;

                case PhysicalPin.Sixteen:
                    return BCMPin.TwentyThree;

                case PhysicalPin.Eighteen:
                    return BCMPin.TwentyFour;

                case PhysicalPin.TwentyTwo:
                    return BCMPin.TwentyFive;
               
                default:
                    throw new ArgumentOutOfRangeException();
                    
            }
            
      */
    


    /// <summary>
    /// Configures a GPIO channel for use
    /// </summary>
    /// <param name="pinNumber">The Broadcom pin number to configure</param>
    /// <param name="direction">The direction to configure the pin for</param>
    public void SetupChannel(BCMPin pinNumber, Direction direction)
        {
            var outputName = string.Format("gpio{0}", (int)pinNumber);
            var gpioPath = Path.Combine(this.GetGpioPath(), outputName);

            // If already exported, unexport it before continuing
            if (Directory.Exists(gpioPath))
            {
                this.UnExport(pinNumber);
            }

            // Now export the channel
            this.Export(pinNumber);

            // Set the IO direction
            this.SetDirection(pinNumber, direction);

            Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', configured for use", pinNumber));
        }

        /// <summary>
        /// Outputs a value to a GPIO pin
        /// </summary>
        /// <param name="pinNumber">The pin number to use</param>
        /// <param name="value">The value to output</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an attempt to use an incorrectly configured channel is made
        /// </exception>
        public void OutputValue(PhysicalPin pinNumber, bool value)
        {
            this.OutputValue(pinNumber, value);
        }

        /// <summary>
        /// Outputs a value to a GPIO pin
        /// </summary>
        /// <param name="pinNumber">The pin number to use</param>
        /// <param name="value">The value to output</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an attempt to use an incorrectly configured channel is made
        /// </exception>
        public void OutputValue(BCMPin pinNumber, bool value)
        {
            // Check that the output is configured
            if (!this.directions.ContainsKey(pinNumber))
            {
                throw new InvalidOperationException("Attempt to output value on un-configured pin");
            }

            // Check that the channel is not being used incorrectly
            if (this.directions[pinNumber] == Direction.Input)
            {
                throw new InvalidOperationException("Attempt to output value on pin configured for input");
            }

            var gpioId = string.Format("gpio{0}", (int)pinNumber);
            var filePath = Path.Combine(gpioId, "value");
            using (var streamWriter = new StreamWriter(Path.Combine(this.GetGpioPath(), filePath), false))
            {
                if (value)
                {
                    streamWriter.Write("1");
                }
                else
                {
                    streamWriter.Write("0");
                }
            }

            Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', outputting value '{1}'", pinNumber, value));
        }

        /// <summary>
        /// Reads a value form a GPIO pin
        /// </summary>
        /// <param name="pinNumber">The pin number to read</param>
        /// <returns>The value at that pin</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an attempt to use an incorrectly configured channel is made
        /// </exception>
        public bool ReadValue(PhysicalPin pinNumber)
        {
            return this.ReadValue(pinNumber);
        }

        /// <summary>
        /// Reads a value form a GPIO pin
        /// </summary>
        /// <param name="pinNumber">The pin number to read</param>
        /// <returns>The value at that pin</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an attempt to use an incorrectly configured channel is made
        /// </exception>
        public bool ReadValue(BCMPin pinNumber)
        {
            // Check that the output is configured
            if (!this.directions.ContainsKey(pinNumber))
            {
                throw new InvalidOperationException("Attempt to read value from un-configured pin");
            }

            // Check that the channel is not being used incorrectly
            if (this.directions[pinNumber] == Direction.Output)
            {
                throw new InvalidOperationException("Attempt to read value form pin configured for output");
            }

            var gpioId = string.Format("gpio{0}", (int)pinNumber);
            var filePath = Path.Combine(gpioId, "value");
            using (var fileStream = new FileStream(Path.Combine(this.GetGpioPath(), filePath), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var rawValue = streamReader.ReadToEnd().Trim();
                    Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', has input value '{1}'", pinNumber, rawValue));
                    if (rawValue == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Unexports a given GPIO pin number
        /// </summary>
        /// <param name="pinNumber">The pin number to unexport</param>
        private void UnExport(BCMPin pinNumber)
        {
            using (var fileStream = new FileStream(Path.Combine(this.GetGpioPath(), "unexport"), FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write((int)pinNumber);
                }
            }

            Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', un-exported", pinNumber));
        }

        /// <summary>
        /// Exports a given GPIO pin
        /// </summary>
        /// <param name="pinNumber">The pin number to export</param>
        private void Export(BCMPin pinNumber)
        {
            // The simulator requires directories to be created first, but the RasPi does not and throws an exception.
            if (this.TestMode)
            {
                var exportDir = string.Format("gpio{0}", (int)pinNumber);
                var exportPath = Path.Combine(this.GetGpioPath(), exportDir);
                if (!Directory.Exists(exportPath))
                {
                    Directory.CreateDirectory(exportPath);
                    File.Create(Path.Combine(exportPath, "value")).Close();
                }
            }

            using (var fileStream = new FileStream(Path.Combine(this.GetGpioPath(), "export"), FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite))
            {

                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write((int)pinNumber);
                    streamWriter.Flush();
                }
            }

            Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', been exported", pinNumber));
        }

        /// <summary>
        /// Sets the direction of a GPIO channel
        /// </summary>
        /// <param name="pinNumber">The pin number to set the direction of</param>
        /// <param name="direction">The direction to set it to</param>
        private void SetDirection(BCMPin pinNumber, Direction direction)
        {
            var gpioId = string.Format("gpio{0}", (int)pinNumber);
            var filePath = Path.Combine(gpioId, "direction");
            using (var streamWriter = new StreamWriter(Path.Combine(this.GetGpioPath(), filePath), false))
            {
                if (direction == Direction.Input)
                {
                    streamWriter.Write("in");
                }
                else
                {
                    streamWriter.Write("out");
                }
            }

            // Internally log the direction of this pin, so we can perform safety checks later.
            if (this.directions.ContainsKey(pinNumber))
            {
                this.directions[pinNumber] = direction;
            }
            else
            {
                this.directions.Add(pinNumber, direction);
            }

            Debug.WriteLine(string.Format("[PiSharp.LibGpio] Broadcom GPIO number '{0}', now set to direction '{1}'", pinNumber, direction));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the library should be used in test mode.
        /// Note: If running under Windows or Mac OSx, test mode is assumed.
        /// </summary>
        public bool TestMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the GPIO path to write to
        /// </summary>
        /// <returns>The correct path for the IO and mode</returns>
        private string GetGpioPath()
        {
            if (this.TestMode) 
            {
                // If we're in Test mode or running on a Mac, use a Unix style test path
                return "/tmp/RasPiGpioTest";
            }
            else
            {
                // Otherwise use the the GPIO folder for the Raspberry Pi
                return "/sys/class/gpio";
            }
        }

    }
}


