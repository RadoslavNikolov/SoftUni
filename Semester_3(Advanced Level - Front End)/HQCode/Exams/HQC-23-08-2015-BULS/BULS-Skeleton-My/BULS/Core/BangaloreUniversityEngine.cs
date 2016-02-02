namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Controllers;
    using Data;
    using Interfaces;
    using Models;
    using Utilities.Exceptions;

    public class BangaloreUniversityEngine : IRunnable
    {
        private readonly IReaderWriter readerWriter;

        public BangaloreUniversityEngine(IReaderWriter readerWriter)
        {
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            var db = new BangaloreUniversityData();
            User currentUser = null;
            while (true)
            {
                string inputLine = this.readerWriter.Read();
                if (inputLine == null)
                {
                    break;
                }

                var route = new Router(inputLine);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var ctrl = Activator.CreateInstance(controllerType, db, currentUser) as ControllerAbstract;
                var act = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, act);

                try 
                {
                    var view = act.Invoke(ctrl, @params) as IView;
                    this.readerWriter.Write(view.Display());
                    currentUser = ctrl.CurrentUser;
                } 
                catch (Exception ex) 
                {
                    if (ex.InnerException is ArgumentException || ex.InnerException is AuthorizationFailedException)
                    {
                        this.readerWriter.Write(ex.InnerException.Message);                        
                    }
                    else
                    {
                        throw ex.InnerException;
                    }
                }
            }
        }

        private static object[] MapParameters(Router router, MethodInfo action)
        {
            var expectedMethodparameters = action.GetParameters();
            var argumentsToPass = new List<object>();

            foreach (ParameterInfo param in expectedMethodparameters)
            {
                var currentArgument = router.Parameters[param.Name];
                if (param.ParameterType == typeof(int))
                {
                    argumentsToPass.Add(int.Parse(currentArgument));
                }
                else
                {
                    argumentsToPass.Add(currentArgument);                               
                }
            }

            return argumentsToPass.ToArray();
        }
    }
}
