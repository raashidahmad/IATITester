﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IATITester.IATILib
{
    public interface IParserIATI
    {
        IXMLResult ParseIATIXML(string url);
    }
}
