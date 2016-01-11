namespace Blobs.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Infrastructure;
    using Models.Inftrastructure;

    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(string attackType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == attackType.ToLowerInvariant());

            if (type == null)
            {
                throw new ArgumentException("Unknown attack type");
            }

            var attack = (IAttack)Activator.CreateInstance(type);

            return attack;
        }
    }
}