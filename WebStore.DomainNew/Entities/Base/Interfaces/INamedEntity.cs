using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
