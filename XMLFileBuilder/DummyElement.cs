using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileBuilder
{
    class DummyElement
    {
        private string readablename;
        private string locatorpath;
        private int somenumber;
        private bool somebool;
        private double somedouble;

        public DummyElement(string name, string path, int num, bool boo, double duhble)
        {
            readablename = name;
            locatorpath = path;
            somenumber = num;
            somebool = boo;
            somedouble = duhble;
        }

        public string Name {get { return readablename; }}
        public string xPath {get { return locatorpath; }}
        public int ID {get { return somenumber; }}
        public bool Valid {get { return somebool; }}
        public double BigNum {get { return somedouble;}}

    }
}
