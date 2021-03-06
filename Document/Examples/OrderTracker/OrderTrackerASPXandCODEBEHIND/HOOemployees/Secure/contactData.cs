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
    public class contactData : DataSet {
        
        private ContactPeopleDataTable tableContactPeople;
        
        public contactData() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected contactData(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["ContactPeople"] != null)) {
                    this.Tables.Add(new ContactPeopleDataTable(ds.Tables["ContactPeople"]));
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
        public ContactPeopleDataTable ContactPeople {
            get {
                return this.tableContactPeople;
            }
        }
        
        public override DataSet Clone() {
            contactData cln = ((contactData)(base.Clone()));
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
            if ((ds.Tables["ContactPeople"] != null)) {
                this.Tables.Add(new ContactPeopleDataTable(ds.Tables["ContactPeople"]));
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
            this.tableContactPeople = ((ContactPeopleDataTable)(this.Tables["ContactPeople"]));
            if ((this.tableContactPeople != null)) {
                this.tableContactPeople.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "contactData";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/contactData.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableContactPeople = new ContactPeopleDataTable();
            this.Tables.Add(this.tableContactPeople);
        }
        
        private bool ShouldSerializeContactPeople() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void ContactPeopleRowChangeEventHandler(object sender, ContactPeopleRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ContactPeopleDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnCID;
            
            private DataColumn columnname;
            
            private DataColumn columnphone;
            
            private DataColumn columnemail;
            
            private DataColumn columnExpr1;
            
            private DataColumn columnUID;
            
            private DataColumn columncustomerUsername;
            
            internal ContactPeopleDataTable() : 
                    base("ContactPeople") {
                this.InitClass();
            }
            
            internal ContactPeopleDataTable(DataTable table) : 
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
            
            internal DataColumn CIDColumn {
                get {
                    return this.columnCID;
                }
            }
            
            internal DataColumn nameColumn {
                get {
                    return this.columnname;
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
            
            internal DataColumn Expr1Column {
                get {
                    return this.columnExpr1;
                }
            }
            
            internal DataColumn UIDColumn {
                get {
                    return this.columnUID;
                }
            }
            
            internal DataColumn customerUsernameColumn {
                get {
                    return this.columncustomerUsername;
                }
            }
            
            public ContactPeopleRow this[int index] {
                get {
                    return ((ContactPeopleRow)(this.Rows[index]));
                }
            }
            
            public event ContactPeopleRowChangeEventHandler ContactPeopleRowChanged;
            
            public event ContactPeopleRowChangeEventHandler ContactPeopleRowChanging;
            
            public event ContactPeopleRowChangeEventHandler ContactPeopleRowDeleted;
            
            public event ContactPeopleRowChangeEventHandler ContactPeopleRowDeleting;
            
            public void AddContactPeopleRow(ContactPeopleRow row) {
                this.Rows.Add(row);
            }
            
            public ContactPeopleRow AddContactPeopleRow(string CID, string name, string phone, string email, string Expr1, string UID, string customerUsername) {
                ContactPeopleRow rowContactPeopleRow = ((ContactPeopleRow)(this.NewRow()));
                rowContactPeopleRow.ItemArray = new object[] {
                        CID,
                        name,
                        phone,
                        email,
                        Expr1,
                        UID,
                        customerUsername};
                this.Rows.Add(rowContactPeopleRow);
                return rowContactPeopleRow;
            }
            
            public ContactPeopleRow FindByUID(string UID) {
                return ((ContactPeopleRow)(this.Rows.Find(new object[] {
                            UID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                ContactPeopleDataTable cln = ((ContactPeopleDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new ContactPeopleDataTable();
            }
            
            internal void InitVars() {
                this.columnCID = this.Columns["CID"];
                this.columnname = this.Columns["name"];
                this.columnphone = this.Columns["phone"];
                this.columnemail = this.Columns["email"];
                this.columnExpr1 = this.Columns["Expr1"];
                this.columnUID = this.Columns["UID"];
                this.columncustomerUsername = this.Columns["customerUsername"];
            }
            
            private void InitClass() {
                this.columnCID = new DataColumn("CID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCID);
                this.columnname = new DataColumn("name", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnname);
                this.columnphone = new DataColumn("phone", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnphone);
                this.columnemail = new DataColumn("email", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnemail);
                this.columnExpr1 = new DataColumn("Expr1", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnExpr1);
                this.columnUID = new DataColumn("UID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUID);
                this.columncustomerUsername = new DataColumn("customerUsername", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncustomerUsername);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnUID}, true));
                this.columnCID.AllowDBNull = false;
                this.columnname.AllowDBNull = false;
                this.columnphone.AllowDBNull = false;
                this.columnExpr1.AllowDBNull = false;
                this.columnUID.AllowDBNull = false;
                this.columnUID.Unique = true;
                this.columncustomerUsername.AllowDBNull = false;
            }
            
            public ContactPeopleRow NewContactPeopleRow() {
                return ((ContactPeopleRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new ContactPeopleRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(ContactPeopleRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.ContactPeopleRowChanged != null)) {
                    this.ContactPeopleRowChanged(this, new ContactPeopleRowChangeEvent(((ContactPeopleRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.ContactPeopleRowChanging != null)) {
                    this.ContactPeopleRowChanging(this, new ContactPeopleRowChangeEvent(((ContactPeopleRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.ContactPeopleRowDeleted != null)) {
                    this.ContactPeopleRowDeleted(this, new ContactPeopleRowChangeEvent(((ContactPeopleRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.ContactPeopleRowDeleting != null)) {
                    this.ContactPeopleRowDeleting(this, new ContactPeopleRowChangeEvent(((ContactPeopleRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveContactPeopleRow(ContactPeopleRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ContactPeopleRow : DataRow {
            
            private ContactPeopleDataTable tableContactPeople;
            
            internal ContactPeopleRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableContactPeople = ((ContactPeopleDataTable)(this.Table));
            }
            
            public string CID {
                get {
                    return ((string)(this[this.tableContactPeople.CIDColumn]));
                }
                set {
                    this[this.tableContactPeople.CIDColumn] = value;
                }
            }
            
            public string name {
                get {
                    return ((string)(this[this.tableContactPeople.nameColumn]));
                }
                set {
                    this[this.tableContactPeople.nameColumn] = value;
                }
            }
            
            public string phone {
                get {
                    return ((string)(this[this.tableContactPeople.phoneColumn]));
                }
                set {
                    this[this.tableContactPeople.phoneColumn] = value;
                }
            }
            
            public string email {
                get {
                    try {
                        return ((string)(this[this.tableContactPeople.emailColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableContactPeople.emailColumn] = value;
                }
            }
            
            public string Expr1 {
                get {
                    return ((string)(this[this.tableContactPeople.Expr1Column]));
                }
                set {
                    this[this.tableContactPeople.Expr1Column] = value;
                }
            }
            
            public string UID {
                get {
                    return ((string)(this[this.tableContactPeople.UIDColumn]));
                }
                set {
                    this[this.tableContactPeople.UIDColumn] = value;
                }
            }
            
            public string customerUsername {
                get {
                    return ((string)(this[this.tableContactPeople.customerUsernameColumn]));
                }
                set {
                    this[this.tableContactPeople.customerUsernameColumn] = value;
                }
            }
            
            public bool IsemailNull() {
                return this.IsNull(this.tableContactPeople.emailColumn);
            }
            
            public void SetemailNull() {
                this[this.tableContactPeople.emailColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ContactPeopleRowChangeEvent : EventArgs {
            
            private ContactPeopleRow eventRow;
            
            private DataRowAction eventAction;
            
            public ContactPeopleRowChangeEvent(ContactPeopleRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public ContactPeopleRow Row {
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
