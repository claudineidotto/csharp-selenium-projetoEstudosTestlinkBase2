using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Uteis
{
    class CSVData
    {
        public static DataTable GetCSVData(string CSVFilePath)
        {
            StreamReader str_rdr = new StreamReader(CSVFilePath);
            string[] headercolnames = str_rdr.ReadLine().Split(',');

            DataTable dtbl = new DataTable();

            foreach (string headercolname in headercolnames)
            {
                dtbl.Columns.Add(headercolname);
            }

            while (!str_rdr.EndOfStream)
            {
                string[] rows = str_rdr.ReadLine().Split(',');
                DataRow dr = dtbl.NewRow();
                for (int i = 0; i < headercolnames.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dtbl.Rows.Add(dr);
            }
            return dtbl;
        }
    }
}
