﻿using System;
using System.Collections.Generic;

namespace ExcellParser
{
    public class ColumnParser :Parser
    {
        public ColumnParser() : base()
        {
            
        }

        protected override void createKeyValue(string[,] data, Dictionary<string, Dictionary<string, List<string>>> dictionaryOut, string sheetName)
        {
            int N = data.GetLength(0);
            int M = data.GetLength(1);
            Dictionary<string,List<string>> dictionaryIn = new Dictionary<string, List<string>>();
            String[] fcol=_operations.getColumn(data, 0);
            
            for (int rowNum = 0; rowNum < N; rowNum++)
            {
                for (int colNum = 1; colNum < M; colNum++)
                {
                    if (String.IsNullOrEmpty(data[rowNum,colNum]))
                    {
                        continue;
                    }
                    dictAdd(fcol[rowNum],data[rowNum,colNum],dictionaryIn);
                }
            }
            dictionaryOut.Add(sheetName,dictionaryIn);
        }
    }
}