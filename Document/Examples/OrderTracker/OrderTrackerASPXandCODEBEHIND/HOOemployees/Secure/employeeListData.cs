﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace OrderTrackerv2.HOOemployees.Secure {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class employeeListData : DataSet {
        
        private EmployeesDataTable tableEmployees;
        
        public employeeListData() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected employeeListData(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Employees"] != null)) {
                    this.Tables.Add(new EmployeesDataTable(ds.Tables["Employees"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public EmployeesDataTable Employees {
            get {
                return this.tableEmployees;
            }
        }
        
        public override DataSet Clone() {
            employeeListData cln = ((employeeListData)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["Employees"] != null)) {
                this.Tables.Add(new EmployeesDataTable(ds.Tables["Employees"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableEmployees = ((EmployeesDataTable)(this.Tables["Employees"]));
            if ((this.tableEmployees != null)) {
                this.tableEmployees.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "employeeListData";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/employeeListData.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableEmployees = new EmployeesDataTable();
            this.Tables.Add(this.tableEmployees);
        }
        
        private bool ShouldSerializeEmployees() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void EmployeesRowChangeEventHandler(object sender, EmployeesRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class EmployeesDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnUID;
            
            private DataColumn columnpassword;
            
            private DataColumn columnemployeename;
            
            private DataColumn columnemployeetype;
            
            private DataColumn columnphone;
            
            private DataColumn columnemail;
            
            private DataColumn columnadministrator;
            
            internal EmployeesDataTable() : 
                    base("Employees") {
                this.InitClass();
            }
            
            internal EmployeesDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn UIDColumn {
                get {
                    return this.columnUID;
                }
            }
            
            internal DataColumn passwordColumn {
                get {
                    return this.columnpassword;
                }
            }
            
            internal DataColumn employeenameColumn {
                get {
                    return this.columnemployeename;
                }
            }
            
            internal DataColumn employeetypeColumn {
                get {
                    return this.columnemployeetype;
                }
            }
            
            internal DataColumn phoneColumn {
                get {
                    return this.columnphone;
                }
            }
            
            internal DataColumn emailColumn {
                get {
                    return this.columnemail;
                }
            }
            
            internal DataColumn administratorColumn {
                get {
                    return this.columnadministrator;
                }
            }
            
            public EmployeesRow this[int index] {
                get {
                    return ((EmployeesRow)(this.Rows[index]));
                }
            }
            
            public event EmployeesRowChangeEventHandler EmployeesRowChanged;
            
            public event EmployeesRowChangeEventHandler EmployeesRowChanging;
            
            public event EmployeesRowChangeEventHandler EmployeesRowDeleted;
            
            public event EmployeesRowChangeEventHandler EmployeesRowDeleting;
            
            public void AddEmployeesRow(EmployeesRow row) {
                this.Rows.Add(row);
            }
            
            public EmployeesRow AddEmployeesRow(string UID, string password, string employeename, string employeetype, string phone, string email, string administrator) {
                EmployeesRow rowEmployeesRow = ((EmployeesRow)(this.NewRow()));
                rowEmployeesRow.ItemArray = new object[] {
                        UID,
                        password,
                        employeename,
                        employeetype,
                        phone,
                        email,
                        administrator};
                this.Rows.Add(rowEmployeesRow);
                return rowEmployeesRow;
            }
            
            public EmployeesRow FindByUIDpassword(string UID, string password) {
                return ((EmployeesRow)(this.Rows.Find(new object[] {
                            UID,
                            password})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                EmployeesDataTable cln = ((EmployeesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new EmployeesDataTable();
            }
            
            internal void InitVars() {
                this.columnUID = this.Columns["UID"];
                this.columnpassword = this.Columns["password"];
                this.columnemployeename = this.Columns["employeename"];
                this.columnemployeetype = this.Columns["employeetype"];
                this.columnphone = this.Columns["phone"];
                this.columnemail = this.Columns["email"];
                this.columnadministrator = this.Columns["administrator"];
            }
            
            private void InitClass() {
                this.columnUID = new DataColumn("UID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUID);
                this.columnpassword = new DataColumn("password", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnpassword);
                this.columnemployeename = new DataColumn("employeename", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnemployeename);
                this.columnemployeetype = new DataColumn("employeetype", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnemployeetype);
                this.columnphone = new DataColumn("phone", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnphone);
                this.columnemail = new DataColumn("email", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnemail);
                this.columnadministrator = new DataColumn("administrator", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnadministrator);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnUID,
                                this.columnpassword}, true));
                this.columnUID.AllowDBNull = false;
                this.columnpassword.AllowDBNull = false;
                this.columnemployeename.AllowDBNull = false;
                this.columnemployeetype.AllowDBNull = false;
                this.columnphone.AllowDBNull = false;
                this.columnadministrator.AllowDBNull = false;
            }
            
            public EmployeesRow NewEmployeesRow() {
                return ((EmployeesRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new EmployeesRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(EmployeesRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.EmployeesRowChanged != null)) {
                    this.EmployeesRowChanged(this, new EmployeesRowChangeEvent(((EmployeesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.EmployeesRowChanging != null)) {
                    this.EmployeesRowChanging(this, new EmployeesRowChangeEvent(((EmployeesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.EmployeesRowDeleted != null)) {
                    this.EmployeesRowDeleted(this, new EmployeesRowChangeEvent(((EmployeesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.EmployeesRowDeleting != null)) {
                    this.EmployeesRowDeleting(this, new EmployeesRowChangeEvent(((EmployeesRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveEmployeesRow(EmployeesRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class EmployeesRow : DataRow {
            
            private EmployeesDataTable tableEmployees;
            
            internal EmployeesRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableEmployees = ((EmployeesDataTable)(this.Table));
            }
            
            public string UID {
                get {
                    return ((string)(this[this.tableEmployees.UIDColumn]));
                }
                set {
                    this[this.tableEmployees.UIDColumn] = value;
                }
            }
            
            public string password {
                get {
                    return ((string)(this[this.tableEmployees.passwordColumn]));
                }
                set {
                    this[this.tableEmployees.passwordColumn] = value;
                }
            }
            
            public string employeename {
                get {
                    return ((string)(this[this.tableEmployees.employeenameColumn]));
                }
                set {
                    this[this.tableEmployees.employeenameColumn] = value;
                }
            }
            
            public string employeetype {
                get {
                    return ((string)(this[this.tableEmployees.employeetypeColumn]));
                }
                set {
                    this[this.tableEmployees.employeetypeColumn] = value;
                }
            }
            
            public string phone {
                get {
                    return ((string)(this[this.tableEmployees.phoneColumn]));
                }
                set {
                    this[this.tableEmployees.phoneColumn] = value;
                }
            }
            
            public string email {
                get {
                    try {
                        return ((string)(this[this.tableEmployees.emailColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableEmployees.emailColumn] = value;
                }
            }
            
            public string administrator {
                get {
                    return ((string)(this[this.tableEmployees.administratorColumn]));
                }
                set {
                    this[this.tableEmployees.administratorColumn] = value;
                }
            }
            
            public bool IsemailNull() {
                return this.IsNull(this.tableEmployees.emailColumn);
            }
            
            public void SetemailNull() {
                this[this.tableEmployees.emailColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class EmployeesRowChangeEvent : EventArgs {
            
            private EmployeesRow eventRow;
            
            private DataRowAction eventAction;
            
            public EmployeesRowChangeEvent(EmployeesRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public EmployeesRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}