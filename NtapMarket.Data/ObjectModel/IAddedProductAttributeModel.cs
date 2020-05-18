using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.ObjectModel
{
    public interface IAddedProductAttributeModel
    {
        string Name { get; set; }

        string Value { get; set; }

        string Description { get; set; }
    }
}
