﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    using Infrastructure;
    using Models.Appenders;
    using Models.Enums;
    using Models.Layouts;
    using Models.Loggers;

    class MyLoggerProgram
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "../../log.txt";

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "TestUser"));
            logger.Warn("Warning - missing files.");

            var xmlLayout = new XmlLayout();
            consoleAppender = new ConsoleAppender(xmlLayout);
            logger = new Logger(consoleAppender);
            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");

            consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;
            logger = new Logger(consoleAppender);


            logger.Info("Application server startexd successfully");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Host unreachable");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
