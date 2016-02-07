﻿namespace AirConditionerTestingSystem.Interfaces
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandLine);
    }
}