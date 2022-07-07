using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class ImageUploader
    {/*
         0=> dosya bos
         1=> bu gorsel zaten eklenmis
         2=> uymayan format
         3=> ekleme basarili
         */
        public static string UploadImage(string imagePath, HttpPostedFileBase file)
        {

            //yuklenen gorsele isim olusturma:

            string fileName = "";

            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                imagePath = imagePath.Replace("~", "");

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                fileName = uniqueName + "." + extension;

                //png, jpg, ve jpeg ve gif disindaki uzantilari kabul etme:
                if (extension == "png" || extension == "jpg" || extension == "jpeg" || extension == "gif")
                {
                    try
                    {
                        var filePath = HttpContext.Current.Server.MapPath(imagePath + fileName);
                        file.SaveAs(filePath);

                        return fileName;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return "2";
                }

            }
            else
            {
                return "0";
            }
        }
    }
}
