
namespace KoinovDiplom_ActEmpKPK
{
    partial class FormForClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label worker_IDLabel;
            this.button1 = new System.Windows.Forms.Button();
            this.pOSTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.wORKERDataGridView = new System.Windows.Forms.DataGridView();
            this.wORKERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.worker_IDComboBox = new System.Windows.Forms.ComboBox();
            this.user2DataSet = new KoinovDiplom_ActEmpKPK.user2DataSet();
            this.pOSTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pOSTTableAdapter = new KoinovDiplom_ActEmpKPK.user2DataSetTableAdapters.POSTTableAdapter();
            this.tableAdapterManager = new KoinovDiplom_ActEmpKPK.user2DataSetTableAdapters.TableAdapterManager();
            this.wORKERTableAdapter = new KoinovDiplom_ActEmpKPK.user2DataSetTableAdapters.WORKERTableAdapter();
            this.wORKERBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            label1 = new System.Windows.Forms.Label();
            worker_IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pOSTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKERDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSTBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKERBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(12, 266);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 13);
            label1.TabIndex = 10;
            label1.Text = "Код мет. акт.:";
            // 
            // worker_IDLabel
            // 
            worker_IDLabel.AutoSize = true;
            worker_IDLabel.BackColor = System.Drawing.Color.Transparent;
            worker_IDLabel.Location = new System.Drawing.Point(15, 35);
            worker_IDLabel.Name = "worker_IDLabel";
            worker_IDLabel.Size = new System.Drawing.Size(90, 13);
            worker_IDLabel.TabIndex = 6;
            worker_IDLabel.Text = "Код сотрудника:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(245, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Проверить правильность";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pOSTBindingSource
            // 
            this.pOSTBindingSource.DataMember = "POST";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 266);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 20);
            this.textBox1.TabIndex = 9;
            // 
            // wORKERDataGridView
            // 
            this.wORKERDataGridView.AutoGenerateColumns = false;
            this.wORKERDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.wORKERDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wORKERDataGridView.DataSource = this.wORKERBindingSource;
            this.wORKERDataGridView.Location = new System.Drawing.Point(232, 12);
            this.wORKERDataGridView.Name = "wORKERDataGridView";
            this.wORKERDataGridView.RowHeadersVisible = false;
            this.wORKERDataGridView.Size = new System.Drawing.Size(556, 132);
            this.wORKERDataGridView.TabIndex = 8;
            // 
            // wORKERBindingSource
            // 
            this.wORKERBindingSource.DataMember = "WORKER";
            // 
            // worker_IDComboBox
            // 
            this.worker_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wORKERBindingSource, "Worker_ID", true));
            this.worker_IDComboBox.FormattingEnabled = true;
            this.worker_IDComboBox.Location = new System.Drawing.Point(105, 32);
            this.worker_IDComboBox.Name = "worker_IDComboBox";
            this.worker_IDComboBox.Size = new System.Drawing.Size(121, 21);
            this.worker_IDComboBox.TabIndex = 7;
            // 
            // user2DataSet
            // 
            this.user2DataSet.DataSetName = "user2DataSet";
            this.user2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pOSTBindingSource1
            // 
            this.pOSTBindingSource1.DataMember = "POST";
            this.pOSTBindingSource1.DataSource = this.user2DataSet;
            // 
            // pOSTTableAdapter
            // 
            this.pOSTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ACCESS_LEVELTableAdapter = null;
            this.tableAdapterManager.ACTIVITY_EMPLOYEETableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DISCIPLINETableAdapter = null;
            this.tableAdapterManager.EDUCATION_FORMTableAdapter = null;
            this.tableAdapterManager.EVENT_MATERIALSTableAdapter = null;
            this.tableAdapterManager.EVENTTableAdapter = null;
            this.tableAdapterManager.POSTTableAdapter = this.pOSTTableAdapter;
            this.tableAdapterManager.SPECIALITYTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = KoinovDiplom_ActEmpKPK.user2DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.USERTableAdapter = null;
            this.tableAdapterManager.WORKERTableAdapter = this.wORKERTableAdapter;
            // 
            // wORKERTableAdapter
            // 
            this.wORKERTableAdapter.ClearBeforeFill = true;
            // 
            // wORKERBindingSource1
            // 
            this.wORKERBindingSource1.DataMember = "WORKER";
            this.wORKERBindingSource1.DataSource = this.user2DataSet;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // FormForClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KoinovDiplom_ActEmpKPK.Properties.Resources._64c14f36767c0e634bd3909a__1;
            this.ClientSize = new System.Drawing.Size(857, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.wORKERDataGridView);
            this.Controls.Add(worker_IDLabel);
            this.Controls.Add(this.worker_IDComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormForClass";
            this.Text = "FormForClass";
            this.Load += new System.EventHandler(this.FormForClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pOSTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKERDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSTBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKERBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource pOSTBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView wORKERDataGridView;
        private System.Windows.Forms.BindingSource wORKERBindingSource;
        private System.Windows.Forms.ComboBox worker_IDComboBox;
        private user2DataSet user2DataSet;
        private System.Windows.Forms.BindingSource pOSTBindingSource1;
        private user2DataSetTableAdapters.POSTTableAdapter pOSTTableAdapter;
        private user2DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private user2DataSetTableAdapters.WORKERTableAdapter wORKERTableAdapter;
        private System.Windows.Forms.BindingSource wORKERBindingSource1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}