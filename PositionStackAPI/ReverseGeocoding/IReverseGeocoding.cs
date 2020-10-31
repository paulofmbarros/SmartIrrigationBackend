using System;
using System.Collections.Generic;
using System.Text;

namespace PositionStackAPI.ReverseGeocoding
{
    public interface IReverseGeocoding
    {
        void GetAddressFromCoords(string latitude, string longitude);
    }
}
