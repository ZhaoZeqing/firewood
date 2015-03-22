using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Common
{
    public class ConpressPic
    {
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="sFile">文件的源地址</param>
        /// <param name="outPath">保存压缩图片文件的新地址</param>
        /// <param name="flag">压缩的百分比</param>
        /// <returns></returns>
        public static bool GetPicThumbnail(string sFile, string outPath, int flag)//压缩图片质量和大小
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);

            ImageFormat tFormat = iSource.RawFormat;
            //以下代码为保存图片时，设置压缩质量 
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100 
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                iSource = SizeDown(iSource);
                if (jpegICIinfo != null)
                {
                    iSource.Save(outPath, jpegICIinfo, ep);//dFile是压缩后的新路径 
                }
                else
                {
                    iSource.Save(outPath, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                iSource.Dispose();
            }
        }

        public static Image SizeDown(Image iSource)
        {
            int width = (int)(iSource.Width);
            int height = (int)(iSource.Height);
            float wh = ((float)width / (float)height);
            if (width >= height && width > 1500)
            {
                width = 1500;
                height = (int)(1500 / wh);
            }
            else if (height > width && height > 1125)
            {
                height = 1125;
                width = (int)(1125 * wh);
            }
            else
            {
            }
            Bitmap init = new Bitmap(iSource, new Size(width, height));
            iSource.Dispose();
            return (Bitmap)init;
        }
    }
}
