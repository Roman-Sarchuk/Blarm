using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlarmWF
{
    public enum ColorStatusName { On, Mute, Off };

    internal class StatusColor
    {
        // green, orange, red
        private static Color[] btnColorList = new Color[] { Color.FromArgb(212, 236, 151), Color.FromArgb(255, 219, 151), Color.FromArgb(255, 191, 191) };

        public static Color GetColor(ColorStatusName status)
        {
            switch (status)
            {
                case ColorStatusName.On:
                    return btnColorList[0];
                case ColorStatusName.Mute:
                    return btnColorList[1];
                case ColorStatusName.Off:
                    return btnColorList[2];
            }
            return default(Color);
        }
        public static string GetText(ColorStatusName status) { return status.ToString(); }
    }
}
