using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;

namespace Competition
{
    class Logger
    {

        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = @"competition.log";
            roller.DatePattern = "'competition_'yyyyMMdd'.log'";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 10;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = false;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);



            //ColoredConsoleAppender console = new ColoredConsoleAppender();
            /*ColoredConsoleAppender console = new ColoredConsoleAppender
            {
                Threshold = Level.All,
                Layout = new PatternLayout(
                    "%level [%thread] %d{HH:mm:ss} - %message%newline"
                ),
            };
            console.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Debug,
                ForeColor = ColoredConsoleAppender.Colors.Cyan
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            console.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Info,
                ForeColor = ColoredConsoleAppender.Colors.Green
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            console.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Warn,
                ForeColor = ColoredConsoleAppender.Colors.Purple
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            console.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Error,
                ForeColor = ColoredConsoleAppender.Colors.Red
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            console.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Fatal,
                ForeColor = ColoredConsoleAppender.Colors.White
                    | ColoredConsoleAppender.Colors.HighIntensity,
                BackColor = ColoredConsoleAppender.Colors.Red
            });*/


            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

    }
}
