using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class BotonRedondo : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, this.Width, this.Height); // ovalado
        this.Region = new Region(path);
    }
}
