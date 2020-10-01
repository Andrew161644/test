﻿using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace ExcellParser
{
    public class RowParser : Parser
    {
        public RowParser()
            : base()
        {
            
        }
        
        protected override void createKeyValue(string[,] data,Dictionary<string,Dictionary<string,List<string>>> dictionaryOut,String sheetName)
        {
            int N = data.GetLength(0);
            int M = data.GetLength(1);
            Dictionary<string,List<string>> dictionaryIn = new Dictionary<string, List<string>>();
            String[] frow=_operations.getRow(data, 0);
            
            for (int rowNum = 1; rowNum < N; rowNum++)
            {
                for (int colNum = 0; colNum < M; colNum++)
                {
                    
                    dictAdd(frow[colNum],data[rowNum,colNum],dictionaryIn);
                }
            }
            dictionaryOut.Add(sheetName,dictionaryIn);
        }
    }
}