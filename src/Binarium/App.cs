using System;
using System.Diagnostics;
using Binarium.AppServices;
using Binarium.Models;
using Microsoft.Extensions.Logging;

namespace Binarium
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IBinaryStringService _binaryStringService;
        private readonly CommandLineArguments _arguments;

        public App(
            ILogger<App> logger,
            IBinaryStringService binaryStringService,
            CommandLineArguments arguments)
        {
            _logger = logger;
            _binaryStringService = binaryStringService;
            _arguments = arguments;
        }

        public void Run()
        {
            if (_arguments.Values?.Length > 0)
                RunWithArguments();
            else
                RunWithManualInput();
        }

        private void RunWithManualInput()
        {
            Console.WriteLine("Enter binary string:");
            var input = Console.ReadLine();

            ValidateBinaryString(input);

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        private void RunWithArguments()
        {
            foreach (var input in _arguments.Values)
            {
                Console.WriteLine($"The binary string to check: '{input}'");

                ValidateBinaryString(input);
            }
        }

        private void ValidateBinaryString(string input)
        {
            var sw = Stopwatch.StartNew();

            var result = _binaryStringService.CheckForBeingGood(input);

            sw.Stop();
            _logger.LogDebug($"ElapsedMilliseconds: {sw.ElapsedMilliseconds}");
            _logger.LogDebug($"ElapsedTicks: {sw.ElapsedTicks}");

            if (result.Code == (int)BinaryStringTypes.Good)
            {
                Console.WriteLine("The binary string is GOOD.");
            }
            else
            {
                Console.WriteLine("The binary string is NOT GOOD.");
                Console.WriteLine($"Reason: {result.Description}");
            }

            Console.WriteLine();
        }
    }
}
