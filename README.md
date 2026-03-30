# How to Implement an AutoComplete Cell in WinForms DataGrid (SfDataGrid)?

By default, [Winforms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDatagrid) does not provide built‑in AutoComplete functionality. However, you can achieve similar behavior by using a GridComboBoxColumn.

The AutoComplete behavior can be implemented by creating a custom [GridComboBoxCellRenderer](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.Renderers.GridComboBoxCellRenderer.html) and overriding the [OnInitializeEditElement](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.Renderers.GridComboBoxCellRenderer.html#Syncfusion_WinForms_DataGrid_Renderers_GridComboBoxCellRenderer_OnInitializeEditElement_Syncfusion_WinForms_DataGrid_DataColumnBase_Syncfusion_WinForms_GridCommon_ScrollAxis_RowColumnIndex_Syncfusion_WinForms_ListView_SfComboBox_) method. Within this method, you can apply filtering to the dropdown items based on the characters typed in the cell by using the `uiElement.DropDownListView.View.Filter` property. And, you can update the row data based on the selected material within the [SfDataGrid.CellComboBoxSelectionChanged](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_CellComboBoxSelectionChanged) event.

**C#**
```
//Code snippet for customizing the GridComboBoxCellRenderer

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
                if (data is not Material m) return false;
                var text = uiElement.Text ?? string.Empty;
                if (string.IsNullOrWhiteSpace(text)) return true;

                return m.Name?.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 || (m.Synonyms?.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
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


//Code snippet for update the row data

dataGrid.CellComboBoxSelectionChanged += dataGrid_CellComboBoxSelectionChanged;

private void dataGrid_CellComboBoxSelectionChanged(object sender, CellComboBoxSelectionChangedEventArgs e)
{
    if (e.GridColumn.MappingName == "MaterialID")
    {
        if (e.Record is LineItem li)
        {
            if (e.SelectedItem is Material selected)
                li.Material = selected;
        }
    }
}
```

![LAutoComplete Cell](AutoComplete%20Cell.gif)

Take a moment to peruse the [WinForms DataGrid - Columns](https://help.syncfusion.com/windowsforms/datagrid/columntypes) documentation, to learn more about column and it's types with example.