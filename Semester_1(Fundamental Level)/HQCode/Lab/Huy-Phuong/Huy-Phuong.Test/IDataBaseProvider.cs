namespace Huy_Phuong.Test
{
    using System.Collections.Generic;
    using Infrastructure;

    public interface IDataBaseProvider
    {
        IList<ITheatre> GetMockDataBase { get;}
    }
}