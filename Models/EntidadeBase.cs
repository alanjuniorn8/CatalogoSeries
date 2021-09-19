using System;

namespace DIO.Series.Models
{
    public abstract class EntidadeBase
    {
        public Guid Id{ get; private set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
    }
}