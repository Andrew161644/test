﻿using System;
using System.Collections.Generic;
 using System.IO;
using System.Linq;
 using Newtonsoft.Json;
using OfficeOpenXml;


namespace ExcellParser
{
    public class Parser
    {
        protected ArrayOperations _operations;
        protected Dictionary<string, Dictionary<string, List<string>>> dictionaryOut;
        public Parser()
        {
            _operations=new ArrayOperations();
            dictionaryOut=new Dictionary<string, Dictionary<string, List<string>>>();
        }
        public String parse(String path)
        {
            using (ExcelPackage xlPackage =
                new ExcelPackage(new FileInfo(path)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                int c = xlPackage.Workbook.Worksheets.Count;
                
                for (int i = 0; i < c; i++)
                {
                    var myWorksheet = xlPackage.Workbook.Worksheets[i];
                    var totalRows = myWorksheet.Dimension.End.Row;
                    var totalColumns = myWorksheet.Dimension.End.Column;
                    string[,] data=new string[totalRows,totalColumns];
                    for (int rowNum = 1; rowNum <= totalRows; rowNum++)
                    {
                        for (int colNum = 1; colNum <= totalColumns; colNum++)
                        {
                            var cell=myWorksheet.Cells[rowNum,colNum,rowNum,colNum].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                            String str=string.Join("", cell);
                            data[rowNum-1, colNum-1] = str;
                        }
                    }
                   
                    /*
                     * method here work with data[,] it is should add our data to dict out
                     */
                    _operations.removeFirstEmpty(ref data);
                    createKeyValue(data,dictionaryOut,myWorksheet.Name);
                }

                return JsonConvert.SerializeObject(dictionaryOut);
            }
        } 
       

        protected virtual void createKeyValue(string[,] data,Dictionary<string,Dictionary<string,List<string>>> dictionaryOut,String sheetName)
        {
            return;
        }

        protected void dictAdd(string key,string val,Dictionary<string,List<string>> inside)
        {
            if (!inside.ContainsKey(key))
            {
                List<String> s=new List<String>();
                s.Add(val);
                inside.Add(key,s);
            }
            else
            {
                inside[key].Add(val);
            }
        }
    }
}