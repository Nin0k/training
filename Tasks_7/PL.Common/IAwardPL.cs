﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Common
{
    public interface IAwardPL
    {
        void DisplayAllAwards();
        bool AddAward();
        Guid SelectedAward();
    }
}
