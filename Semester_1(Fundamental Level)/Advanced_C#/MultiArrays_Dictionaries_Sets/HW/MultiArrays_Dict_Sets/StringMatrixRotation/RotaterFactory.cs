namespace StringMatrixRotation
{
    using Interfaces;
    using Rotaters;

    public class RotaterFactory : IRotaterFactory
    {
        public IRotater GetRotater(int degrees)
        {
            IRotater rotater = null;
            switch (degrees % 360)
            {
                case 90:
                    rotater = new Rotater90();
                    break;

                case 180:
                    rotater = new Rotater180();
                    break;

                case 270: 
                    rotater = new Rotater270();
                    break;
                default:
                    rotater = new Rotater0();
                    break;
            }

            return rotater;
        }
    }
}