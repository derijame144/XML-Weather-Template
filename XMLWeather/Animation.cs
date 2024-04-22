using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWeather
{
    internal class Animation
    {
        List<Image> spriteList;
        public Image currentsprite;
        public int spriteNumber = 0;

        public Animation(List<Image> spriteList)
        {
            this.spriteList = spriteList;
        }

        public void Play()
        {
            currentsprite = spriteList[spriteNumber];


            spriteNumber++;

            if (spriteNumber == spriteList.Count)
            {
                spriteNumber = 0;
            }
        }
    }
}
