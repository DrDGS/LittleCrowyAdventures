using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IAttackInputSource
    {

        bool X { get; }
        bool Y { get; }
        bool Sp { get; }

    }
}
