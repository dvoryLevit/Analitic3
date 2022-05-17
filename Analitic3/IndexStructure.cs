using System;
using System.Collections.Generic;
using System.Text;

namespace Analitic3
{
    class IndexStructure
    {
        public int iList { get; set; }
        public int iArry { get; set; }

        public IndexStructure()
        {
        }

        public IndexStructure(int index1, int index2)
        {
            this.iList = index1;
            this.iArry = index2;
        }
    }
}
