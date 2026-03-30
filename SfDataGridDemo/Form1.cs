using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.ListView.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Material> allMaterials = new List<Material>
            {
                new Material { ID = "1", Name = "Hedione", CAS = "123-456-78", Synonyms = "Methyl dihydrojasmonate"},
                new Material { ID = "2", Name = "Hedione Special", CAS = "222-222-222", Synonyms = "Methyl dihydrojasmonate"},
                new Material { ID = "3", Name = "Iso E Super", CAS = "567-89-0", Synonyms = "Sylvamber; patchouli ethanone" },
                new Material { ID = "4", Name = "Galaxolide", CAS = "987-65-3", Synonyms="Penthyl chromobyte"},
                new Material { ID = "5", Name = "Something Whatever", CAS = "888-77-6", Synonyms = "Blah blah blah"}
            };

            ObservableCollection<LineItem> lineItems = new ObservableCollection<LineItem>
            {
                new LineItem {Material = allMaterials[0], Parts = 100},
                new LineItem {Material = allMaterials[1], Parts = 200},
                new LineItem {Material = allMaterials[2], Parts = 300}
            };

            Formula currentFormula = new Formula();
            currentFormula.LineItems = lineItems;

            dataGrid.AutoGenerateColumns = false;
            dataGrid.SelectionMode = GridSelectionMode.Single;
            dataGrid.DataSource = currentFormula.LineItems;
            dataGrid.EditMode = EditMode.SingleClick;
            dataGrid.EditorSelectionBehavior = EditorSelectionBehavior.SelectAll;

            var nameColumn = new GridComboBoxColumn
            {
                MappingName = "MaterialID",
                HeaderText = "Name",
                Width = 300,
                DataSource = allMaterials,
                DisplayMember = "Name",
                ValueMember = "ID",
                DropDownStyle = DropDownStyle.DropDown,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend
            };
            dataGrid.Columns.Add(nameColumn);


            dataGrid.Columns.Add(new GridNumericColumn
            {
                MappingName = "Parts",
                HeaderText = "Parts",
                Width = 90
            });

            dataGrid.Columns.Add(new GridTextColumn
            {
                MappingName = "Material.CAS",
                HeaderText = "CAS",
                Width = 150,
                AllowEditing = true
            });

            dataGrid.CellRenderers.Remove("ComboBox");
            dataGrid.CellRenderers.Add("ComboBox", new GridComboBoxCellRendererExt());
            dataGrid.CellComboBoxSelectionChanged += dataGrid_CellComboBoxSelectionChanged;
        }

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
    }
}
