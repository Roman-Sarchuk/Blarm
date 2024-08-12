using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlarmWF
{
    public enum StatusName { On, Mute, Off };

    internal class StatusColor
    {
        // green, orange, red
        private static Color[] btnColorList = new Color[] { Color.FromArgb(212, 236, 151), Color.FromArgb(255, 219, 151), Color.FromArgb(255, 191, 191) };

        public static Color GetColor(StatusName status)
        {
            switch (status)
            {
                case StatusName.On:
                    return btnColorList[0];
                case StatusName.Mute:
                    return btnColorList[1];
                case StatusName.Off:
                    return btnColorList[2];
            }
            return default(Color);
        }
        public static string GetText(StatusName status) { return status.ToString(); }
    }
}
