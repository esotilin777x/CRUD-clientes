using System;
using System.Drawing;
using System.Windows.Forms;

public static class Estilos
{
    public static void AplicarEstiloDataGrid(DataGridView dgv)
    {
        dgv.BorderStyle = BorderStyle.None;
        dgv.BackgroundColor = Color.White;
        dgv.EnableHeadersVisualStyles = false;
        dgv.GridColor = Color.LightGray;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToResizeRows = false;

        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219); // azul
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dgv.DefaultCellStyle.BackColor = Color.White;
        dgv.DefaultCellStyle.ForeColor = Color.Black;
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
        dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    public static void EstilizarLabel(Label lbl)
    {
        lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        lbl.ForeColor = Color.FromArgb(52, 73, 94); 
    }

    public static void EstilizarTextBox(TextBox txt)
    {
        txt.BorderStyle = BorderStyle.None;
        txt.BackColor = Color.White;
        txt.ForeColor = Color.Black;
        txt.Font = new Font("Segoe UI", 10);
        txt.Height = 30;
        txt.Multiline = true;
        txt.TextAlign = HorizontalAlignment.Left;
        txt.Padding = new Padding(5); 
    }



    public static void EstilizarBoton(Button boton, string tipo)
    {
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.Cursor = Cursors.Hand;
        boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        boton.Size = new Size(95, 30); 
        boton.ForeColor = Color.White;
        boton.TextAlign = ContentAlignment.MiddleCenter;
        boton.Padding = new Padding(0); 


    
        switch (tipo)
        {
            case "agregar":
                boton.BackColor = Color.FromArgb(46, 204, 113); // Verde
                break;
            case "actualizar":
                boton.BackColor = Color.FromArgb(52, 152, 219); // Azul
                break;
            case "eliminar":
                boton.BackColor = Color.FromArgb(231, 76, 60); // Rojo
                break;
            case "cargar":
                boton.BackColor = Color.FromArgb(52, 73, 94); // Gris azul
                break;
            default:
                boton.BackColor = Color.DimGray;
                break;
        }

        // Bordes redondeados
        boton.Region = System.Drawing.Region.FromHrgn(
            CreateRoundRectRgn(0, 0, boton.Width, boton.Height, 20, 20)
        );


    }

    // Importación de GDI32 para bordes redondeados
    [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );

}
