using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ButtonCreation
{
    static class MoveHandle
    {
        public static void myMove(this Control newControl)
        {
            Point mainLocation = Point.Empty;

            Point NewLocation = newControl.Location;

            newControl.MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    mainLocation = new Point(args.X, args.Y);
                }
            };

            newControl.MouseMove += (sender, args) =>
            {
                if (mainLocation != Point.Empty)
                {
                    Point newLocation = newControl.Location;
                    newLocation.X += args.X - mainLocation.X;
                    newLocation.Y += args.Y - mainLocation.Y;
                    newControl.Location = newLocation;
                }
            };

            newControl.MouseUp += (sender, args) =>
            {
                mainLocation = Point.Empty;
            };
        }

    }
}
