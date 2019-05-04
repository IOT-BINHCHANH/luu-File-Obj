using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace SaveFileObject.objs
{
    class RowsInfo
    {
        public static RowsInfo info = null;
        public List<MyRow> rows = new List<MyRow>();
        private string dataFolder = Application.StartupPath + "\\data\\";
        private string dataPath = Application.StartupPath + "\\data\\db.dat";
        private BinaryFormatter formatter;

        public RowsInfo()
        {
            formatter = new BinaryFormatter();
            if (File.Exists(dataPath))
            {
                loadData();
            }
        }

        public bool add(MyRow row)
        {
            if (row != null)
            {
                rows.Add(row);
                return true;
            }
            return false;
        }

        public static RowsInfo Instance()
        {
            if (info == null)
            {
                info = new RowsInfo();
            }
            return info;
        }

        public void save()
        {
            if(!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            try
            {
                FileStream writerFileStream = new FileStream(dataPath, FileMode.Create, FileAccess.Write);
                // Save our dictionary of friends to file
                formatter.Serialize(writerFileStream, this.rows);
                // Close the writerFileStream when we are done.
                writerFileStream.Close();
            }
            catch { }
        }

        public void loadData()
        {
            try
            {
                // Create a FileStream will gain read access to the 
                // data file.
                FileStream readerFileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read);
                // Reconstruct information of our friends from file.
                rows = (List<MyRow>)this.formatter.Deserialize(readerFileStream);
                // Close the readerFileStream when we are done
                readerFileStream.Close();
            } catch { }
        }
    }
}
