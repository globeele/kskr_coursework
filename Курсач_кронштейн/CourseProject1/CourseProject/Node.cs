using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class Node
    {
        float x;
        float y;
        int index;
        bool fixation;

        public Node() { }

        public Node(int _index, float _x, float _y, bool _fixation)
        {
            index = _index - 1;
            x = _x;
            y = _y;
            fixation = _fixation;
        }

        public float X
        {
            get { return (x); }
            set { x = value; }
        }
        public float Y
        {
            get { return (y); }
            set { y = value; }
        }

        public int Index
        {
            get { return (index); }
            set { index = value; }
        }

        public bool Fixation
        {
            get { return (fixation); }
            set { fixation = value; }
        }
    }
}
