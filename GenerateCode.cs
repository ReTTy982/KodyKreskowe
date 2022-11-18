using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using BarcodeLib;
using System.Drawing.Imaging;
using System.IO;

namespace KodyKreskowe
{
    class GenerateCode
    {
        public Image Generate(String code)
        {

            Barcode barcode = new Barcode();
            //barcode.LabelFont = new Font(barcode.LabelFont.FontFamily, 200 / 15);
            barcode.IncludeLabel= true;
            Image img = barcode.Encode(TYPE.EAN13, code);
            return img;

        }
        public String GetCheckSum(String code)
        {
            int checksum = 0;
            for(int i = 0; i < code.Length; i += 2)
            {
                checksum += Int32.Parse(code[i] + "");
                checksum += 3 * Int32.Parse(code[i + 1] + "");

            }
            checksum = checksum % 10;
            checksum = 10 - checksum;
            String add_check = checksum.ToString();
            code = code + add_check;
            return code;
        }

        public void SaveFile(Image image)
        {
            using (FileStream fs = new FileStream("kod_kreskowy.png", FileMode.Create, FileAccess.Write))
            {
                image.Save(fs, ImageFormat.Png);
                fs.Close();
            }
        }



    }
       
}
