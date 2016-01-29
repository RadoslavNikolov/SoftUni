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

    public class BangaloreUniversityEngine : IRunnable
    {
        private readonly IReaderWriter readerWriter;

        public BangaloreUniversityEngine(IReaderWriter readerWriter)
        {
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            var db = new BangaloreUniversityDate();
            User u = null;
            while (true)
            {
                string str = this.readerWriter.Read();
                if (str == null)
                {
                    break;
                }

                var route = new Router(str);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var ctrl = Activator.CreateInstance(controllerType, db, u) as ControllerAbstract;
                var act = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, act);
                try 
                {
                    var view = act.Invoke(ctrl, @params) as IView;
                    this.readerWriter.Write(view.Display());
                    u = ctrl.User;
                } 
                catch (Exception ex) 
                {
                    this.readerWriter.Write(ex.InnerException.Message);
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

                argumentsToPass.Add(currentArgument);           
            }

            return argumentsToPass.ToArray();
        }
    }
}
