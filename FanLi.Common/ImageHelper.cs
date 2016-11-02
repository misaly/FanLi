using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace FanLi.Common
{
    /// <summary>
    /// 图像帮助类
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 会产生graphics异常的PixelFormat
        /// </summary>
        private static readonly PixelFormat[] IndexedPixelFormats = {
                                        PixelFormat.Undefined,
                                        PixelFormat.DontCare,
                                        PixelFormat.Format16bppArgb1555,
                                        PixelFormat.Format1bppIndexed,
                                        PixelFormat.Format4bppIndexed,
                                        PixelFormat.Format8bppIndexed,
                                        (PixelFormat)8207
        };

        /// <summary>
        /// 获取图像
        /// </summary>
        /// <param name="originImage"></param>
        /// <returns></returns>
        public static Image GetSafeImage(Image originImage)
        {
            //索引像素格式
            //如果原图片是索引像素格式之列的，则需要转换
            if (IsPixelFormatIndexed(originImage.PixelFormat))
            {
                //转换
                Bitmap bmp = new Bitmap(originImage.Width, originImage.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(originImage, 0, 0, originImage.Width, originImage.Height); //一定要指定目标源的宽高，要不然图像显示不完全
                }
                //下面的操作，就直接对 bmp 进行了
                return bmp;
            }
            return originImage;
        }

        /// <summary>
        /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
        /// </summary>
        /// <param name="imgPixelFormat">原图片的PixelFormat</param>
        /// <returns></returns>
        public static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            return IndexedPixelFormats.Contains(imgPixelFormat);
        }
    }
}
