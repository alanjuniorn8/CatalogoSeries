using System;

namespace DIO.Series.Classes
{
    public abstract class SerieBase
    {
        private readonly Guid _id;

        public SerieBase()
        {
            _id = Guid.NewGuid();
        }
    }
}