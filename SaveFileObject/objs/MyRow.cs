using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaveFileObject.objs
{
    [Serializable]
    class MyRow
    {
        public string id;
        public string name;
        

        public MyRow(string id, string name)
        {
            this.id = id;
            this.name = name;

        }

    }
}
