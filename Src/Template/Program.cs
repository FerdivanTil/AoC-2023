﻿using Businesslogic;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.WriteResult(Test1, FileType.Test1Sample,0);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test2Sample);
            //Helper.WriteResult(Test2, FileType.Test2);
        }

        private static int Test1(List<string> input)
        {
            throw new NotImplementedException();
            return 0;
        }

        private static int Test2(List<string> input)
        {
            throw new NotImplementedException();
            return 0;
        }
    }
}
