﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace OrderTrackerv2.HOOemployees {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class ManagementPendingData : DataSet {
        
        private OrdersDataTable tableOrders;
        
        public ManagementPendingData() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected ManagementPendingData(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Orders"] != null)) {
                    this.Tables.Add(new OrdersDataTable(ds.Tables["Orders"]));
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
        public OrdersDataTable Orders {
            get {
                return this.tableOrders;
            }
        }
        
        public override DataSet Clone() {
            ManagementPendingData cln = ((ManagementPendingData)(base.Clone()));
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
            if ((ds.Tables["Orders"] != null)) {
                this.Tables.Add(new OrdersDataTable(ds.Tables["Orders"]));
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
            this.tableOrders = ((OrdersDataTable)(this.Tables["Orders"]));
            if ((this.tableOrders != null)) {
                this.tableOrders.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "ManagementPendingData";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/ManagementPendingData.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableOrders = new OrdersDataTable();
            this.Tables.Add(this.tableOrders);
        }
        
        private bool ShouldSerializeOrders() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void OrdersRowChangeEventHandler(object sender, OrdersRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrdersDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnorderNumber;
            
            private DataColumn columnorderDate;
            
            private DataColumn columndueDate;
            
            private DataColumn columnrecDate;
            
            private DataColumn columnrushReorderRegular;
            
            private DataColumn columnorderType;
            
            private DataColumn columncustomerNumber;
            
            private DataColumn columntotalDue;
            
            private DataColumn columnbalanceDue;
            
            private DataColumn columnartFinished;
            
            private DataColumn columnproductionFinished;
            
            private DataColumn columnorderFinished;
            
            internal OrdersDataTable() : 
                    base("Orders") {
                this.InitClass();
            }
            
            internal OrdersDataTable(DataTable table) : 
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
            
            internal DataColumn orderNumberColumn {
                get {
                    return this.columnorderNumber;
                }
            }
            
            internal DataColumn orderDateColumn {
                get {
                    return this.columnorderDate;
                }
            }
            
            internal DataColumn dueDateColumn {
                get {
                    return this.columndueDate;
                }
            }
            
            internal DataColumn recDateColumn {
                get {
                    return this.columnrecDate;
                }
            }
            
            internal DataColumn rushReorderRegularColumn {
                get {
                    return this.columnrushReorderRegular;
                }
            }
            
            internal DataColumn orderTypeColumn {
                get {
                    return this.columnorderType;
                }
            }
            
            internal DataColumn customerNumberColumn {
                get {
                    return this.columncustomerNumber;
                }
            }
            
            internal DataColumn totalDueColumn {
                get {
                    return this.columntotalDue;
                }
            }
            
            internal DataColumn balanceDueColumn {
                get {
                    return this.columnbalanceDue;
                }
            }
            
            internal DataColumn artFinishedColumn {
                get {
                    return this.columnartFinished;
                }
            }
            
            internal DataColumn productionFinishedColumn {
                get {
                    return this.columnproductionFinished;
                }
            }
            
            internal DataColumn orderFinishedColumn {
                get {
                    return this.columnorderFinished;
                }
            }
            
            public OrdersRow this[int index] {
                get {
                    return ((OrdersRow)(this.Rows[index]));
                }
            }
            
            public event OrdersRowChangeEventHandler OrdersRowChanged;
            
            public event OrdersRowChangeEventHandler OrdersRowChanging;
            
            public event OrdersRowChangeEventHandler OrdersRowDeleted;
            
            public event OrdersRowChangeEventHandler OrdersRowDeleting;
            
            public void AddOrdersRow(OrdersRow row) {
                this.Rows.Add(row);
            }
            
            public OrdersRow AddOrdersRow(int orderNumber, System.DateTime orderDate, System.DateTime dueDate, System.DateTime recDate, string rushReorderRegular, string orderType, string customerNumber, System.Decimal totalDue, System.Decimal balanceDue, bool artFinished, bool productionFinished, bool orderFinished) {
                OrdersRow rowOrdersRow = ((OrdersRow)(this.NewRow()));
                rowOrdersRow.ItemArray = new object[] {
                        orderNumber,
                        orderDate,
                        dueDate,
                        recDate,
                        rushReorderRegular,
                        orderType,
                        customerNumber,
                        totalDue,
                        balanceDue,
                        artFinished,
                        productionFinished,
                        orderFinished};
                this.Rows.Add(rowOrdersRow);
                return rowOrdersRow;
            }
            
            public OrdersRow FindByorderNumber(int orderNumber) {
                return ((OrdersRow)(this.Rows.Find(new object[] {
                            orderNumber})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                OrdersDataTable cln = ((OrdersDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new OrdersDataTable();
            }
            
            internal void InitVars() {
                this.columnorderNumber = this.Columns["orderNumber"];
                this.columnorderDate = this.Columns["orderDate"];
                this.columndueDate = this.Columns["dueDate"];
                this.columnrecDate = this.Columns["recDate"];
                this.columnrushReorderRegular = this.Columns["rushReorderRegular"];
                this.columnorderType = this.Columns["orderType"];
                this.columncustomerNumber = this.Columns["customerNumber"];
                this.columntotalDue = this.Columns["totalDue"];
                this.columnbalanceDue = this.Columns["balanceDue"];
                this.columnartFinished = this.Columns["artFinished"];
                this.columnproductionFinished = this.Columns["productionFinished"];
                this.columnorderFinished = this.Columns["orderFinished"];
            }
            
            private void InitClass() {
                this.columnorderNumber = new DataColumn("orderNumber", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnorderNumber);
                this.columnorderDate = new DataColumn("orderDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnorderDate);
                this.columndueDate = new DataColumn("dueDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columndueDate);
                this.columnrecDate = new DataColumn("recDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnrecDate);
                this.columnrushReorderRegular = new DataColumn("rushReorderRegular", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnrushReorderRegular);
                this.columnorderType = new DataColumn("orderType", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnorderType);
                this.columncustomerNumber = new DataColumn("customerNumber", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncustomerNumber);
                this.columntotalDue = new DataColumn("totalDue", typeof(System.Decimal), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columntotalDue);
                this.columnbalanceDue = new DataColumn("balanceDue", typeof(System.Decimal), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnbalanceDue);
                this.columnartFinished = new DataColumn("artFinished", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnartFinished);
                this.columnproductionFinished = new DataColumn("productionFinished", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnproductionFinished);
                this.columnorderFinished = new DataColumn("orderFinished", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnorderFinished);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnorderNumber}, true));
                this.columnorderNumber.AllowDBNull = false;
                this.columnorderNumber.Unique = true;
                this.columnorderDate.AllowDBNull = false;
                this.columnrushReorderRegular.AllowDBNull = false;
                this.columnorderType.AllowDBNull = false;
                this.columncustomerNumber.AllowDBNull = false;
            }
            
            public OrdersRow NewOrdersRow() {
                return ((OrdersRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new OrdersRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(OrdersRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.OrdersRowChanged != null)) {
                    this.OrdersRowChanged(this, new OrdersRowChangeEvent(((OrdersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.OrdersRowChanging != null)) {
                    this.OrdersRowChanging(this, new OrdersRowChangeEvent(((OrdersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.OrdersRowDeleted != null)) {
                    this.OrdersRowDeleted(this, new OrdersRowChangeEvent(((OrdersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.OrdersRowDeleting != null)) {
                    this.OrdersRowDeleting(this, new OrdersRowChangeEvent(((OrdersRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveOrdersRow(OrdersRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrdersRow : DataRow {
            
            private OrdersDataTable tableOrders;
            
            internal OrdersRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableOrders = ((OrdersDataTable)(this.Table));
            }
            
            public int orderNumber {
                get {
                    return ((int)(this[this.tableOrders.orderNumberColumn]));
                }
                set {
                    this[this.tableOrders.orderNumberColumn] = value;
                }
            }
            
            public System.DateTime orderDate {
                get {
                    return ((System.DateTime)(this[this.tableOrders.orderDateColumn]));
                }
                set {
                    this[this.tableOrders.orderDateColumn] = value;
                }
            }
            
            public System.DateTime dueDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.tableOrders.dueDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.dueDateColumn] = value;
                }
            }
            
            public System.DateTime recDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.tableOrders.recDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.recDateColumn] = value;
                }
            }
            
            public string rushReorderRegular {
                get {
                    return ((string)(this[this.tableOrders.rushReorderRegularColumn]));
                }
                set {
                    this[this.tableOrders.rushReorderRegularColumn] = value;
                }
            }
            
            public string orderType {
                get {
                    return ((string)(this[this.tableOrders.orderTypeColumn]));
                }
                set {
                    this[this.tableOrders.orderTypeColumn] = value;
                }
            }
            
            public string customerNumber {
                get {
                    return ((string)(this[this.tableOrders.customerNumberColumn]));
                }
                set {
                    this[this.tableOrders.customerNumberColumn] = value;
                }
            }
            
            public System.Decimal totalDue {
                get {
                    try {
                        return ((System.Decimal)(this[this.tableOrders.totalDueColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.totalDueColumn] = value;
                }
            }
            
            public System.Decimal balanceDue {
                get {
                    try {
                        return ((System.Decimal)(this[this.tableOrders.balanceDueColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.balanceDueColumn] = value;
                }
            }
            
            public bool artFinished {
                get {
                    try {
                        return ((bool)(this[this.tableOrders.artFinishedColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.artFinishedColumn] = value;
                }
            }
            
            public bool productionFinished {
                get {
                    try {
                        return ((bool)(this[this.tableOrders.productionFinishedColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.productionFinishedColumn] = value;
                }
            }
            
            public bool orderFinished {
                get {
                    try {
                        return ((bool)(this[this.tableOrders.orderFinishedColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrders.orderFinishedColumn] = value;
                }
            }
            
            public bool IsdueDateNull() {
                return this.IsNull(this.tableOrders.dueDateColumn);
            }
            
            public void SetdueDateNull() {
                this[this.tableOrders.dueDateColumn] = System.Convert.DBNull;
            }
            
            public bool IsrecDateNull() {
                return this.IsNull(this.tableOrders.recDateColumn);
            }
            
            public void SetrecDateNull() {
                this[this.tableOrders.recDateColumn] = System.Convert.DBNull;
            }
            
            public bool IstotalDueNull() {
                return this.IsNull(this.tableOrders.totalDueColumn);
            }
            
            public void SettotalDueNull() {
                this[this.tableOrders.totalDueColumn] = System.Convert.DBNull;
            }
            
            public bool IsbalanceDueNull() {
                return this.IsNull(this.tableOrders.balanceDueColumn);
            }
            
            public void SetbalanceDueNull() {
                this[this.tableOrders.balanceDueColumn] = System.Convert.DBNull;
            }
            
            public bool IsartFinishedNull() {
                return this.IsNull(this.tableOrders.artFinishedColumn);
            }
            
            public void SetartFinishedNull() {
                this[this.tableOrders.artFinishedColumn] = System.Convert.DBNull;
            }
            
            public bool IsproductionFinishedNull() {
                return this.IsNull(this.tableOrders.productionFinishedColumn);
            }
            
            public void SetproductionFinishedNull() {
                this[this.tableOrders.productionFinishedColumn] = System.Convert.DBNull;
            }
            
            public bool IsorderFinishedNull() {
                return this.IsNull(this.tableOrders.orderFinishedColumn);
            }
            
            public void SetorderFinishedNull() {
                this[this.tableOrders.orderFinishedColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrdersRowChangeEvent : EventArgs {
            
            private OrdersRow eventRow;
            
            private DataRowAction eventAction;
            
            public OrdersRowChangeEvent(OrdersRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public OrdersRow Row {
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
