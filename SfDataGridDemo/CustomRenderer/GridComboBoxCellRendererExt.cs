using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.ListView;
using System;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public class GridComboBoxCellRendererExt : GridComboBoxCellRenderer
    {
        protected override void OnInitializeEditElement(
            DataColumnBase column, RowColumnIndex rowColumnIndex, SfComboBox uiElement)
        {
            base.OnInitializeEditElement(column, rowColumnIndex, uiElement);

            uiElement.DropDownButton.Visible = false;
            uiElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            if (uiElement.DropDownListView.View != null)
            {
                uiElement.DropDownListView.View.Filter = (object data) =>
                {
                    if (!(data is Material m)) return false;
                    var text = uiElement.Text ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(text)) return true;

                    return m.Name?.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0
                           || (m.Synonyms?.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
                };
            }
        }

        protected override void OnUnwireEditUIElement(SfComboBox uiElement)
        {
            if (uiElement?.DropDownListView?.View != null)
            {
                uiElement.DropDownListView.View.Filter = null;
            }
            base.OnUnwireEditUIElement(uiElement);
        }
    }
}
