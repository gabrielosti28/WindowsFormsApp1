using System.Windows.Forms;

namespace AppInterno.Helpers
{
    public static class UIHelper
    {
        public static void ShowLoading(Form form, string message = "Carregando...")
        {
            form.Cursor = Cursors.WaitCursor;
            form.Enabled = false;

            // TODO: Adicionar label de "Carregando..." ou progress bar
        }

        public static void HideLoading(Form form)
        {
            form.Cursor = Cursors.Default;
            form.Enabled = true;
        }

        public static void ShowError(Form form, string title, string message)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void ShowSuccess(Form form, string title, string message)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}