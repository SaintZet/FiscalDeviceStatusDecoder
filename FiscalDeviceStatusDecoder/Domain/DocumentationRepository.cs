using System;
using System.Collections.Generic;

namespace FiscalDeviceStatusDecoder.Domain
{
    internal class DocumentationRepository
    {
        internal static Dictionary<(int, int), string> GetDocument(Manufacturer manufacturer, string[]? models)
        {
            switch (manufacturer)
            {
                case Manufacturer.Datecs:
                    return new Datecs().GetDocument(models);

                case Manufacturer.Daisy:
                    return new Daisy().GetDocument(models);

                case Manufacturer.Eltrade:
                    return new Eltrade().GetDocument(models);
                    break;

                case Manufacturer.Tremol:
                    return new Tremol().GetDocument(models);

                case Manufacturer.Incotext:
                    return new Incotext().GetDocument(models);

                case Manufacturer.Port:
                    return new Port().GetDocument(models);
            }
            throw new NotImplementedException();
        }
    }
}